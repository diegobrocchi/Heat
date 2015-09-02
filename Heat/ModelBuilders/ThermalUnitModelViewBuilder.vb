Imports Heat.ViewModels.ThermalUnits
Imports System.Data.Entity

Public Class ThermalUnitModelViewBuilder

    Private _db As IHeatDBContext

    Sub New(dbContext As IHeatDBContext)
        _db = dbContext
    End Sub

    ''' <summary>
    ''' Genera il modello per la view Create, con la lista dei PlantID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetCreateThermalUnitViewModel() As CreateThermalUnitViewModel
        Dim result As New CreateThermalUnitViewModel
        result.PlantIDSelected = False

        result.PlantList = _db.Plants.OrderBy(Function(x) x.Name).ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
        
        BindSelectLists(result)

        result.InstallationDate = Now

        Return result
    End Function


    ''' <summary>
    ''' Genera il modello della view Create, con il PlantID specificato.
    ''' </summary>
    ''' <param name="plantID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GetCreateThermalUnitViewModel(plantID As Integer) As CreateThermalUnitViewModel
        Dim result As New CreateThermalUnitViewModel

        result.PlantIDSelected = True
        result.PlantDescription = _db.Plants.Find(plantID).Name

        BindSelectLists(result)

        result.InstallationDate = Now

        Return result

    End Function

    Sub BindSelectLists(model As CreateThermalUnitViewModel)
        model.ManifacturerList = _db.Manifacturers.OrderBy(Function(m) m.Name).ToList.ToSelectListItems(Function(m) m.Name, Function(m) m.ID, "")
        model.ModelList = _db.ManifacturerModels.Include(Function(mm) mm.Manifacturer).OrderBy(Function(mm) mm.Manifacturer.Name).ThenBy(Function(mm) mm.Model).ToList.ToSelectListItems(Function(x) x.Model, Function(x) x.ID, "")
        model.FuelList = _db.Fuels.OrderBy(Function(f) f.Name).ToList.ToSelectListItems(Function(f) f.Name, Function(f) f.ID, "")
        model.HeatTransferFluidList = _db.HeatTransferFluids.OrderBy(Function(htf) htf.Name).ToList.ToSelectListItems(Function(htf) htf.Name, Function(htf) htf.ID, "")

    End Sub

End Class
