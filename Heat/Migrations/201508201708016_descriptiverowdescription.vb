Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class descriptiverowdescription
        Inherits DbMigration
    
        Public Overrides Sub Up()
            'DropColumn("dbo.InvoiceRows", "Description")
            'RenameColumn(table := "dbo.InvoiceRows", name := "Description1", newName := "Description")
            AddColumn("dbo.InvoiceRows", "RowDescription", Function(c) c.String())
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.InvoiceRows", "RowDescription")
            RenameColumn(table := "dbo.InvoiceRows", name := "Description", newName := "Description1")
            AddColumn("dbo.InvoiceRows", "Description", Function(c) c.String())
        End Sub
    End Class
End Namespace
