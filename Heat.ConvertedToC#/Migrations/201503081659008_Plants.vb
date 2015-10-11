Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Plants
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.PlantClasses",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Plants",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Code = c.Int(nullable := False),
                        .Name = c.String(),
                        .Address = c.String(),
                        .StreetNumber = c.String(),
                        .City = c.String(),
                        .PostalCode = c.String(),
                        .Area = c.String(),
                        .Zone = c.String(),
                        .PlantTelephone1 = c.String(),
                        .PlantTelephone2 = c.String(),
                        .PlantTelephone3 = c.String(),
                        .PlantDistictCode = c.String(),
                        .Fuel = c.String(),
                        .PlantClass_ID = c.Int(),
                        .PlantType_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.PlantClasses", Function(t) t.PlantClass_ID) _
                .ForeignKey("dbo.PlantTypes", Function(t) t.PlantType_ID) _
                .Index(Function(t) t.PlantClass_ID) _
                .Index(Function(t) t.PlantType_ID)
            
            CreateTable(
                "dbo.PlantTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes")
            DropForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses")
            DropIndex("dbo.Plants", New String() { "PlantType_ID" })
            DropIndex("dbo.Plants", New String() { "PlantClass_ID" })
            DropTable("dbo.PlantTypes")
            DropTable("dbo.Plants")
            DropTable("dbo.PlantClasses")
        End Sub
    End Class
End Namespace
