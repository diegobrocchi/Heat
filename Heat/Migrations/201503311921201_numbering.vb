Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class numbering
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameTable(name := "dbo.Numerators", newName := "Numberings")
        End Sub
        
        Public Overrides Sub Down()
            RenameTable(name := "dbo.Numberings", newName := "Numerators")
        End Sub
    End Class
End Namespace
