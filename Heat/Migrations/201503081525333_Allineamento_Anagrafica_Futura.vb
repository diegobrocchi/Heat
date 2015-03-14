Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Allineamento_Anagrafica_Futura
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Customers", "Name", Function(c) c.String())
            AddColumn("dbo.Customers", "Address", Function(c) c.String())
            AddColumn("dbo.Customers", "City", Function(c) c.String())
            AddColumn("dbo.Customers", "PostalCode", Function(c) c.String())
            AddColumn("dbo.Customers", "District", Function(c) c.String())
            AddColumn("dbo.Customers", "Telephone1", Function(c) c.String())
            AddColumn("dbo.Customers", "Telephone2", Function(c) c.String())
            AddColumn("dbo.Customers", "Telephone3", Function(c) c.String())
            AddColumn("dbo.Customers", "Taxcode", Function(c) c.String())
            AddColumn("dbo.Customers", "VAT", Function(c) c.String())
            AddColumn("dbo.Customers", "IBAN", Function(c) c.String())
            DropColumn("dbo.Customers", "FirstName")
            DropColumn("dbo.Customers", "Surname")
            DropColumn("dbo.Customers", "CompanyName")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Customers", "CompanyName", Function(c) c.String())
            AddColumn("dbo.Customers", "Surname", Function(c) c.String())
            AddColumn("dbo.Customers", "FirstName", Function(c) c.String())
            DropColumn("dbo.Customers", "IBAN")
            DropColumn("dbo.Customers", "VAT")
            DropColumn("dbo.Customers", "Taxcode")
            DropColumn("dbo.Customers", "Telephone3")
            DropColumn("dbo.Customers", "Telephone2")
            DropColumn("dbo.Customers", "Telephone1")
            DropColumn("dbo.Customers", "District")
            DropColumn("dbo.Customers", "PostalCode")
            DropColumn("dbo.Customers", "City")
            DropColumn("dbo.Customers", "Address")
            DropColumn("dbo.Customers", "Name")
        End Sub
    End Class
End Namespace
