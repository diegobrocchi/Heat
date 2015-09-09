Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class nullableLastServiceDateInPlantService
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.PlantServices", "PreviousServiceDate", Function(c) c.DateTime())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.PlantServices", "PreviousServiceDate", Function(c) c.DateTime(nullable := False))
        End Sub
    End Class
End Namespace
