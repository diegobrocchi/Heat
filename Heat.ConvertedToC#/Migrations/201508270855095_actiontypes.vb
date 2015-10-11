Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class actiontypes
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ActionTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Description = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.Actions", "Type_ID", Function(c) c.Int())
            CreateIndex("dbo.Actions", "Type_ID")
            AddForeignKey("dbo.Actions", "Type_ID", "dbo.ActionTypes", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Actions", "Type_ID", "dbo.ActionTypes")
            DropIndex("dbo.Actions", New String() { "Type_ID" })
            DropColumn("dbo.Actions", "Type_ID")
            DropTable("dbo.ActionTypes")
        End Sub
    End Class
End Namespace
