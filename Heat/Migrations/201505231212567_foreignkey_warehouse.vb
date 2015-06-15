Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class foreignkey_warehouse
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.WarehouseMovements", "Destination_ID", "dbo.Warehouses")
            DropForeignKey("dbo.WarehouseMovements", "Product_ID", "dbo.Products")
            DropForeignKey("dbo.WarehouseMovements", "Source_ID", "dbo.Warehouses")
            DropIndex("dbo.WarehouseMovements", New String() { "Destination_ID" })
            DropIndex("dbo.WarehouseMovements", New String() { "Product_ID" })
            DropIndex("dbo.WarehouseMovements", New String() { "Source_ID" })
            RenameColumn(table := "dbo.WarehouseMovements", name := "Destination_ID", newName := "DestinationID")
            RenameColumn(table := "dbo.WarehouseMovements", name := "Product_ID", newName := "ProductID")
            RenameColumn(table := "dbo.WarehouseMovements", name := "Source_ID", newName := "SourceID")
            AlterColumn("dbo.WarehouseMovements", "DestinationID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.WarehouseMovements", "ProductID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.WarehouseMovements", "SourceID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.WarehouseMovements", "ProductID")
            CreateIndex("dbo.WarehouseMovements", "SourceID")
            CreateIndex("dbo.WarehouseMovements", "DestinationID")
            AddForeignKey("dbo.WarehouseMovements", "DestinationID", "dbo.Warehouses", "ID", cascadeDelete:=False)
            AddForeignKey("dbo.WarehouseMovements", "ProductID", "dbo.Products", "ID", cascadeDelete:=False)
            AddForeignKey("dbo.WarehouseMovements", "SourceID", "dbo.Warehouses", "ID", cascadeDelete:=False)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.WarehouseMovements", "SourceID", "dbo.Warehouses")
            DropForeignKey("dbo.WarehouseMovements", "ProductID", "dbo.Products")
            DropForeignKey("dbo.WarehouseMovements", "DestinationID", "dbo.Warehouses")
            DropIndex("dbo.WarehouseMovements", New String() { "DestinationID" })
            DropIndex("dbo.WarehouseMovements", New String() { "SourceID" })
            DropIndex("dbo.WarehouseMovements", New String() { "ProductID" })
            AlterColumn("dbo.WarehouseMovements", "SourceID", Function(c) c.Int())
            AlterColumn("dbo.WarehouseMovements", "ProductID", Function(c) c.Int())
            AlterColumn("dbo.WarehouseMovements", "DestinationID", Function(c) c.Int())
            RenameColumn(table := "dbo.WarehouseMovements", name := "SourceID", newName := "Source_ID")
            RenameColumn(table := "dbo.WarehouseMovements", name := "ProductID", newName := "Product_ID")
            RenameColumn(table := "dbo.WarehouseMovements", name := "DestinationID", newName := "Destination_ID")
            CreateIndex("dbo.WarehouseMovements", "Source_ID")
            CreateIndex("dbo.WarehouseMovements", "Product_ID")
            CreateIndex("dbo.WarehouseMovements", "Destination_ID")
            AddForeignKey("dbo.WarehouseMovements", "Source_ID", "dbo.Warehouses", "ID")
            AddForeignKey("dbo.WarehouseMovements", "Product_ID", "dbo.Products", "ID")
            AddForeignKey("dbo.WarehouseMovements", "Destination_ID", "dbo.Warehouses", "ID")
        End Sub
    End Class
End Namespace
