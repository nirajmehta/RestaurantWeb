namespace RestaurantWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleNonNullColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Role", c => c.String(nullable: false, defaultValue: "Customer"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Role");
        }
    }
}
