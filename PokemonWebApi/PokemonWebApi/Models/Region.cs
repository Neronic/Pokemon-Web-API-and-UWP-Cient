using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PokemonWebApi.Models
{
    [DataContract(IsReference=true)]
    public class Region
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        [Display(Name = "Region: ")]
        [Required(ErrorMessage = "You must enter the name of the region.")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Region name must be between 3 and 15 characters long.")]
        public string RegionName { get; set; }

        public ICollection<Route> Route { get; set; }
    }
}
