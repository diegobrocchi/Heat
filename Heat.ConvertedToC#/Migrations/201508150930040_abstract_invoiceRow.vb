Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class abstract_invoiceRow
        Inherits DbMigration
    
        Public Overrides Sub Up()
            ' RenameTable(name := "dbo.DescriptiveInvoiceRows", newName := "InvoiceRows")
            DropForeignKey("dbo.InvoiceRows", "Product_ID", "dbo.Products")
            DropIndex("dbo.ProductInvoiceRows", New String() { "Invoice_ID" })
            DropIndex("dbo.ProductInvoiceRows", New String() { "Product_ID" })
            AddColumn("dbo.InvoiceRows", "RowType", Function(c) c.Int())
            AddColumn("dbo.InvoiceRows", "ProductCode", Function(c) c.String())
            AddColumn("dbo.InvoiceRows", "Description", Function(c) c.String())
            AddColumn("dbo.InvoiceRows", "Discriminator", Function(c) c.String(nullable := False, maxLength := 128))
            'AddColumn("dbo.InvoiceRows", "Product_ID", Function(c) c.Int())
            AlterColumn("dbo.InvoiceRows", "RateDiscount1", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AlterColumn("dbo.InvoiceRows", "RateDiscount2", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AlterColumn("dbo.InvoiceRows", "RateDiscount3", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            'DropTable("dbo.InvoiceRows")
            DropTable("dbo.ProductInvoiceRows")
        End Sub
        
        Public Overrides Sub Down()
            CreateTable(
                "dbo.ProductInvoiceRows",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .RowID = c.Int(nullable := False),
                        .ItemOrder = c.Int(nullable := False),
                        .Quantity = c.Double(nullable := False),
                        .UnitPrice = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .VAT_Rate = c.Single(nullable := False),
                        .RateDiscount1 = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .RateDiscount2 = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .RateDiscount3 = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Invoice_ID = c.Int(),
                        .Product_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.InvoiceRows",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .RowID = c.Int(nullable := False),
                        .ItemOrder = c.Int(nullable := False),
                        .Quantity = c.Double(nullable := False),
                        .UnitPrice = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .VAT_Rate = c.Single(nullable := False),
                        .RateDiscount1 = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .RateDiscount2 = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .RateDiscount3 = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Invoice_ID = c.Int(),
                        .Product_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AlterColumn("dbo.InvoiceRows", "RateDiscount3", Function(c) c.Single(nullable := False))
            AlterColumn("dbo.InvoiceRows", "RateDiscount2", Function(c) c.Single(nullable := False))
            AlterColumn("dbo.InvoiceRows", "RateDiscount1", Function(c) c.Single(nullable := False))
            DropColumn("dbo.InvoiceRows", "Product_ID")
            DropColumn("dbo.InvoiceRows", "Discriminator")
            DropColumn("dbo.InvoiceRows", "Description1")
            DropColumn("dbo.InvoiceRows", "ProductCode")
            DropColumn("dbo.InvoiceRows", "RowType")
            CreateIndex("dbo.ProductInvoiceRows", "Product_ID")
            CreateIndex("dbo.ProductInvoiceRows", "Invoice_ID")
            AddForeignKey("dbo.InvoiceRows", "Product_ID", "dbo.Products", "ID")
            RenameTable(name := "dbo.InvoiceRows", newName := "DescriptiveInvoiceRows")
        End Sub
    End Class
End Namespace
