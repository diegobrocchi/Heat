Imports Heat.ViewModels.Heaters
Imports System.Data.Entity


Public Class HeaterModelViewBuilder

    Private _db As IHeatDBContext

    Sub New(dbContext As IHeatDBContext)
        _db = dbContext
    End Sub

    Public Function GetCreateHeaterViewModel(thermalUnitID As Integer) As CreateHeaterViewModel
        Dim result As New CreateHeaterViewModel

        result.ThermalUnitID = thermalUnitID
        result.ThermalUnitDescription = _db.ThermalUnits.Find(thermalUnitID).SerialNumber
        result.ManifacturerList = _db.Manifacturers.OrderBy(Function(m) m.Name).ToList.ToSelectListItems(Function(m) m.Name, Function(m) m.ID, "")
        result.FuelList = _db.Fuels.OrderBy(Function(f) f.Name).ToList.ToSelectListItems(Function(f) f.Name, Function(f) f.ID, "")
        result.ModelList = _db.ManifacturerModels.Include(Function(mm) mm.Manifacturer).OrderBy(Function(mm) mm.Manifacturer.Name).ThenBy(Function(mm) mm.Model).ToList.ToSelectListItems(Function(x) x.Model, Function(x) x.ID, "")

        result.InstallationDate = Now

        Return result

    End Function

End Class
