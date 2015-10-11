Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class proposedCalls
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ProposedOutBoundCalls",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .User = c.String(),
                        .PlantID = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Plants", Function(t) t.PlantID, cascadeDelete := True) _
                .Index(Function(t) t.PlantID)
            
            AddColumn("dbo.Contacts", "ProposedOutBoundCall_ID", Function(c) c.Int())
            CreateIndex("dbo.Contacts", "ProposedOutBoundCall_ID")
            AddForeignKey("dbo.Contacts", "ProposedOutBoundCall_ID", "dbo.ProposedOutBoundCalls", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.ProposedOutBoundCalls", "PlantID", "dbo.Plants")
            DropForeignKey("dbo.Contacts", "ProposedOutBoundCall_ID", "dbo.ProposedOutBoundCalls")
            DropIndex("dbo.ProposedOutBoundCalls", New String() { "PlantID" })
            DropIndex("dbo.Contacts", New String() { "ProposedOutBoundCall_ID" })
            DropColumn("dbo.Contacts", "ProposedOutBoundCall_ID")
            DropTable("dbo.ProposedOutBoundCalls")
        End Sub
    End Class
End Namespace
