Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class uploadFIlename_medium
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Media", "UploadFilename", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Media", "UploadFilename")
        End Sub
    End Class
End Namespace
