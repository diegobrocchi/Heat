Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class plant_toWorkAction
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.WorkActions", "PlantID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.WorkActions", "PlantID")
            AddForeignKey("dbo.WorkActions", "PlantID", "dbo.Plants", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.WorkActions", "PlantID", "dbo.Plants")
            DropIndex("dbo.WorkActions", New String() { "PlantID" })
            DropColumn("dbo.WorkActions", "PlantID")
        End Sub
    End Class
End Namespace
