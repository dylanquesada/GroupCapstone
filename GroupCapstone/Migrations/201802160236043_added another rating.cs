namespace GroupCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanotherrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HomeRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HomeRating");
        }
    }
}
