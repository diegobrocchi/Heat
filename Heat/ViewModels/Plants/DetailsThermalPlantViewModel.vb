Imports System.ComponentModel.DataAnnotations


Namespace ViewModels.Plants
    ''' <summary>
    ''' Oggetto con ottenuto con flattening parziale di Plant, Plant.BuildingAddress e Plant.ThermalUnit
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DetailsThermalPlantViewModel

#Region "Proprietà derivate da Plant"
        Property ID As Integer
        <Display(name:="Classe impianto")> _
        Property PlantClass As String

        <Display(name:="Tipologia impianto")> _
        Property PlantType As String

#End Region

#Region "Proprietà derivate da Plant.BuidingAddress"
        <Display(name:="Singola unità abitativa")> _
        Property IsSingleUnit As Boolean

        <Display(name:="Categoria energetica")> _
        Property EnergyCategory As EnergyCategoryEnum

        <Display(name:="Volume lordo riscaldato (m³)")> _
        Property GrossHeatedVolumeM3 As Single

        <Display(name:="Volume lordo raffrescato (m³)")> _
        Property GrossCooledVolumeM3 As Single
#End Region

#Region "Proprietà derivate da Plant.ThermalUnit"
        <Display(name:="Costruttore")>
        Property Manifacturer As String

        <Display(name:="Modello")> _
        Property Model As String

        <Display(name:="Matricola")> _
        Property SerialNumber As String

        <Display(name:="Data di installazione")> _
        <DataType(DataType.Date)> _
        <DisplayFormat(dataformatstring:="{0:d}")> _
        Property InstallationDate As DateTime

        <Display(name:="Data di prima accensione")> _
        <DataType(DataType.Date)> _
        <DisplayFormat(dataformatstring:="{0:d}")> _
        Property FirstStartUp As Nullable(Of DateTime)

        <Display(name:="Garanzia")> _
        Property Warranty As String

        <Display(name:="Scadenza garanzia")> _
        <DataType(DataType.Date)> _
        <DisplayFormat(dataformatstring:="{0:d}")> _
        Property WarrantyExpiration As Nullable(Of DateTime)

        <Display(name:="Combustibile")> _
        Property Fuel As String

        <Display(name:="Potenza termica utile nominale Pn max (kW)")> _
        Property NominalThermalPowerMax As Single

        <Display(name:="Fluido termovettore")> _
        Property HeatTransferFluid As String

        <Display(name:="Rendimento termico utile a Pn max (%)")> _
        Property ThermalEfficiencyPowerMax As Single

        <Display(name:="Tipo di unità termica")> _
        Property Kind As ThermalUnitKindEnum

        'Property Heaters As List(Of Heater)
#End Region

    End Class
End Namespace

