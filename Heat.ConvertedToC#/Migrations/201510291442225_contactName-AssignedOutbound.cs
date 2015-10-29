namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactNameAssignedOutbound : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignedOutboundCalls", "ContactName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignedOutboundCalls", "ContactName");
        }
    }
}
