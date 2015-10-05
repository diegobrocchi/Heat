Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class OutboundCalls
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.OutboundCalls",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .CallDate = c.DateTime(nullable := False),
                        .ContactID = c.Int(nullable := False),
                        .ResultID = c.Int(nullable := False),
                        .Login = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Contacts", Function(t) t.ContactID, cascadeDelete := True) _
                .Index(Function(t) t.ContactID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.OutboundCalls", "ContactID", "dbo.Contacts")
            DropIndex("dbo.OutboundCalls", New String() { "ContactID" })
            DropTable("dbo.OutboundCalls")
        End Sub
    End Class
End Namespace
