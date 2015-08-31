Imports System.ComponentModel.DataAnnotations

Namespace ViewModels.ThermalUnits
    Public Class CreateThermalUnitViewModel

        Property PlantID As Integer
        <Display(name:="Impianto")> _
        Property PlantDescription As String

        <Display(name:="Marca")> _
        Property ManifacturerID As String
        Property ManifacturerList As IEnumerable(Of SelectListItem)

        <Display(name:="Modello")> _
        Property ModelID As Integer
        Property ModelList As IEnumerable(Of SelectListItem)

        <Display(name:="Matricola")> _
        Property SerialNumber As String

        <Display(name:="Data di installazione")> _
        <DataType(DataType.Date)> _
        Property InstallationDate As DateTime

        <Display(name:="Data di prima accensione")> _
        <DataType(DataType.Date)> _
        Property FirstStartUp As Nullable(Of DateTime)

        <Display(name:="Garanzia")> _
        Property Warranty As String

        <Display(name:="Scadenza garanzia")> _
        <DataType(DataType.Date)> _
        Property WarrantyExpiration As Nullable(Of DateTime)

        <Required> _
        <Display(name:="Combustibile")> _
        Property FuelID As Integer
        Property FuelList As IEnumerable(Of SelectListItem)

        <Display(name:="Potenza termica utile nominale Pn max (kW)")> _
        Property NominalThermalPowerMax As Single

        <Display(name:="Fluido termovettore")> _
        Property HeatTransferFluidID As Integer
        Property HeatTransferFluidList As IEnumerable(Of SelectListItem)

        <Display(name:="Rendimento termico utile a Pn max (%)")> _
        Property ThermalEfficiencyPowerMax As Single

        <Required> _
        <Display(name:="Tipo di unità")> _
        Property Kind As ThermalUnitKindEnum



    End Class
End Namespace

