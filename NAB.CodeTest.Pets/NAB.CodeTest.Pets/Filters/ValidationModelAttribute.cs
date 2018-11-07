using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace NAB.CodeTest.Pets.Filters
{
    public class ValidationModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                                        actionContext.ModelState);
            }
        }
    }
}