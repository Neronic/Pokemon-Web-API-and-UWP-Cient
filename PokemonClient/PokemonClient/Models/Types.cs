using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClient.Models
{
    [DataContract]
    public class Types
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string TypeName { get; set; }
        [DataMember]
        public string TypeOne { get; set; }
        [DataMember]
        public string TypeTwo { get; set; }
    }
}
