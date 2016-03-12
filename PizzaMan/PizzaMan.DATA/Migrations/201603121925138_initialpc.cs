namespace PizzaMan.DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialpc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizzerias", "Address", c => c.String());
            AddColumn("dbo.Pizzerias", "City", c => c.String());
            AddColumn("dbo.Pizzerias", "State", c => c.String());
            AddColumn("dbo.Pizzerias", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pizzerias", "ZipCode");
            DropColumn("dbo.Pizzerias", "State");
            DropColumn("dbo.Pizzerias", "City");
            DropColumn("dbo.Pizzerias", "Address");
        }
    }
}
