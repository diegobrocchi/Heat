Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class BoilerHeater_CertificationReference
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.BoilerHeaters", "CertificationReference", Function(c) c.String())
            AddColumn("dbo.BoilerServices", "PreviousServiceDate", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.BoilerServices", "Periodicity", Function(c) c.Int(nullable := False))
            AddColumn("dbo.BoilerServices", "LegalExpirationDate", Function(c) c.DateTime(nullable := False))
            AddColumn("dbo.BoilerServices", "PlannedServiceDate", Function(c) c.DateTime(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.BoilerServices", "PlannedServiceDate")
            DropColumn("dbo.BoilerServices", "LegalExpirationDate")
            DropColumn("dbo.BoilerServices", "Periodicity")
            DropColumn("dbo.BoilerServices", "PreviousServiceDate")
            DropColumn("dbo.BoilerHeaters", "CertificationReference")
        End Sub
    End Class
End Namespace
