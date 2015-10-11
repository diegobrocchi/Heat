Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class add_BoilerServiceType
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.BoilerHeaters",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .SerialNumber = c.String(),
                        .MinimumPowerKW = c.Single(nullable := False),
                        .MaximumPowerKW = c.Single(nullable := False),
                        .Boiler_ID = c.Int(),
                        .Manifacturer_ID = c.Int(),
                        .Model_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Boilers", Function(t) t.Boiler_ID) _
                .ForeignKey("dbo.Manifacturers", Function(t) t.Manifacturer_ID) _
                .ForeignKey("dbo.ManifacturerModels", Function(t) t.Model_ID) _
                .Index(Function(t) t.Boiler_ID) _
                .Index(Function(t) t.Manifacturer_ID) _
                .Index(Function(t) t.Model_ID)
            
            CreateTable(
                "dbo.Boilers",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .SerialNumber = c.String(),
                        .InstallationDate = c.DateTime(nullable := False),
                        .FirstStartUp = c.DateTime(nullable := False),
                        .Warranty = c.String(),
                        .WarrantyExpiration = c.DateTime(nullable := False),
                        .Manifacturer_ID = c.Int(),
                        .Model_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Manifacturers", Function(t) t.Manifacturer_ID) _
                .ForeignKey("dbo.ManifacturerModels", Function(t) t.Model_ID) _
                .Index(Function(t) t.Manifacturer_ID) _
                .Index(Function(t) t.Model_ID)
            
            CreateTable(
                "dbo.BoilerServices",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Boiler_ID = c.Int(),
                        .Type_ID = c.Int(),
                        .ManifacturerModel_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Boilers", Function(t) t.Boiler_ID) _
                .ForeignKey("dbo.BoilerServiceTypes", Function(t) t.Type_ID) _
                .ForeignKey("dbo.ManifacturerModels", Function(t) t.ManifacturerModel_ID) _
                .Index(Function(t) t.Boiler_ID) _
                .Index(Function(t) t.Type_ID) _
                .Index(Function(t) t.ManifacturerModel_ID)
            
            CreateTable(
                "dbo.BoilerServiceTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Description = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.BoilerHeaters", "Model_ID", "dbo.ManifacturerModels")
            DropForeignKey("dbo.BoilerHeaters", "Manifacturer_ID", "dbo.Manifacturers")
            DropForeignKey("dbo.BoilerHeaters", "Boiler_ID", "dbo.Boilers")
            DropForeignKey("dbo.Boilers", "Model_ID", "dbo.ManifacturerModels")
            DropForeignKey("dbo.BoilerServices", "ManifacturerModel_ID", "dbo.ManifacturerModels")
            DropForeignKey("dbo.BoilerServices", "Type_ID", "dbo.BoilerServiceTypes")
            DropForeignKey("dbo.BoilerServices", "Boiler_ID", "dbo.Boilers")
            DropForeignKey("dbo.Boilers", "Manifacturer_ID", "dbo.Manifacturers")
            DropIndex("dbo.BoilerServices", New String() { "ManifacturerModel_ID" })
            DropIndex("dbo.BoilerServices", New String() { "Type_ID" })
            DropIndex("dbo.BoilerServices", New String() { "Boiler_ID" })
            DropIndex("dbo.Boilers", New String() { "Model_ID" })
            DropIndex("dbo.Boilers", New String() { "Manifacturer_ID" })
            DropIndex("dbo.BoilerHeaters", New String() { "Model_ID" })
            DropIndex("dbo.BoilerHeaters", New String() { "Manifacturer_ID" })
            DropIndex("dbo.BoilerHeaters", New String() { "Boiler_ID" })
            DropTable("dbo.BoilerServiceTypes")
            DropTable("dbo.BoilerServices")
            DropTable("dbo.Boilers")
            DropTable("dbo.BoilerHeaters")
        End Sub
    End Class
End Namespace
