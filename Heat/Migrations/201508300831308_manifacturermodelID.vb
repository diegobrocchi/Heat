Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class manifacturermodelID
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.ManifacturerModels", "Manifacturer_ID", "dbo.Manifacturers")
            DropIndex("dbo.ManifacturerModels", New String() { "Manifacturer_ID" })
            RenameColumn(table := "dbo.ManifacturerModels", name := "Manifacturer_ID", newName := "ManifacturerID")
            AlterColumn("dbo.ManifacturerModels", "ManifacturerID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.ManifacturerModels", "ManifacturerID")
            AddForeignKey("dbo.ManifacturerModels", "ManifacturerID", "dbo.Manifacturers", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.ManifacturerModels", "ManifacturerID", "dbo.Manifacturers")
            DropIndex("dbo.ManifacturerModels", New String() { "ManifacturerID" })
            AlterColumn("dbo.ManifacturerModels", "ManifacturerID", Function(c) c.Int())
            RenameColumn(table := "dbo.ManifacturerModels", name := "ManifacturerID", newName := "Manifacturer_ID")
            CreateIndex("dbo.ManifacturerModels", "Manifacturer_ID")
            AddForeignKey("dbo.ManifacturerModels", "Manifacturer_ID", "dbo.Manifacturers", "ID")
        End Sub
    End Class
End Namespace
