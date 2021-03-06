namespace RestaurantWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleAddedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Role");
        }
    }
}
