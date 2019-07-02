using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PokemonWebApi.Models
{
    [DataContract(IsReference=true)]
    public class Route
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [Display(Name = "Route: ")]
        [Required(ErrorMessage = "Cannot leave name of route blank.")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Route name must be between 4 and 30 characters.")]
        public string RouteName { get; set; }

        public ICollection<Pokemon> Pokemons { get; set; }

        public int RegionID { get; set; }
        public Region Region { get; set; }

    }
}
