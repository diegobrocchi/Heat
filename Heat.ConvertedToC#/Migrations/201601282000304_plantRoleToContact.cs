namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plantRoleToContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Role_ID", c => c.Int());
            CreateIndex("dbo.Contacts", "Role_ID");
            AddForeignKey("dbo.Contacts", "Role_ID", "dbo.PlantRoles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Role_ID", "dbo.PlantRoles");
            DropIndex("dbo.Contacts", new[] { "Role_ID" });
            DropColumn("dbo.Contacts", "Role_ID");
        }
    }
}
