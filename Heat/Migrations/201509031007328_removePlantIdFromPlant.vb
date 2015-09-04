Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removePlantIdFromPlant
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses")
            DropForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes")
            DropIndex("dbo.Plants", New String() { "PlantClassID" })
            DropIndex("dbo.Plants", New String() { "PlantTypeID" })
            RenameColumn(table := "dbo.Plants", name := "PlantClassID", newName := "PlantClass_ID")
            RenameColumn(table := "dbo.Plants", name := "PlantTypeID", newName := "PlantType_ID")
            AlterColumn("dbo.Plants", "PlantClass_ID", Function(c) c.Int())
            AlterColumn("dbo.Plants", "PlantType_ID", Function(c) c.Int())
            CreateIndex("dbo.Plants", "PlantClass_ID")
            CreateIndex("dbo.Plants", "PlantType_ID")
            AddForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses", "ID")
            AddForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes")
            DropForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses")
            DropIndex("dbo.Plants", New String() { "PlantType_ID" })
            DropIndex("dbo.Plants", New String() { "PlantClass_ID" })
            AlterColumn("dbo.Plants", "PlantType_ID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Plants", "PlantClass_ID", Function(c) c.Int(nullable := False))
            RenameColumn(table := "dbo.Plants", name := "PlantType_ID", newName := "PlantTypeID")
            RenameColumn(table := "dbo.Plants", name := "PlantClass_ID", newName := "PlantClassID")
            CreateIndex("dbo.Plants", "PlantTypeID")
            CreateIndex("dbo.Plants", "PlantClassID")
            AddForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes", "ID", cascadeDelete := True)
            AddForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses", "ID", cascadeDelete := True)
        End Sub
    End Class
End Namespace
