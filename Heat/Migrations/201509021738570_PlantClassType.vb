Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class PlantClassType
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses")
            DropForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes")
            DropIndex("dbo.Plants", New String() { "PlantClass_ID" })
            DropIndex("dbo.Plants", New String() { "PlantType_ID" })
            RenameColumn(table := "dbo.Plants", name := "PlantClass_ID", newName := "PlantClassID")
            RenameColumn(table := "dbo.Plants", name := "PlantType_ID", newName := "PlantTypeID")
            AlterColumn("dbo.Plants", "PlantClassID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Plants", "PlantTypeID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.Plants", "PlantClassID")
            CreateIndex("dbo.Plants", "PlantTypeID")
            AddForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses", "ID", cascadeDelete := True)
            AddForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes")
            DropForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses")
            DropIndex("dbo.Plants", New String() { "PlantTypeID" })
            DropIndex("dbo.Plants", New String() { "PlantClassID" })
            AlterColumn("dbo.Plants", "PlantTypeID", Function(c) c.Int())
            AlterColumn("dbo.Plants", "PlantClassID", Function(c) c.Int())
            RenameColumn(table := "dbo.Plants", name := "PlantTypeID", newName := "PlantType_ID")
            RenameColumn(table := "dbo.Plants", name := "PlantClassID", newName := "PlantClass_ID")
            CreateIndex("dbo.Plants", "PlantType_ID")
            CreateIndex("dbo.Plants", "PlantClass_ID")
            AddForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes", "ID")
            AddForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses", "ID")
        End Sub
    End Class
End Namespace
