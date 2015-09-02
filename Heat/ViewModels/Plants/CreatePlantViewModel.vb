Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Plants
    Public Class CreatePlantViewModel

        <Display(name:="Codice impianto")> _
        Property Code As Integer

        <Required> _
        <Display(name:="Nominativo")> _
        Property Name As String

        <Required> _
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

        <Required> _
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

        <Display(name:="Singola unità abitativa")> _
        Property IsSingleUnit As Boolean

        <Display(name:="Categoria energetica")> _
        Property EnergyCategory As EnergyCategoryEnum

        <Display(name:="Volume lordo riscaldato (m³)")> _
        Property GrossHeatedVolumeM3 As Single

        <Display(name:="Volume lordo raffrescato (m³)")> _
        Property GrossCooledVolumeM3 As Single


    End Class
End Namespace

