namespace PizzaMan.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspectRatings",
                c => new
                    {
                        AspectRatingId = c.Int(nullable: false, identity: true),
                        AspectId = c.Int(nullable: false),
                        ReviewId = c.Int(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AspectRatingId)
                .ForeignKey("dbo.Aspects", t => t.AspectId, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.ReviewId, cascadeDelete: true)
                .Index(t => t.AspectId)
                .Index(t => t.ReviewId);
            
            CreateTable(
                "dbo.Aspects",
                c => new
                    {
                        AspectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AspectId);
            
            DropColumn("dbo.Reviews", "Crust");
            DropColumn("dbo.Reviews", "Cheese");
            DropColumn("dbo.Reviews", "Toppings");
            DropColumn("dbo.Reviews", "CustomerService");
            DropColumn("dbo.Reviews", "OtherFoodItems");
            DropColumn("dbo.Reviews", "Drinks");
            DropColumn("dbo.Reviews", "OverallExperience");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "OverallExperience", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Drinks", c => c.Int());
            AddColumn("dbo.Reviews", "OtherFoodItems", c => c.Int());
            AddColumn("dbo.Reviews", "CustomerService", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Toppings", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Cheese", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Crust", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspectRatings", "ReviewId", "dbo.Reviews");
            DropForeignKey("dbo.AspectRatings", "AspectId", "dbo.Aspects");
            DropIndex("dbo.AspectRatings", new[] { "ReviewId" });
            DropIndex("dbo.AspectRatings", new[] { "AspectId" });
            DropTable("dbo.Aspects");
            DropTable("dbo.AspectRatings");
        }
    }
}
