﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestoSondage.Models
{
    public class RestoSondageContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RestoSondageContext() : base("name=RestoSondageContext")
        {
        }

        public System.Data.Entity.DbSet<RestoSondage.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<RestoSondage.Models.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<RestoSondage.Models.Sondage> Sondages { get; set; }

        public System.Data.Entity.DbSet<RestoSondage.Models.Vote> Votes { get; set; }
    }
}
