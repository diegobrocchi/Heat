namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposedCallsGenerations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProposedCallsGenerations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GenerationDate = c.DateTime(nullable: false),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ProposedOutBoundCalls", "ProposedCallsGeneration_ID", c => c.Int());
            CreateIndex("dbo.ProposedOutBoundCalls", "ProposedCallsGeneration_ID");
            AddForeignKey("dbo.ProposedOutBoundCalls", "ProposedCallsGeneration_ID", "dbo.ProposedCallsGenerations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProposedOutBoundCalls", "ProposedCallsGeneration_ID", "dbo.ProposedCallsGenerations");
            DropIndex("dbo.ProposedOutBoundCalls", new[] { "ProposedCallsGeneration_ID" });
            DropColumn("dbo.ProposedOutBoundCalls", "ProposedCallsGeneration_ID");
            DropTable("dbo.ProposedCallsGenerations");
        }
    }
}
