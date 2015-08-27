Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class changeWorkAction
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.WorkActions", "Operation_ID", Function(c) c.Int())
            CreateIndex("dbo.WorkActions", "Operation_ID")
            AddForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations")
            DropIndex("dbo.WorkActions", New String() { "Operation_ID" })
            DropColumn("dbo.WorkActions", "Operation_ID")
        End Sub
    End Class
End Namespace
