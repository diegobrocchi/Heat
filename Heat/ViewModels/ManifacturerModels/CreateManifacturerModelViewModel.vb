Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.ManifacturerModels

    Public Class CreateManifacturerModelViewModel
        <Required> _
        <Display(name:="Marca")> _
        Property ManifacturerID As Integer
        Property ManifacturerList As IEnumerable(Of SelectListItem)
        <Required> _
        Property Model As String
    End Class

End Namespace
