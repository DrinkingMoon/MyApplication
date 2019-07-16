namespace MyWpfMVVMApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dish",
                c => new
                    {
                        PKID = c.Guid(nullable: false),
                        Name = c.String(),
                        Category = c.String(),
                        Comment = c.String(),
                        Score = c.Double(),
                        FKID_Restaurant = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PKID)
                .ForeignKey("dbo.Restaurant", t => t.FKID_Restaurant, cascadeDelete: true)
                .Index(t => t.FKID_Restaurant);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        PKID = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.PKID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dish", "FKID_Restaurant", "dbo.Restaurant");
            DropIndex("dbo.Dish", new[] { "FKID_Restaurant" });
            DropTable("dbo.Restaurant");
            DropTable("dbo.Dish");
        }
    }
}
