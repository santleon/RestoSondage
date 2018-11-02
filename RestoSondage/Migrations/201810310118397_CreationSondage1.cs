namespace RestoSondage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationSondage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "name", c => c.String());
            DropColumn("dbo.Restaurants", "éname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "éname", c => c.String());
            DropColumn("dbo.Restaurants", "name");
        }
    }
}
