namespace Heat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableInstallationDateInThermalUnit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ThermalUnits", "InstallationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ThermalUnits", "InstallationDate", c => c.DateTime(nullable: false));
        }
    }
}
