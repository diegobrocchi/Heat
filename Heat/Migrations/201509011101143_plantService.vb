Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class plantService
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.PlantServices",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False),
                        .PreviousServiceDate = c.DateTime(nullable := False),
                        .Periodicity = c.Int(nullable := False),
                        .LegalExpirationDate = c.DateTime(nullable := False),
                        .PlannedServiceDate = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Plants", Function(t) t.ID) _
                .Index(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.PlantServices", "ID", "dbo.Plants")
            DropIndex("dbo.PlantServices", New String() { "ID" })
            DropTable("dbo.PlantServices")
        End Sub
    End Class
End Namespace
