Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removeTelephoneFromPlant
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.Plants", "PlantTelephone1")
            DropColumn("dbo.Plants", "PlantTelephone2")
            DropColumn("dbo.Plants", "PlantTelephone3")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Plants", "PlantTelephone3", Function(c) c.String())
            AddColumn("dbo.Plants", "PlantTelephone2", Function(c) c.String())
            AddColumn("dbo.Plants", "PlantTelephone1", Function(c) c.String())
        End Sub
    End Class
End Namespace
