Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class addresstype
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Contacts",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Phone = c.String(),
                        .CellPhone = c.String(),
                        .Fax = c.String(),
                        .Email = c.String(),
                        .URL = c.String(),
                        .Address_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Addresses", Function(t) t.Address_ID) _
                .Index(Function(t) t.Address_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Contacts", "Address_ID", "dbo.Addresses")
            DropIndex("dbo.Contacts", New String() { "Address_ID" })
            DropTable("dbo.Contacts")
        End Sub
    End Class
End Namespace
