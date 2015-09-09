Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class distinctCodePlant
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Plants", "PlantDistinctCode", Function(c) c.String())
            DropColumn("dbo.Plants", "PlantDistictCode")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Plants", "PlantDistictCode", Function(c) c.String())
            DropColumn("dbo.Plants", "PlantDistinctCode")
        End Sub
    End Class
End Namespace
