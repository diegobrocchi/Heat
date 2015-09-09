Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class ThermalUnitKind
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.ThermalUnitKinds",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Description = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.ThermalUnitKinds")
        End Sub
    End Class
End Namespace
