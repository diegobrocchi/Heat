Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class HeatTransferFluid
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.HeatTransferFluids",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Name = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.HeatTransferFluids")
        End Sub
    End Class
End Namespace
