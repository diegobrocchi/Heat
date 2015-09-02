Imports Heat.Models
Imports Heat.ViewModels.Plants
Imports System.Data.Entity

Public Class PlantModelViewBuilder

    Private _db As IHeatDBContext

    Sub New(dbcontext As IHeatDBContext)
        _db = dbcontext
    End Sub

    'Function GetCreatePlantViewModel() As CreatePlantViewModel
    '    Dim result As New CreatePlantViewModel

    '    Return result
    'End Function

    Function GetAddContactPlantViewModel(plantID As Integer) As AddContactPlantViewModel
        Dim result As New AddContactPlantViewModel

        result.PlantID = plantID
        result.AddressTypeList = _db.AddressTypes.OrderBy(Function(x) x.Description).ToList.ToSelectListItems(Function(x) x.Description, Function(x) x.ID, "")

        Return result


    End Function
    Function GetAddThermInfoPlantViewModel(plantID As Integer) As AddThermInfoPlantViewModel
        Dim result As New AddThermInfoPlantViewModel

        result.PlantID = plantID
        result.PlantClassList = _db.PlantClasses.OrderBy(Function(x) x.Name).ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
        result.PlantTypeList = _db.PlantTypes.OrderBy(Function(x) x.Name).ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

        Return result

    End Function
End Class
