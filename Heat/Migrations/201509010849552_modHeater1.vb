Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class modHeater1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Heaters", "Heater_ID", "dbo.Heaters")
            DropForeignKey("dbo.Heaters", "HeatTransferFluidID", "dbo.HeatTransferFluids")
            DropIndex("dbo.Heaters", New String() { "HeatTransferFluidID" })
            DropIndex("dbo.Heaters", New String() { "Heater_ID" })
            DropColumn("dbo.Heaters", "HeatTransferFluidID")
            DropColumn("dbo.Heaters", "ThermalEfficiencyPowerMax")
            DropColumn("dbo.Heaters", "Kind")
            DropColumn("dbo.Heaters", "Heater_ID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Heaters", "Heater_ID", Function(c) c.Int())
            AddColumn("dbo.Heaters", "Kind", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Heaters", "ThermalEfficiencyPowerMax", Function(c) c.Single(nullable := False))
            AddColumn("dbo.Heaters", "HeatTransferFluidID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.Heaters", "Heater_ID")
            CreateIndex("dbo.Heaters", "HeatTransferFluidID")
            AddForeignKey("dbo.Heaters", "HeatTransferFluidID", "dbo.HeatTransferFluids", "ID", cascadeDelete := True)
            AddForeignKey("dbo.Heaters", "Heater_ID", "dbo.Heaters", "ID")
        End Sub
    End Class
End Namespace
