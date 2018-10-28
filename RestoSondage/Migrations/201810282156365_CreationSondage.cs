namespace RestoSondage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationSondage : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Utilisateurs", newName: "Users");
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        éname = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurants");
            RenameTable(name: "dbo.Users", newName: "Utilisateurs");
        }
    }
}
