Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addContactsTOPlant
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Contacts", "Plant_ID", Function(c) c.Int())
            CreateIndex("dbo.Contacts", "Plant_ID")
            AddForeignKey("dbo.Contacts", "Plant_ID", "dbo.Plants", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Contacts", "Plant_ID", "dbo.Plants")
            DropIndex("dbo.Contacts", New String() { "Plant_ID" })
            DropColumn("dbo.Contacts", "Plant_ID")
        End Sub
    End Class
End Namespace
