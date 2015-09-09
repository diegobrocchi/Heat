Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class thermalunitNullableDate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.ThermalUnits", "FirstStartUp", Function(c) c.DateTime())
            AlterColumn("dbo.ThermalUnits", "WarrantyExpiration", Function(c) c.DateTime())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.ThermalUnits", "WarrantyExpiration", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.ThermalUnits", "FirstStartUp", Function(c) c.DateTime(nullable := False))
        End Sub
    End Class
End Namespace
