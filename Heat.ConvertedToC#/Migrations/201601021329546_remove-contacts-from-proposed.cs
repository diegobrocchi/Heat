namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removecontactsfromproposed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "ProposedOutBoundCall_ID", "dbo.ProposedOutBoundCalls");
            DropIndex("dbo.Contacts", new[] { "ProposedOutBoundCall_ID" });
            DropColumn("dbo.Contacts", "ProposedOutBoundCall_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ProposedOutBoundCall_ID", c => c.Int());
            CreateIndex("dbo.Contacts", "ProposedOutBoundCall_ID");
            AddForeignKey("dbo.Contacts", "ProposedOutBoundCall_ID", "dbo.ProposedOutBoundCalls", "ID");
        }
    }
}
