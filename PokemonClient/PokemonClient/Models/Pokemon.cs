using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClient.Models
{
    [DataContract]
    public class Pokemon
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int TypesID { get; set; }
        [DataMember]
        public Types Types { get; set; }
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public Route Route { get; set; }
    }
}
