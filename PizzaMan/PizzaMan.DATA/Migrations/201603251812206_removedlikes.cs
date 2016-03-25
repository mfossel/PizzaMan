namespace PizzaMan.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedlikes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Photos", "NumberOfLikes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "NumberOfLikes", c => c.Int(nullable: false));
        }
    }
}
