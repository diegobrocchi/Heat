Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class invoice_row
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Invoices", "InvoiceDate", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.Invoices", "TaxableAmount", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.Invoices", "TaxRate", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.Invoices", "TaxesAmount", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.Invoices", "TotalAmount", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.Invoices", "SelfBilling", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.Invoices", "IsTaxExempt", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.Invoices", "TaxExemption", Function(c) c.String())
            AddColumn("dbo.InvoiceRows", "VAT_Rate", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.InvoiceRows", "RateDiscount1", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.InvoiceRows", "RateDiscount2", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            AddColumn("dbo.InvoiceRows", "RateDiscount3", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            DropColumn("dbo.Invoices", "Sum")
            DropColumn("dbo.InvoiceRows", "VAT")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.InvoiceRows", "VAT", Function(c) c.Double(nullable := False))
            AddColumn("dbo.Invoices", "Sum", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
            DropColumn("dbo.InvoiceRows", "RateDiscount3")
            DropColumn("dbo.InvoiceRows", "RateDiscount2")
            DropColumn("dbo.InvoiceRows", "RateDiscount1")
            DropColumn("dbo.InvoiceRows", "VAT_Rate")
            DropColumn("dbo.Invoices", "TaxExemption")
            DropColumn("dbo.Invoices", "IsTaxExempt")
            DropColumn("dbo.Invoices", "SelfBilling")
            DropColumn("dbo.Invoices", "TotalAmount")
            DropColumn("dbo.Invoices", "TaxesAmount")
            DropColumn("dbo.Invoices", "TaxRate")
            DropColumn("dbo.Invoices", "TaxableAmount")
            DropColumn("dbo.Invoices", "InvoiceDate")
        End Sub
    End Class
End Namespace
