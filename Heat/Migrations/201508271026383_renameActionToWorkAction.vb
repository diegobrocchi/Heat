Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class renameActionToWorkAction
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.Actions", newName := "WorkActions")
        End Sub
        
        Public Overrides Sub Down()
            RenameTable(name := "dbo.WorkActions", newName := "Actions")
        End Sub
    End Class
End Namespace
