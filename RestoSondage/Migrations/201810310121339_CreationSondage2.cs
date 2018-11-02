namespace RestoSondage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationSondage2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sondages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        éname = c.String(),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Restaurant_Id = c.Int(),
                        Utilisateur_Id = c.Int(),
                        Sondage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id)
                .ForeignKey("dbo.Users", t => t.Utilisateur_Id)
                .ForeignKey("dbo.Sondages", t => t.Sondage_Id)
                .Index(t => t.Restaurant_Id)
                .Index(t => t.Utilisateur_Id)
                .Index(t => t.Sondage_Id);
            
            AddColumn("dbo.Restaurants", "Sondage_Id", c => c.Int());
            AddColumn("dbo.Users", "Sondage_Id", c => c.Int());
            CreateIndex("dbo.Restaurants", "Sondage_Id");
            CreateIndex("dbo.Users", "Sondage_Id");
            AddForeignKey("dbo.Restaurants", "Sondage_Id", "dbo.Sondages", "Id");
            AddForeignKey("dbo.Users", "Sondage_Id", "dbo.Sondages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Sondage_Id", "dbo.Sondages");
            DropForeignKey("dbo.Votes", "Utilisateur_Id", "dbo.Users");
            DropForeignKey("dbo.Votes", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.Users", "Sondage_Id", "dbo.Sondages");
            DropForeignKey("dbo.Restaurants", "Sondage_Id", "dbo.Sondages");
            DropIndex("dbo.Votes", new[] { "Sondage_Id" });
            DropIndex("dbo.Votes", new[] { "Utilisateur_Id" });
            DropIndex("dbo.Votes", new[] { "Restaurant_Id" });
            DropIndex("dbo.Users", new[] { "Sondage_Id" });
            DropIndex("dbo.Restaurants", new[] { "Sondage_Id" });
            DropColumn("dbo.Users", "Sondage_Id");
            DropColumn("dbo.Restaurants", "Sondage_Id");
            DropTable("dbo.Votes");
            DropTable("dbo.Sondages");
        }
    }
}
