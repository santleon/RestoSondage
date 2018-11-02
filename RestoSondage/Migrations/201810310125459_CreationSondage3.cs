namespace RestoSondage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationSondage3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sondages", "Name", c => c.String());
            DropColumn("dbo.Sondages", "éname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sondages", "éname", c => c.String());
            DropColumn("dbo.Sondages", "Name");
        }
    }
}
