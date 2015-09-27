Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class plant_medium
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Media", "Plant_ID", Function(c) c.Int())
            CreateIndex("dbo.Media", "Plant_ID")
            AddForeignKey("dbo.Media", "Plant_ID", "dbo.Plants", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Media", "Plant_ID", "dbo.Plants")
            DropIndex("dbo.Media", New String() { "Plant_ID" })
            DropColumn("dbo.Media", "Plant_ID")
        End Sub
    End Class
End Namespace
