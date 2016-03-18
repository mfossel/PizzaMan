namespace PizzaMan.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ZipCode");
        }
    }
}
