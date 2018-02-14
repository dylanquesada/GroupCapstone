namespace GroupCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlongitudeandlatitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Latitude", c => c.String());
            AddColumn("dbo.AspNetUsers", "Longitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Longitude");
            DropColumn("dbo.AspNetUsers", "Latitude");
        }
    }
}
