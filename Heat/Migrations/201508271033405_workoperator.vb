Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class workoperator
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.WorkOperators",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.WorkActions", "AssignedOperator_ID", Function(c) c.Int())
            CreateIndex("dbo.WorkActions", "AssignedOperator_ID")
            AddForeignKey("dbo.WorkActions", "AssignedOperator_ID", "dbo.WorkOperators", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.WorkActions", "AssignedOperator_ID", "dbo.WorkOperators")
            DropIndex("dbo.WorkActions", New String() { "AssignedOperator_ID" })
            DropColumn("dbo.WorkActions", "AssignedOperator_ID")
            DropTable("dbo.WorkOperators")
        End Sub
    End Class
End Namespace
