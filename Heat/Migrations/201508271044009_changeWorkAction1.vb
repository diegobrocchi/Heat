Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class changeWorkAction1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropForeignKey("dbo.WorkActions", "AssignedOperator_ID", "dbo.WorkOperators")
            DropForeignKey("dbo.WorkActions", "Customer_ID", "dbo.Customers")
            DropForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations")
            DropIndex("dbo.WorkActions", New String() { "AssignedOperator_ID" })
            DropIndex("dbo.WorkActions", New String() { "Customer_ID" })
            DropIndex("dbo.WorkActions", New String() { "Operation_ID" })
            RenameColumn(table := "dbo.WorkActions", name := "AssignedOperator_ID", newName := "AssignedOperatorID")
            RenameColumn(table := "dbo.WorkActions", name := "Customer_ID", newName := "CustomerID")
            RenameColumn(table := "dbo.WorkActions", name := "Operation_ID", newName := "OperationID")
            AlterColumn("dbo.WorkActions", "AssignedOperatorID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.WorkActions", "CustomerID", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.WorkActions", "OperationID", Function(c) c.Int(nullable := False))
            CreateIndex("dbo.WorkActions", "CustomerID")
            CreateIndex("dbo.WorkActions", "OperationID")
            CreateIndex("dbo.WorkActions", "AssignedOperatorID")
            AddForeignKey("dbo.WorkActions", "AssignedOperatorID", "dbo.WorkOperators", "ID", cascadeDelete := True)
            AddForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers", "ID", cascadeDelete := True)
            AddForeignKey("dbo.WorkActions", "OperationID", "dbo.Operations", "ID", cascadeDelete := True)
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.WorkActions", "OperationID", "dbo.Operations")
            DropForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers")
            DropForeignKey("dbo.WorkActions", "AssignedOperatorID", "dbo.WorkOperators")
            DropIndex("dbo.WorkActions", New String() { "AssignedOperatorID" })
            DropIndex("dbo.WorkActions", New String() { "OperationID" })
            DropIndex("dbo.WorkActions", New String() { "CustomerID" })
            AlterColumn("dbo.WorkActions", "OperationID", Function(c) c.Int())
            AlterColumn("dbo.WorkActions", "CustomerID", Function(c) c.Int())
            AlterColumn("dbo.WorkActions", "AssignedOperatorID", Function(c) c.Int())
            RenameColumn(table := "dbo.WorkActions", name := "OperationID", newName := "Operation_ID")
            RenameColumn(table := "dbo.WorkActions", name := "CustomerID", newName := "Customer_ID")
            RenameColumn(table := "dbo.WorkActions", name := "AssignedOperatorID", newName := "AssignedOperator_ID")
            CreateIndex("dbo.WorkActions", "Operation_ID")
            CreateIndex("dbo.WorkActions", "Customer_ID")
            CreateIndex("dbo.WorkActions", "AssignedOperator_ID")
            AddForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations", "ID")
            AddForeignKey("dbo.WorkActions", "Customer_ID", "dbo.Customers", "ID")
            AddForeignKey("dbo.WorkActions", "AssignedOperator_ID", "dbo.WorkOperators", "ID")
        End Sub
    End Class
End Namespace
