Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class seller
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.CausalWarehouses", "TypeID", "dbo.CausalWarehouseGroups")
            DropIndex("dbo.CausalWarehouses", New String() { "TypeID" })
            CreateTable(
                "dbo.Sellers",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .FiscalCode = c.String(),
                        .IBAN = c.String(),
                        .Logo = c.String(),
                        .Name = c.String(),
                        .Vat_Number = c.String(),
                        .Address_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Addresses", Function(t) t.Address_ID) _
                .Index(Function(t) t.Address_ID)
            
            AddColumn("dbo.CausalWarehouses", "Type", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Invoices", "InsertedNumber_SerialInteger", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Invoices", "InsertedNumber_SerialString", Function(c) c.String())
            AddColumn("dbo.Invoices", "InsertedNumber_IsValid", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.Invoices", "InsertedNumber_InvalidError", Function(c) c.String())
            AddColumn("dbo.Invoices", "ConfirmedNumber_SerialInteger", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Invoices", "ConfirmedNumber_SerialString", Function(c) c.String())
            AddColumn("dbo.Invoices", "ConfirmedNumber_IsValid", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.Invoices", "ConfirmedNumber_InvalidError", Function(c) c.String())
            AddColumn("dbo.Invoices", "State", Function(c) c.Int(nullable := False))
            AddColumn("dbo.WarehouseMovements", "CausalWarehouseID", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Warehouses", "CheckStockBefore", Function(c) c.Boolean(nullable := False))
            CreateIndex("dbo.WarehouseMovements", "CausalWarehouseID")
            AddForeignKey("dbo.WarehouseMovements", "CausalWarehouseID", "dbo.CausalWarehouses", "ID", cascadeDelete:=False)
            DropColumn("dbo.Invoices", "DocNumber")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Invoices", "DocNumber", Function(c) c.Int(nullable := False))
            DropForeignKey("dbo.WarehouseMovements", "CausalWarehouseID", "dbo.CausalWarehouses")
            DropForeignKey("dbo.Sellers", "Address_ID", "dbo.Addresses")
            DropIndex("dbo.WarehouseMovements", New String() { "CausalWarehouseID" })
            DropIndex("dbo.Sellers", New String() { "Address_ID" })
            DropColumn("dbo.Warehouses", "CheckStockBefore")
            DropColumn("dbo.WarehouseMovements", "CausalWarehouseID")
            DropColumn("dbo.Invoices", "State")
            DropColumn("dbo.Invoices", "ConfirmedNumber_InvalidError")
            DropColumn("dbo.Invoices", "ConfirmedNumber_IsValid")
            DropColumn("dbo.Invoices", "ConfirmedNumber_SerialString")
            DropColumn("dbo.Invoices", "ConfirmedNumber_SerialInteger")
            DropColumn("dbo.Invoices", "InsertedNumber_InvalidError")
            DropColumn("dbo.Invoices", "InsertedNumber_IsValid")
            DropColumn("dbo.Invoices", "InsertedNumber_SerialString")
            DropColumn("dbo.Invoices", "InsertedNumber_SerialInteger")
            DropColumn("dbo.CausalWarehouses", "Type")
            DropTable("dbo.Sellers")
            CreateIndex("dbo.CausalWarehouses", "TypeID")
            AddForeignKey("dbo.CausalWarehouses", "TypeID", "dbo.CausalWarehouseGroups", "ID", cascadeDelete := True)
        End Sub
    End Class
End Namespace
