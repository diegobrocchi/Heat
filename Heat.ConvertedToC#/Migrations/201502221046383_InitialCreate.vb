Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Addresses",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Street = c.String(),
                        .StreetNumber = c.String(),
                        .City = c.String(),
                        .PostalCode = c.String(),
                        .Province = c.String(),
                        .State = c.String(),
                        .AddressType_ID = c.Int(),
                        .Customer_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.AddressTypes", Function(t) t.AddressType_ID) _
                .ForeignKey("dbo.Customers", Function(t) t.Customer_ID) _
                .Index(Function(t) t.AddressType_ID) _
                .Index(Function(t) t.Customer_ID)
            
            CreateTable(
                "dbo.AddressTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Description = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Customers",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .FirstName = c.String(),
                        .Surname = c.String(),
                        .CompanyName = c.String(),
                        .EMail = c.String(),
                        .Website = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Addresses", "Customer_ID", "dbo.Customers")
            DropForeignKey("dbo.Addresses", "AddressType_ID", "dbo.AddressTypes")
            DropIndex("dbo.Addresses", New String() { "Customer_ID" })
            DropIndex("dbo.Addresses", New String() { "AddressType_ID" })
            DropTable("dbo.Customers")
            DropTable("dbo.AddressTypes")
            DropTable("dbo.Addresses")
        End Sub
    End Class
End Namespace
