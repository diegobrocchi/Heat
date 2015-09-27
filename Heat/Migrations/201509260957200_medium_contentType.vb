Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class medium_contentType
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Media", "ContentType", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Media", "ContentType")
        End Sub
    End Class
End Namespace
