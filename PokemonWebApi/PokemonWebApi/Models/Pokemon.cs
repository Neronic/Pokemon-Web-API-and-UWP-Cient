using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PokemonWebApi.Models
{

    public class Pokemon
    {
        public int ID { get; set; }

        [Display(Name = "Name: ")]
        [Required(ErrorMessage = "Name cannot be blank.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]
        public string Name {get;set;}

        [Display(Name = "No.: ")]
        [Required(ErrorMessage = "Number cannot be left blank")]
        [Range(1, 807, ErrorMessage = "Number must be between 1 and 807.")]
        public int Number {get;set;}

        [Display(Name = "Description: ")]
        [StringLength(250, ErrorMessage = "Description can't be longer than 250 characters.")]
        public string Description {get;set;}

        public int TypesID { get; set; }
        public Types Types { get; set; }

        public int RouteID { get; set; }
        public Route Route { get; set; }
        
    }
}
