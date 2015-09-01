Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class modHeater
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Heaters", "InstallationDate", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.Heaters", "Type", Function(c) c.String())
            AddColumn("dbo.Heaters", "FuelID", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Heaters", "NominalThermalPowerMax", Function(c) c.Single(nullable := False))
            AddColumn("dbo.Heaters", "DismissDate", Function(c) c.DateTime())
            AddColumn("dbo.Heaters", "HeatTransferFluidID", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Heaters", "ThermalEfficiencyPowerMax", Function(c) c.Single(nullable := False))
            AddColumn("dbo.Heaters", "Kind", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Heaters", "Heater_ID", Function(c) c.Int())
            CreateIndex("dbo.Heaters", "FuelID")
            CreateIndex("dbo.Heaters", "HeatTransferFluidID")
            CreateIndex("dbo.Heaters", "Heater_ID")
            AddForeignKey("dbo.Heaters", "FuelID", "dbo.Fuels", "ID", cascadeDelete := True)
            AddForeignKey("dbo.Heaters", "Heater_ID", "dbo.Heaters", "ID")
            AddForeignKey("dbo.Heaters", "HeatTransferFluidID", "dbo.HeatTransferFluids", "ID", cascadeDelete := True)
            DropColumn("dbo.Heaters", "CertificationReference")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Heaters", "CertificationReference", Function(c) c.String())
            DropForeignKey("dbo.Heaters", "HeatTransferFluidID", "dbo.HeatTransferFluids")
            DropForeignKey("dbo.Heaters", "Heater_ID", "dbo.Heaters")
            DropForeignKey("dbo.Heaters", "FuelID", "dbo.Fuels")
            DropIndex("dbo.Heaters", New String() { "Heater_ID" })
            DropIndex("dbo.Heaters", New String() { "HeatTransferFluidID" })
            DropIndex("dbo.Heaters", New String() { "FuelID" })
            DropColumn("dbo.Heaters", "Heater_ID")
            DropColumn("dbo.Heaters", "Kind")
            DropColumn("dbo.Heaters", "ThermalEfficiencyPowerMax")
            DropColumn("dbo.Heaters", "HeatTransferFluidID")
            DropColumn("dbo.Heaters", "DismissDate")
            DropColumn("dbo.Heaters", "NominalThermalPowerMax")
            DropColumn("dbo.Heaters", "FuelID")
            DropColumn("dbo.Heaters", "Type")
            DropColumn("dbo.Heaters", "InstallationDate")
        End Sub
    End Class
End Namespace
