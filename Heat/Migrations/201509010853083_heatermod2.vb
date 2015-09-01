Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class heatermod2
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.Heaters", "NominalThermalPowerMax")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Heaters", "NominalThermalPowerMax", Function(c) c.Single(nullable := False))
        End Sub
    End Class
End Namespace
