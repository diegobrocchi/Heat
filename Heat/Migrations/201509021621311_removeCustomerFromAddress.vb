Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removeCustomerFromAddress
        Inherits DbMigration
    
        Public Overrides Sub Up()
            RenameColumn(table := "dbo.Addresses", name := "CustomerID", newName := "Customer_ID")
            RenameIndex(table := "dbo.Addresses", name := "IX_CustomerID", newName := "IX_Customer_ID")
        End Sub
        
        Public Overrides Sub Down()
            RenameIndex(table := "dbo.Addresses", name := "IX_Customer_ID", newName := "IX_CustomerID")
            RenameColumn(table := "dbo.Addresses", name := "Customer_ID", newName := "CustomerID")
        End Sub
    End Class
End Namespace
