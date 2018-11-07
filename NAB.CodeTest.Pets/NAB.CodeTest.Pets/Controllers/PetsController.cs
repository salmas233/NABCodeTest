using NLog;
using System;
using System.Linq;
using System.Web.Http;
using NAB.CodeTest.Pets.Models;
using System.Collections.Generic;

namespace NAB.CodeTest.Pets.Controllers
{
    public class PetsController : ApiController
    {
        #region Private Variables
        private ILogger logger = LogManager.GetCurrentClassLogger();
        #endregion

        [HttpPost]
        public IHttpActionResult Post(List<PetOwnerRequest> petOwners)
        {
            try
            {
                var result = new List<PetOwnerResponse>();

                foreach (var ownerGroup in petOwners.GroupBy(po => po.gender))
                {
                    result.Add(new PetOwnerResponse()
                    {
                        gender = ownerGroup.Key.Value,
                        catNames = ownerGroup.Where( o => o.pets?.Any() == true)
                                   .SelectMany(o => o.pets)
                                   .Where(o => o.type == PetType.Cat)
                                   .Select(o => o.name).ToList()
                    });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Error($"Unexpected error encounted. Technical Details : {ex.ToString()}");
                return StatusCode(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}