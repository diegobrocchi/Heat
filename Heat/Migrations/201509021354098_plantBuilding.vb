Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class plantBuilding
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AddColumn("dbo.Plants", "BuildingAddress_Address", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_StreetNumber", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_Building", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_Stair", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_Apartment", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_City", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_PostalCode", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_Area", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_Zone", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_District", Function(c) c.String())
            AddColumn("dbo.Plants", "BuildingAddress_IsSingleUnit", Function(c) c.Boolean(nullable := False))
            AddColumn("dbo.Plants", "BuildingAddress_EnergyCategory", Function(c) c.Int(nullable := False))
            AddColumn("dbo.Plants", "BuildingAddress_GrossHeatedVolumeM3", Function(c) c.Single(nullable := False))
            AddColumn("dbo.Plants", "BuildingAddress_GrossCooledVolumeM3", Function(c) c.Single(nullable := False))
        End Sub
        
        Public Overrides Sub Down()
            DropColumn("dbo.Plants", "BuildingAddress_GrossCooledVolumeM3")
            DropColumn("dbo.Plants", "BuildingAddress_GrossHeatedVolumeM3")
            DropColumn("dbo.Plants", "BuildingAddress_EnergyCategory")
            DropColumn("dbo.Plants", "BuildingAddress_IsSingleUnit")
            DropColumn("dbo.Plants", "BuildingAddress_District")
            DropColumn("dbo.Plants", "BuildingAddress_Zone")
            DropColumn("dbo.Plants", "BuildingAddress_Area")
            DropColumn("dbo.Plants", "BuildingAddress_PostalCode")
            DropColumn("dbo.Plants", "BuildingAddress_City")
            DropColumn("dbo.Plants", "BuildingAddress_Apartment")
            DropColumn("dbo.Plants", "BuildingAddress_Stair")
            DropColumn("dbo.Plants", "BuildingAddress_Building")
            DropColumn("dbo.Plants", "BuildingAddress_StreetNumber")
            DropColumn("dbo.Plants", "BuildingAddress_Address")
        End Sub
    End Class
End Namespace
