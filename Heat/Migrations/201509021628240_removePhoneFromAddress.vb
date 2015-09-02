Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removePhoneFromAddress
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.Addresses", "Phone")
            DropColumn("dbo.Addresses", "CellPhone")
            DropColumn("dbo.Addresses", "Fax")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Addresses", "Fax", Function(c) c.String())
            AddColumn("dbo.Addresses", "CellPhone", Function(c) c.String())
            AddColumn("dbo.Addresses", "Phone", Function(c) c.String())
        End Sub
    End Class
End Namespace
