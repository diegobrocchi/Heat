Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class invoice
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.InvoiceRows",
                Function(c) New With
                    {
                        .ID = c.Int(nullable:=False, identity:=True),
                        .RowID = c.Int(nullable:=False),
                        .ItemOrder = c.Int(nullable:=False),
                        .Quantity = c.Double(nullable:=False),
                        .UnitPrice = c.Decimal(nullable:=False, precision:=18, scale:=2),
                        .VAT = c.Double(nullable:=False),
                        .Invoice_ID = c.Int(),
                        .Product_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Invoices", Function(t) t.Invoice_ID, True) _
                .ForeignKey("dbo.Products", Function(t) t.Product_ID) _
                .Index(Function(t) t.Invoice_ID) _
                .Index(Function(t) t.Product_ID)
            
            CreateTable(
                "dbo.Payments",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Code = c.String(),
                        .Description = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.Invoices", "Sum", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.Invoices", "Customer_ID", Function(c) c.Int())
            AddColumn("dbo.Invoices", "Payment_ID", Function(c) c.Int())
            CreateIndex("dbo.Invoices", "Customer_ID")
            CreateIndex("dbo.Invoices", "Payment_ID")
            'CreateIndex("dbo.Invoices", " AddForeignKeyPayment_ID")
            AddForeignKey("dbo.Invoices", "Customer_ID", "dbo.Customers", "ID")
            AddForeignKey("dbo.Invoices", "Payment_ID", "dbo.Payments", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Invoices", "Payment_ID", "dbo.Payments")
            DropForeignKey("dbo.InvoiceRows", "Product_ID", "dbo.Products")
            DropForeignKey("dbo.InvoiceRows", "Invoice_ID", "dbo.Invoices")
            DropForeignKey("dbo.Invoices", "Customer_ID", "dbo.Customers")
            DropIndex("dbo.InvoiceRows", New String() { "Product_ID" })
            DropIndex("dbo.InvoiceRows", New String() { "Invoice_ID" })
            DropIndex("dbo.Invoices", New String() { "Payment_ID" })
            DropIndex("dbo.Invoices", New String() { "Customer_ID" })
            DropColumn("dbo.Invoices", "Payment_ID")
            DropColumn("dbo.Invoices", "Customer_ID")
            DropColumn("dbo.Invoices", "Sum")
            DropTable("dbo.Payments")
            DropTable("dbo.InvoiceRows")
        End Sub
    End Class
End Namespace
