Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ThermalUnit
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.ThermalUnits", "Fuel_ID", "dbo.Fuels")
            DropForeignKey("dbo.ThermalUnits", "HeatTransferFluid_ID", "dbo.HeatTransferFluids")
            DropForeignKey("dbo.ThermalUnits", "Manifacturer_ID", "dbo.Manifacturers")
            DropForeignKey("dbo.ThermalUnits", "Model_ID", "dbo.ManifacturerModels")
            DropIndex("dbo.ThermalUnits", New String() { "Fuel_ID" })
            DropIndex("dbo.ThermalUnits", New String() { "HeatTransferFluid_ID" })
            DropIndex("dbo.ThermalUnits", New String() { "Manifacturer_ID" })
            DropIndex("dbo.ThermalUnits", New String() { "Model_ID" })
            RenameColumn(table := "dbo.ThermalUnits", name := "Fuel_ID", newName := "FuelID")
            RenameColumn(table := "dbo.ThermalUnits", name := "HeatTransferFluid_ID", newName := "HeatTransferFluidID")
            RenameColumn(table := "dbo.ThermalUnits", name := "Manifacturer_ID", newName := "ManifacturerId")
            RenameColumn(table := "dbo.ThermalUnits", name := "Model_ID", newName := "ModelID")
            AlterColumn("dbo.ThermalUnits", "FuelID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.ThermalUnits", "HeatTransferFluidID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.ThermalUnits", "ManifacturerId", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.ThermalUnits", "ModelID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.ThermalUnits", "ManifacturerId")
            CreateIndex("dbo.ThermalUnits", "ModelID")
            CreateIndex("dbo.ThermalUnits", "FuelID")
            CreateIndex("dbo.ThermalUnits", "HeatTransferFluidID")
            AddForeignKey("dbo.ThermalUnits", "FuelID", "dbo.Fuels", "ID", cascadeDelete := True)
            AddForeignKey("dbo.ThermalUnits", "HeatTransferFluidID", "dbo.HeatTransferFluids", "ID", cascadeDelete := True)
            AddForeignKey("dbo.ThermalUnits", "ManifacturerId", "dbo.Manifacturers", "ID", cascadeDelete := True)
            AddForeignKey("dbo.ThermalUnits", "ModelID", "dbo.ManifacturerModels", "ID", cascadeDelete:=False)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.ThermalUnits", "ModelID", "dbo.ManifacturerModels")
            DropForeignKey("dbo.ThermalUnits", "ManifacturerId", "dbo.Manifacturers")
            DropForeignKey("dbo.ThermalUnits", "HeatTransferFluidID", "dbo.HeatTransferFluids")
            DropForeignKey("dbo.ThermalUnits", "FuelID", "dbo.Fuels")
            DropIndex("dbo.ThermalUnits", New String() { "HeatTransferFluidID" })
            DropIndex("dbo.ThermalUnits", New String() { "FuelID" })
            DropIndex("dbo.ThermalUnits", New String() { "ModelID" })
            DropIndex("dbo.ThermalUnits", New String() { "ManifacturerId" })
            AlterColumn("dbo.ThermalUnits", "ModelID", Function(c) c.Int())
            AlterColumn("dbo.ThermalUnits", "ManifacturerId", Function(c) c.Int())
            AlterColumn("dbo.ThermalUnits", "HeatTransferFluidID", Function(c) c.Int())
            AlterColumn("dbo.ThermalUnits", "FuelID", Function(c) c.Int())
            RenameColumn(table := "dbo.ThermalUnits", name := "ModelID", newName := "Model_ID")
            RenameColumn(table := "dbo.ThermalUnits", name := "ManifacturerId", newName := "Manifacturer_ID")
            RenameColumn(table := "dbo.ThermalUnits", name := "HeatTransferFluidID", newName := "HeatTransferFluid_ID")
            RenameColumn(table := "dbo.ThermalUnits", name := "FuelID", newName := "Fuel_ID")
            CreateIndex("dbo.ThermalUnits", "Model_ID")
            CreateIndex("dbo.ThermalUnits", "Manifacturer_ID")
            CreateIndex("dbo.ThermalUnits", "HeatTransferFluid_ID")
            CreateIndex("dbo.ThermalUnits", "Fuel_ID")
            AddForeignKey("dbo.ThermalUnits", "Model_ID", "dbo.ManifacturerModels", "ID")
            AddForeignKey("dbo.ThermalUnits", "Manifacturer_ID", "dbo.Manifacturers", "ID")
            AddForeignKey("dbo.ThermalUnits", "HeatTransferFluid_ID", "dbo.HeatTransferFluids", "ID")
            AddForeignKey("dbo.ThermalUnits", "Fuel_ID", "dbo.Fuels", "ID")
        End Sub
    End Class
End Namespace
