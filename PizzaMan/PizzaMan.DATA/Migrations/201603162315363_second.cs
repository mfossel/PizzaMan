namespace PizzaMan.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AspectRatings");
            AlterColumn("dbo.AspectRatings", "Rating", c => c.Single(nullable: false));
            AddPrimaryKey("dbo.AspectRatings", new[] { "AspectId", "ReviewId" });
            DropColumn("dbo.AspectRatings", "AspectRatingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspectRatings", "AspectRatingId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.AspectRatings");
            AlterColumn("dbo.AspectRatings", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddPrimaryKey("dbo.AspectRatings", "AspectRatingId");
        }
    }
}
