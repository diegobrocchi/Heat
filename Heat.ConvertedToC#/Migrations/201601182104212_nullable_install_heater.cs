namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_install_heater : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Heaters", "InstallationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Heaters", "InstallationDate", c => c.DateTime(nullable: false));
        }
    }
}
