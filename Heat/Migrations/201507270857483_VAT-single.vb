Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class VATsingle
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.InvoiceRows", "VAT_Rate", Function(c) c.Single(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.InvoiceRows", "VAT_Rate", Function(c) c.Decimal(nullable := False, precision := 18, scale := 2))
        End Sub
    End Class
End Namespace
