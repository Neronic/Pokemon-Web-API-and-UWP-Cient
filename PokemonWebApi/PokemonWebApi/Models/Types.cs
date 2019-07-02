using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PokemonWebApi.Models
{
    [DataContract(IsReference=true)]
    public class Types
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [Display(Name = "Type: ")]
        [Required(ErrorMessage = "Type name cannot be left blank.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Type name needs to be between 3 and 20 letters.")]
        public string TypeName { get; set; }

        [DataMember]
        [Display(Name = "Type One:")]
        [StringLength(20, ErrorMessage = "Type one cannot exceed 20 letters.")]
        public string TypeOne { get; set; }
        
        [DataMember]
        [Display(Name = "Type Two:")]
        [StringLength(20, ErrorMessage = "Type two cannot exceed 20 letters.")]
        public string TypeTwo { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
