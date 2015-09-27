Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class rename_filenameMedium
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Media", "OriginalFilename", Function(c) c.String())
            DropColumn("dbo.Media", "FileName")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Media", "FileName", Function(c) c.String())
            DropColumn("dbo.Media", "OriginalFilename")
        End Sub
    End Class
End Namespace
