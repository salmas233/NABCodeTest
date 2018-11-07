using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NAB.CodeTest.Pets.Models
{
    public class PetOwnerRequest
    {
        [Required(ErrorMessage ="Owner name is required.")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "Owner gender is required.")]
        public Gender? gender { get; set; }
        public int age { get; set; }
        public List<Pet> pets { get; set; }
    }
}