using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClient.Models
{
    [DataContract]
    public class Route
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string RouteName { get; set; }
        [DataMember]
        public int RegionID { get; set; }
        [DataMember]
        public Region Region { get; set; }
    }
}
