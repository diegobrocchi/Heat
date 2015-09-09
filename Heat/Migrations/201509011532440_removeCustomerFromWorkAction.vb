Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removeCustomerFromWorkAction
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers")
            DropIndex("dbo.WorkActions", New String() { "CustomerID" })
            DropColumn("dbo.WorkActions", "CustomerID")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.WorkActions", "CustomerID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.WorkActions", "CustomerID")
            AddForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers", "ID", cascadeDelete := True)
        End Sub
    End Class
End Namespace
