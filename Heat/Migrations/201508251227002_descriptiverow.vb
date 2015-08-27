Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class descriptiverow
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.InvoiceRows", "RowType")
            DropColumn("dbo.InvoiceRows", "ProductCode")
            'DropColumn("dbo.InvoiceRows", "Description")
        End Sub
        
        Public Overrides Sub Down()
            'AddColumn("dbo.InvoiceRows", "Description", Function(c) c.String())
            AddColumn("dbo.InvoiceRows", "ProductCode", Function(c) c.String())
            AddColumn("dbo.InvoiceRows", "RowType", Function(c) c.Int())
        End Sub
    End Class
End Namespace
