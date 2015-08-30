Imports Heat.ViewModels.ManifacturerModels
Imports Heat.Models
Imports System.Data.Entity

Public Class ManifacturerModelViewBuilder
    Private _db As IHeatDBContext

    Sub New(context As IHeatDBContext)
        _db = context
    End Sub

    Public Function GetIndexManifacturerModelViewModel() As List(Of IndexManifacturerModelViewModel)
        Dim result As List(Of IndexManifacturerModelViewModel)

        result = _db.ManifacturerModels.
            Include(Function(x) x.Manifacturer).
            Select(Function(x) New IndexManifacturerModelViewModel With {.ID = x.ID, .Model = x.Model, .Manifacturer = x.Manifacturer.Name}).ToList

        Return result


    End Function

    Public Function GetCreateManifacturerModelViewModel() As CreateManifacturerModelViewModel
        Dim result As New CreateManifacturerModelViewModel

        result.ManifacturerList = _db.Manifacturers.ToList.OrderBy(Function(x) x.Name).ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

        Return result
    End Function

    Public Function GetEditManifacturerModelViewModel(id) As EditManifacturerModelViewModel
        Dim result As New EditManifacturerModelViewModel
        Dim dbItem As ManifacturerModel

        dbItem = _db.ManifacturerModels.Find(id)

        result.ID = id
        result.ManifacturerID = dbItem.ManifacturerID
        result.Model = dbItem.Model
        result.ManifacturerList = _db.Manifacturers.ToList.OrderBy(Function(x) x.Name).ToSelectListItems(Function(x) x.Name, Function(x) x.ID, result.ManifacturerID)

        Return result

    End Function
End Class
