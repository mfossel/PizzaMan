namespace PizzaMan.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                .ForeignKey("dbo.Pizzerias", t => t.PizzeriaId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PizzeriaId);
            
            CreateTable(
                "dbo.Pizzerias",
                c => new
                    {
                        PizzeriaId = c.Int(nullable: false, identity: true),
                        PizzeriaName = c.String(),
                        YearOpened = c.Int(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Style = c.String(),
                        Description = c.String(),
                        Delivery = c.Boolean(nullable: false),
                        Takeout = c.Boolean(nullable: false),
                        Sitdown = c.Boolean(nullable: false),
                        Alcohol = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        MenuURL = c.String(),
                        OvenType = c.String(),
                        GlutenFreeOption = c.Boolean(nullable: false),
                        VeganOption = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PizzeriaId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "PizzeriaId", "dbo.Pizzerias");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "PizzeriaId", "dbo.Pizzerias");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "PizzeriaId" });
            DropIndex("dbo.Photos", new[] { "PizzeriaId" });
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
            DropTable("dbo.Pizzerias");
            DropTable("dbo.Photos");
        }
    }
}
