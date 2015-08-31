Imports Heat.ViewModels.ThermalUnits
Imports System.Data.Entity

Public Class ThermalUnitModelViewBuilder

    Private _db As IHeatDBContext

    Sub New(dbContext As IHeatDBContext)
        _db = dbContext
    End Sub

    Function GetCreateThermalUnitViewModel(plantID As Integer) As CreateThermalUnitViewModel
        Dim result As New CreateThermalUnitViewModel

        result.PlantDescription = _db.Plants.Find(plantID).Name
        result.ManifacturerList = _db.Manifacturers.OrderBy(Function(m) m.Name).ToList.ToSelectListItems(Function(m) m.Name, Function(m) m.ID, "")
        result.ModelList = _db.ManifacturerModels.Include(Function(mm) mm.Manifacturer).OrderBy(Function(mm) mm.Manifacturer.Name).ThenBy(Function(mm) mm.Model).ToList.ToSelectListItems(Function(x) x.Model, Function(x) x.ID, "")
        result.FuelList = _db.Fuels.OrderBy(Function(f) f.Name).ToList.ToSelectListItems(Function(f) f.Name, Function(f) f.ID, "")
        result.HeatTransferFluidList = _db.HeatTransferFluids.OrderBy(Function(htf) htf.Name).ToList.ToSelectListItems(Function(htf) htf.Name, Function(htf) htf.ID, "")

        result.InstallationDate = Now


        Return result

    End Function


End Class
