using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestoSondage.Models
{
    public class Vote
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "userId")]
        public User Utilisateur { get; set; }
        [DataMember(Name = "restoId")]
        public Restaurant­­ Restaurant { get; set; }
    }
}