namespace GroupCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanothertwovariables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PricePoint", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "Distance", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Distance");
            DropColumn("dbo.AspNetUsers", "PricePoint");
        }
    }
}
