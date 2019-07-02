using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClient.Models
{
    [DataContract]
    public class Region
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string RegionName { get; set; }
    }
}
