namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableRolIDOnContact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "RoleID", "dbo.PlantRoles");
            DropIndex("dbo.Contacts", new[] { "RoleID" });
            AlterColumn("dbo.Contacts", "RoleID", c => c.Int());
            CreateIndex("dbo.Contacts", "RoleID");
            AddForeignKey("dbo.Contacts", "RoleID", "dbo.PlantRoles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "RoleID", "dbo.PlantRoles");
            DropIndex("dbo.Contacts", new[] { "RoleID" });
            AlterColumn("dbo.Contacts", "RoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "RoleID");
            AddForeignKey("dbo.Contacts", "RoleID", "dbo.PlantRoles", "ID", cascadeDelete: true);
        }
    }
}
