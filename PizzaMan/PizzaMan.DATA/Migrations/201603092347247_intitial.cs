namespace PizzaMan.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Neighborhoods",
                c => new
                    {
                        NeighborhoodId = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        NeighborhoodName = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NeighborhoodId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Pizzerias",
                c => new
                    {
                        PizzeriaId = c.Int(nullable: false, identity: true),
                        NeighborhoodId = c.Int(nullable: false),
                        YearOpened = c.Int(nullable: false),
                        Type = c.String(),
                        Style = c.String(),
                        Description = c.String(),
                        Delivery = c.Boolean(nullable: false),
                        Takeout = c.Boolean(nullable: false),
                        Sitdown = c.Boolean(nullable: false),
                        Alcohol = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        DrinkSelection = c.String(),
                        MenuURL = c.String(),
                        OvenType = c.String(),
                        GlutenFreeOption = c.Boolean(nullable: false),
                        VeganOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PizzeriaId)
                .ForeignKey("dbo.Neighborhoods", t => t.NeighborhoodId, cascadeDelete: true)
                .Index(t => t.NeighborhoodId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PizzeriaId = c.Int(nullable: false),
                        PhotoURL = c.String(),
                        NumberOfLikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzerias", t => t.PizzeriaId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PizzeriaId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmailAddress = c.String(),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        PizzeriaId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Crust = c.Int(nullable: false),
                        Cheese = c.Int(nullable: false),
                        Toppings = c.Int(nullable: false),
                        CustomerService = c.Int(nullable: false),
                        OtherFoodItems = c.Int(),
                        Drinks = c.Int(),
                        OverallExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzerias", t => t.PizzeriaId, cascadeDelete: true)
                .Index(t => t.PizzeriaId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Neighborhoods", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Pizzerias", "NeighborhoodId", "dbo.Neighborhoods");
            DropForeignKey("dbo.Reviews", "PizzeriaId", "dbo.Pizzerias");
            DropForeignKey("dbo.Photos", "PizzeriaId", "dbo.Pizzerias");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "PizzeriaId" });
            DropIndex("dbo.Photos", new[] { "PizzeriaId" });
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropIndex("dbo.Pizzerias", new[] { "NeighborhoodId" });
            DropIndex("dbo.Neighborhoods", new[] { "CityId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Users");
            DropTable("dbo.Photos");
            DropTable("dbo.Pizzerias");
            DropTable("dbo.Neighborhoods");
            DropTable("dbo.Cities");
        }
    }
}
