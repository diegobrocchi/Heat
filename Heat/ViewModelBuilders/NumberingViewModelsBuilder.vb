Public Class NumberingViewModelsBuilder
    Private _db As IHeatDBContext

    Sub New()
    End Sub

    Sub New(context As IHeatDBContext)
        _db = context
    End Sub
    Public Function GetCreateModel() As CreateNumberingViewModel
        Dim result As New CreateNumberingViewModel
        result.FinalSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
        result.TempSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

        Return result
    End Function

End Class
