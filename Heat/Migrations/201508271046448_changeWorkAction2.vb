Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class changeWorkAction2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.WorkActions", "Type_ID", "dbo.ActionTypes")
            DropIndex("dbo.WorkActions", New String() { "Type_ID" })
            RenameColumn(table := "dbo.WorkActions", name := "Type_ID", newName := "TypeID")
            AlterColumn("dbo.WorkActions", "TypeID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.WorkActions", "TypeID")
            AddForeignKey("dbo.WorkActions", "TypeID", "dbo.ActionTypes", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.WorkActions", "TypeID", "dbo.ActionTypes")
            DropIndex("dbo.WorkActions", New String() { "TypeID" })
            AlterColumn("dbo.WorkActions", "TypeID", Function(c) c.Int())
            RenameColumn(table := "dbo.WorkActions", name := "TypeID", newName := "Type_ID")
            CreateIndex("dbo.WorkActions", "Type_ID")
            AddForeignKey("dbo.WorkActions", "Type_ID", "dbo.ActionTypes", "ID")
        End Sub
    End Class
End Namespace
