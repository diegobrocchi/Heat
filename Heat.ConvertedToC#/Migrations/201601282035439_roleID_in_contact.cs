namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleID_in_contact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Role_ID", "dbo.PlantRoles");
            DropIndex("dbo.Contacts", new[] { "Role_ID" });
            RenameColumn(table: "dbo.Contacts", name: "Role_ID", newName: "RoleID");
            AlterColumn("dbo.Contacts", "RoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "RoleID");
            AddForeignKey("dbo.Contacts", "RoleID", "dbo.PlantRoles", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "RoleID", "dbo.PlantRoles");
            DropIndex("dbo.Contacts", new[] { "RoleID" });
            AlterColumn("dbo.Contacts", "RoleID", c => c.Int());
            RenameColumn(table: "dbo.Contacts", name: "RoleID", newName: "Role_ID");
            CreateIndex("dbo.Contacts", "Role_ID");
            AddForeignKey("dbo.Contacts", "Role_ID", "dbo.PlantRoles", "ID");
        }
    }
}
