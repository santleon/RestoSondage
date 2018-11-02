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
        public string Name { get; set; }
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }
        [DataMember(Name = "userIds")]
        public List<User> Utilisateur { get; set; }
        [DataMember(Name = "restoIds")]
        public List<Restaurant­­> Restaurant { get; set; }
        [DataMember(Name = "votes")]
        public List<Vote> Votes { get; set; }
    }
}