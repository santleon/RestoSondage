using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestoSondage.Models
{
    [DataContract]
    public class Sondage
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string éname { get; set; }
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }
        [DataMember(Name = "userIds")]
        public User Utilisateur { get; set; }
        [DataMember(Name = "restoIds")]
        public Restaurant Restaurant { get; set; }
    }
}