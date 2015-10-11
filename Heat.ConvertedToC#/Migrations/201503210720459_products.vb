Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class products
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Causations",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Code = c.String(),
                        .Sign = c.Int(nullable := False),
                        .Type_ID = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.CausationTypes", Function(t) t.Type_ID) _
                .Index(Function(t) t.Type_ID)
            
            CreateTable(
                "dbo.CausationTypes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Code = c.String(),
                        .Description = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Deposits",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Code = c.String(),
                        .Descrition = c.String(),
                        .HasValue = c.Boolean(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            AddColumn("dbo.InventoryMovements", "Causation_ID", Function(c) c.Int())
            AddColumn("dbo.InventoryMovements", "DestinationDeposit_ID", Function(c) c.Int())
            AddColumn("dbo.InventoryMovements", "SourceDeposit_ID", Function(c) c.Int())
            CreateIndex("dbo.InventoryMovements", "Causation_ID")
            CreateIndex("dbo.InventoryMovements", "DestinationDeposit_ID")
            CreateIndex("dbo.InventoryMovements", "SourceDeposit_ID")
            AddForeignKey("dbo.InventoryMovements", "Causation_ID", "dbo.Causations", "ID")
            AddForeignKey("dbo.InventoryMovements", "DestinationDeposit_ID", "dbo.Deposits", "ID")
            AddForeignKey("dbo.InventoryMovements", "SourceDeposit_ID", "dbo.Deposits", "ID")
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.InventoryMovements", "SourceDeposit_ID", "dbo.Deposits")
            DropForeignKey("dbo.InventoryMovements", "DestinationDeposit_ID", "dbo.Deposits")
            DropForeignKey("dbo.InventoryMovements", "Causation_ID", "dbo.Causations")
            DropForeignKey("dbo.Causations", "Type_ID", "dbo.CausationTypes")
            DropIndex("dbo.Causations", New String() { "Type_ID" })
            DropIndex("dbo.InventoryMovements", New String() { "SourceDeposit_ID" })
            DropIndex("dbo.InventoryMovements", New String() { "DestinationDeposit_ID" })
            DropIndex("dbo.InventoryMovements", New String() { "Causation_ID" })
            DropColumn("dbo.InventoryMovements", "SourceDeposit_ID")
            DropColumn("dbo.InventoryMovements", "DestinationDeposit_ID")
            DropColumn("dbo.InventoryMovements", "Causation_ID")
            DropTable("dbo.Deposits")
            DropTable("dbo.CausationTypes")
            DropTable("dbo.Causations")
        End Sub
    End Class
End Namespace
