Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class plantidToPlantservice
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.PlantServices", "PlantID", Function(c) c.Int(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.PlantServices", "PlantID")
        End Sub
    End Class
End Namespace
