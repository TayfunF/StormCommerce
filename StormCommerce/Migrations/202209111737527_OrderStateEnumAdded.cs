namespace StormCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderStateEnumAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderState", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderState");
        }
    }
}
