Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class gruppi_causali
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.CausalWarehouses",
                Function(c) New With
                    {
                        .ID = c.Int(nullable:=False, identity:=True),
                        .Code = c.String(),
                        .Sign = c.Int(nullable:=False),
                        .TypeID = c.Int(nullable:=False),
                        .Transaction = c.Boolean(nullable:=False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.CausalWarehouseGroups", Function(t) t.TypeID, cascadeDelete:=False) _
                .Index(Function(t) t.TypeID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.CausalWarehouses", "TypeID", "dbo.CausalWarehouseGroups")
            DropIndex("dbo.CausalWarehouses", New String() { "TypeID" })
            DropTable("dbo.CausalWarehouses")
        End Sub
    End Class
End Namespace
