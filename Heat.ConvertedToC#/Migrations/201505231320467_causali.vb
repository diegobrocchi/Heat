Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class causali
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.CausalWarehouseGroups",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Code = c.String(),
                        .Description = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.CausalWarehouseGroups")
        End Sub
    End Class
End Namespace
