Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class inventory
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.InventoryMovements",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Quantity = c.Double(nullable := False),
                        .ExecDate = c.DateTime(nullable := False),
                        .Note = c.String(),
                        .Product_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Products", Function(t) t.Product_ID) _
                .Index(Function(t) t.Product_ID)
            
            CreateTable(
                "dbo.Products",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .SKU = c.String(),
                        .Description = c.String(),
                        .UnitPrice = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Cost = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .ReorderLevel = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.Customers", "Enabled", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.Addresses", "Phone", Function(c) c.String())
            AddColumn("dbo.Addresses", "CellPhone", Function(c) c.String())
            AddColumn("dbo.Addresses", "Fax", Function(c) c.String())
            AddColumn("dbo.Addresses", "Note", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.InventoryMovements", "Product_ID", "dbo.Products")
            DropIndex("dbo.InventoryMovements", New String() { "Product_ID" })
            DropColumn("dbo.Addresses", "Note")
            DropColumn("dbo.Addresses", "Fax")
            DropColumn("dbo.Addresses", "CellPhone")
            DropColumn("dbo.Addresses", "Phone")
            DropColumn("dbo.Customers", "Enabled")
            DropTable("dbo.Products")
            DropTable("dbo.InventoryMovements")
        End Sub
    End Class
End Namespace
