Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class CompanyName
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Customers", "CompanyName", Function(c) c.String(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Customers", "CompanyName", Function(c) c.String())
        End Sub
    End Class
End Namespace
