Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Plants

    Public Class DetailsIdentifyPlantViewModel

        Property ID As Integer

        <Display(name:="Nominativo")> _
        Property Name As String

        <Display(name:="Codice dell'impianto per la provincia")> _
        Property PlantDistinctCode As String

        <Display(name:="Indirizzo")> _
        Property Address As String

        <Display(name:="Numero Civico")> _
        Property StreetNumber As String

        <Display(name:="Palazzo")> _
        Property Building As String

        <Display(name:="Scala")> _
        Property Stair As String

        <Display(name:="Interno")> _
        Property Apartment As String

        <Display(name:="Località")> _
        Property City As String

        <Display(name:="CAP")> _
        Property PostalCode As String

        <Display(name:="Area")> _
        Property Area As String

        <Display(name:="Zona")> _
        Property Zone As String

        <Display(name:="Provincia")> _
        Property District As String

    End Class

End Namespace
