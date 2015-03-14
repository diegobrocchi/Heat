Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class rename_VAT
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Customers", "VAT_Number", Function(c) c.String())
            DropColumn("dbo.Customers", "VAT")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Customers", "VAT", Function(c) c.String())
            DropColumn("dbo.Customers", "VAT_Number")
        End Sub
    End Class
End Namespace
