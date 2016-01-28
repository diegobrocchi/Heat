namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plantRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlantRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlantRoles");
        }
    }
}
