Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class PlantService_key
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.PlantServices", "ID", "dbo.Plants")
            DropIndex("dbo.PlantServices", New String() { "ID" })
            DropPrimaryKey("dbo.PlantServices")
            AddColumn("dbo.Plants", "Service_ID", Function(c) c.Int())
            AlterColumn("dbo.PlantServices", "ID", Function(c) c.Int(nullable := False, identity := True))
            AddPrimaryKey("dbo.PlantServices", "ID")
            CreateIndex("dbo.Plants", "Service_ID")
            AddForeignKey("dbo.Plants", "Service_ID", "dbo.PlantServices", "ID")
            DropColumn("dbo.PlantServices", "PlantID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.PlantServices", "PlantID", Function(c) c.Int(nullable := False))
            DropForeignKey("dbo.Plants", "Service_ID", "dbo.PlantServices")
            DropIndex("dbo.Plants", New String() { "Service_ID" })
            DropPrimaryKey("dbo.PlantServices")
            AlterColumn("dbo.PlantServices", "ID", Function(c) c.Int(nullable := False))
            DropColumn("dbo.Plants", "Service_ID")
            AddPrimaryKey("dbo.PlantServices", "ID")
            CreateIndex("dbo.PlantServices", "ID")
            AddForeignKey("dbo.PlantServices", "ID", "dbo.Plants", "ID")
        End Sub
    End Class
End Namespace
