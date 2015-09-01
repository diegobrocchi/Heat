Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removeBoiler
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.BoilerHeaters", "Boiler_ID", "dbo.Boilers")
            DropForeignKey("dbo.BoilerHeaters", "Manifacturer_ID", "dbo.Manifacturers")
            DropForeignKey("dbo.BoilerHeaters", "Model_ID", "dbo.ManifacturerModels")
            DropIndex("dbo.BoilerHeaters", New String() { "Boiler_ID" })
            DropIndex("dbo.BoilerHeaters", New String() { "Manifacturer_ID" })
            DropIndex("dbo.BoilerHeaters", New String() { "Model_ID" })
            DropTable("dbo.BoilerHeaters")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.BoilerHeaters",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .SerialNumber = c.String(),
                        .MinimumPowerKW = c.Single(nullable := False),
                        .MaximumPowerKW = c.Single(nullable := False),
                        .CertificationReference = c.String(),
                        .Boiler_ID = c.Int(),
                        .Manifacturer_ID = c.Int(),
                        .Model_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateIndex("dbo.BoilerHeaters", "Model_ID")
            CreateIndex("dbo.BoilerHeaters", "Manifacturer_ID")
            CreateIndex("dbo.BoilerHeaters", "Boiler_ID")
            AddForeignKey("dbo.BoilerHeaters", "Model_ID", "dbo.ManifacturerModels", "ID")
            AddForeignKey("dbo.BoilerHeaters", "Manifacturer_ID", "dbo.Manifacturers", "ID")
            AddForeignKey("dbo.BoilerHeaters", "Boiler_ID", "dbo.Boilers", "ID")
        End Sub
    End Class
End Namespace
