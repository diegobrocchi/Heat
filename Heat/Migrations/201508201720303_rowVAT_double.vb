Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class rowVAT_double
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.InvoiceRows", "VAT_Rate", Function(c) c.Double(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.InvoiceRows", "VAT_Rate", Function(c) c.Single(nullable := False))
        End Sub
    End Class
End Namespace
