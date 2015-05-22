Imports Heat.Models
Imports AutoMapper

Public Class NumberingViewModelsBuilder
    Private _db As IHeatDBContext



    Sub New(context As IHeatDBContext)
        _db = context
    End Sub

    Public Function GetCreateModel() As CreateNumberingViewModel
        Dim result As New CreateNumberingViewModel
        result.FinalSerialSchemaList = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
        result.TempSerialSchemaList = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

        Return result
    End Function

    Public Function GetEditModel(id As Integer) As EditNumberingViewModel
        Dim result As New EditNumberingViewModel
        Dim editingItem As Numbering

        editingItem = _db.Numberings.AsNoTracking.Include("FinalSerialSchema").Include("TempSerialSchema").ToList.Find(Function(x) x.ID = id) ' _db.Numberings.Find(id)

        result = AutoMapper.Mapper.Map(Of EditNumberingViewModel)(editingItem)

        result.FinalSerialSchemaList = _db.SerialSchemes.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, editingItem.FinalSerialSchema.ID, False)
        result.TempSerialSchemaList = _db.SerialSchemes.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, editingItem.TempSerialSchema.ID, False)

        Return result
    End Function

    Public Function GetIndexModel() As List(Of IndexNumberingViewModel)
        Dim result As List(Of IndexNumberingViewModel)
        Dim numberingList As List(Of Numbering)

        numberingList = _db.Numberings.ToList()
        result = Mapper.Map(Of List(Of IndexNumberingViewModel))(numberingList)

        Return result
    End Function

End Class

'Public Class NumberingViewModelsBuilder
'    Private _db As IHeatDBContext

'    Sub New()
'    End Sub

'    Sub New(context As IHeatDBContext)
'        _db = context
'    End Sub
'    Public Function GetCreateModel() As CreateNumberingViewModel
'        Dim result As New CreateNumberingViewModel
'        result.FinalSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
'        result.TempSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

'        Return result
'    End Function

'End Class
