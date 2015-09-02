Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removeAddressPlant
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.Plants", "Address")
            DropColumn("dbo.Plants", "StreetNumber")
            DropColumn("dbo.Plants", "City")
            DropColumn("dbo.Plants", "PostalCode")
            DropColumn("dbo.Plants", "Area")
            DropColumn("dbo.Plants", "Zone")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Plants", "Zone", Function(c) c.String())
            AddColumn("dbo.Plants", "Area", Function(c) c.String())
            AddColumn("dbo.Plants", "PostalCode", Function(c) c.String())
            AddColumn("dbo.Plants", "City", Function(c) c.String())
            AddColumn("dbo.Plants", "StreetNumber", Function(c) c.String())
            AddColumn("dbo.Plants", "Address", Function(c) c.String())
        End Sub
    End Class
End Namespace
