namespace GroupCapstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Shovelee", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Shovelee");
        }
    }
}
