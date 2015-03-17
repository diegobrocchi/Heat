Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class customername_required
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Customers", "Name", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Customers", "Name", Function(c) c.String())
        End Sub
    End Class
End Namespace
