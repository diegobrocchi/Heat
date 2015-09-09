Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class renameDistrictInAddress
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Addresses", "District", Function(c) c.String())
            DropColumn("dbo.Addresses", "Province")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Addresses", "Province", Function(c) c.String())
            DropColumn("dbo.Addresses", "District")
        End Sub
    End Class
End Namespace
