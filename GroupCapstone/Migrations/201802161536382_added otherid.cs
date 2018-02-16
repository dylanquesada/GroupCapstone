namespace GroupCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedotherid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "OtherId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "OtherId");
        }
    }
}
