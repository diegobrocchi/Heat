Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class customer_notes
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Customers", "Note", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Customers", "Note")
        End Sub
    End Class
End Namespace
