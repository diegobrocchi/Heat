Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class documenttype
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.DocumentTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Description = c.String(),
                        .Numbering_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Numberings", Function(t) t.Numbering_ID) _
                .Index(Function(t) t.Numbering_ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.DocumentTypes", "Numbering_ID", "dbo.Numberings")
            DropIndex("dbo.DocumentTypes", New String() { "Numbering_ID" })
            DropTable("dbo.DocumentTypes")
        End Sub
    End Class
End Namespace
