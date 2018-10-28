using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestoSondage.Models
{
    [DataContract]
    public class Restaurant
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string éname { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
    }
}