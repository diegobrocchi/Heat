Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class heaterlist
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Heaters",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .SerialNumber = c.String(),
                        .MinimumPowerKW = c.Single(nullable := False),
                        .MaximumPowerKW = c.Single(nullable := False),
                        .CertificationReference = c.String(),
                        .Manifacturer_ID = c.Int(),
                        .Model_ID = c.Int(),
                        .ThermalUnit_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Manifacturers", Function(t) t.Manifacturer_ID) _
                .ForeignKey("dbo.ManifacturerModels", Function(t) t.Model_ID) _
                .ForeignKey("dbo.ThermalUnits", Function(t) t.ThermalUnit_ID) _
                .Index(Function(t) t.Manifacturer_ID) _
                .Index(Function(t) t.Model_ID) _
                .Index(Function(t) t.ThermalUnit_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Heaters", "ThermalUnit_ID", "dbo.ThermalUnits")
            DropForeignKey("dbo.Heaters", "Model_ID", "dbo.ManifacturerModels")
            DropForeignKey("dbo.Heaters", "Manifacturer_ID", "dbo.Manifacturers")
            DropIndex("dbo.Heaters", New String() { "ThermalUnit_ID" })
            DropIndex("dbo.Heaters", New String() { "Model_ID" })
            DropIndex("dbo.Heaters", New String() { "Manifacturer_ID" })
            DropTable("dbo.Heaters")
        End Sub
    End Class
End Namespace
