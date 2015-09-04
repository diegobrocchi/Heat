Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Plants
    Public Class IndexPlantViewModel
        Property ID As Integer

        <Display(name:="Nominativo")> _
        Property Name As String

        <Display(name:="Classe impianto")> _
        Property PlantClass As String

        <Display(name:="Tipologia impianto")> _
        Property PlantType As String

        <Display(name:="Codice dell'impianto per la provincia")> _
        Property PlantDistinctCode As String

        <Display(name:="Indirizzo")> _
        Property Address As String



    End Class

End Namespace
