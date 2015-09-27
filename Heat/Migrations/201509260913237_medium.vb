Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class medium
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Media",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .FileName = c.String(),
                        .RelativePath = c.String(),
                        .AbsolutePath = c.String(),
                        .Lenght = c.Int(nullable := False),
                        .Extension = c.String(),
                        .Description = c.String(),
                        .Tags = c.String()
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Media")
        End Sub
    End Class
End Namespace
