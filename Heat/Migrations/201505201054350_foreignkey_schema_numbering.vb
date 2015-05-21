Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class foreignkey_schema_numbering
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.Numberings", "FinalSerialSchema_ID", "dbo.SerialSchemes")
            DropForeignKey("dbo.Numberings", "TempSerialSchema_ID", "dbo.SerialSchemes")
            DropIndex("dbo.Numberings", New String() { "FinalSerialSchema_ID" })
            DropIndex("dbo.Numberings", New String() { "TempSerialSchema_ID" })
            RenameColumn(table := "dbo.Numberings", name := "FinalSerialSchema_ID", newName := "FinalSerialSchemaID")
            RenameColumn(table := "dbo.Numberings", name := "TempSerialSchema_ID", newName := "TempSerialSchemaID")
            AlterColumn("dbo.Numberings", "FinalSerialSchemaID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Numberings", "TempSerialSchemaID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.Numberings", "TempSerialSchemaID")
            CreateIndex("dbo.Numberings", "FinalSerialSchemaID")
            AddForeignKey("dbo.Numberings", "FinalSerialSchemaID", "dbo.SerialSchemes", "ID", cascadeDelete:=False)
            AddForeignKey("dbo.Numberings", "TempSerialSchemaID", "dbo.SerialSchemes", "ID", cascadeDelete:=False)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Numberings", "TempSerialSchemaID", "dbo.SerialSchemes")
            DropForeignKey("dbo.Numberings", "FinalSerialSchemaID", "dbo.SerialSchemes")
            DropIndex("dbo.Numberings", New String() { "FinalSerialSchemaID" })
            DropIndex("dbo.Numberings", New String() { "TempSerialSchemaID" })
            AlterColumn("dbo.Numberings", "TempSerialSchemaID", Function(c) c.Int())
            AlterColumn("dbo.Numberings", "FinalSerialSchemaID", Function(c) c.Int())
            RenameColumn(table := "dbo.Numberings", name := "TempSerialSchemaID", newName := "TempSerialSchema_ID")
            RenameColumn(table := "dbo.Numberings", name := "FinalSerialSchemaID", newName := "FinalSerialSchema_ID")
            CreateIndex("dbo.Numberings", "TempSerialSchema_ID")
            CreateIndex("dbo.Numberings", "FinalSerialSchema_ID")
            AddForeignKey("dbo.Numberings", "TempSerialSchema_ID", "dbo.SerialSchemes", "ID")
            AddForeignKey("dbo.Numberings", "FinalSerialSchema_ID", "dbo.SerialSchemes", "ID")
        End Sub
    End Class
End Namespace
