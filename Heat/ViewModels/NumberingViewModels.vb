Imports System.ComponentModel.DataAnnotations

Public Class CreateNumberingViewModel
    <Required> _
    <Display(name:="Codice")> _
    Property Code As String

    <Required> _
    <Display(name:="Descrizione")> _
    Property Description As String

    <Required> _
    <Display(name:="Schema di numerazione progressivo")> _
    Property TempSerialSchema As IEnumerable(Of SelectListItem)

    <Required> _
    <Display(name:="Schema di numerazione definitivo")> _
    Property FinalSerialSchema As IEnumerable(Of SelectListItem)

End Class
