Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class removeFuelFromPlant
        Inherits DbMigration
    
        Public Overrides Sub Up()
            DropColumn("dbo.Plants", "Fuel")
        End Sub
        
        Public Overrides Sub Down()
            AddColumn("dbo.Plants", "Fuel", Function(c) c.String())
        End Sub
    End Class
End Namespace
