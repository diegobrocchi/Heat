Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.Heaters
    Public Class CreateHeaterViewModel

        Property ThermalUnitID As Integer
        <Display(name:="Generatore di riferimento")> _
        Property ThermalUnitDescription As String

        <Display(name:="Marca")> _
        Property ManifacturerID As String
        Property ManifacturerList As IEnumerable(Of SelectListItem)

        <Display(name:="Modello")> _
        Property ModelID As Integer
        Property ModelList As IEnumerable(Of SelectListItem)

        <Display(name:="Matricola")> _
        Property SerialNumber As String

        <Display(name:="Portata termica minima nominale (kW)")> _
        Property MinimumPowerKW As Single

        <Display(name:="Portata termica massima nominale (kW)")> _
        Property MaximumPowerKW As Single

        <Display(name:="Tipologia")> _
        Property Type As String

        <Display(name:="Data di installazione")> _
        Property InstallationDate As DateTime

        <Display(name:="Data di dismissione")> _
        Property DismissDate As Nullable(Of DateTime)

        <Display(name:="Combustibile")> _
        Property FuelID As Integer
        Property FuelList As IEnumerable(Of SelectListItem)

        
    End Class

End Namespace
