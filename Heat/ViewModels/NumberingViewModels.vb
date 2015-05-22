Imports System.ComponentModel.DataAnnotations
Imports Heat.Models

Public Class IndexNumberingViewModel
    <Key> _
    Property ID As Integer

    <Display(name:="Codice")> _
    Property Code As String

    <Display(name:="Descrizione")> _
    Property Description As String

    <Display(name:="Schema di numerazione provvisorio")> _
    Property TempSerialSchema As String

    <Display(name:="Schema di numerazione definitivo")> _
    Property FinalSerialSchema As String

End Class

Public Class CreateNumberingViewModel

    <Required> _
    <Display(name:="Codice")> _
    Property Code As String

    <Required> _
    <Display(name:="Descrizione")> _
    Property Description As String

    <Required> _
    <Display(name:="Schema di numerazione provvisorio")> _
    Property TempSerialSchemaID As Integer

    Property TempSerialSchemaList As IEnumerable(Of SelectListItem)

    <Required> _
    <Display(name:="Schema di numerazione definitivo")> _
    Property FinalSerialSchemaID As Integer

    Property FinalSerialSchemaList As IEnumerable(Of SelectListItem)

End Class

Public Class EditNumberingViewModel
    <Key> _
    <HiddenInput> _
    Property ID As Integer

    <Required> _
    <Display(name:="Codice")> _
    Property Code As String

    <Required> _
    <Display(name:="Descrizione")> _
    Property Description As String

    <Required> _
    <Display(name:="Schema di numerazione provvisorio")> _
    Property TempSerialSchemaID As Integer
    Property TempSerialSchemaList As IEnumerable(Of SelectListItem)

    <Required> _
    <Display(name:="Schema di numerazione definitivo")> _
    Property FinalSerialSchemaID As Integer
    Property FinalSerialSchemaList As IEnumerable(Of SelectListItem)

End Class



'Imports System.ComponentModel.DataAnnotations

'Public Class CreateNumberingViewModel
'    <Required> _
'    <Display(name:="Codice")> _
'    Property Code As String

'    <Required> _
'    <Display(name:="Descrizione")> _
'    Property Description As String

'    <Required> _
'    <Display(name:="Schema di numerazione progressivo")> _
'    Property TempSerialSchema As IEnumerable(Of SelectListItem)

'    <Required> _
'    <Display(name:="Schema di numerazione definitivo")> _
'    Property FinalSerialSchema As IEnumerable(Of SelectListItem)

'End Class
