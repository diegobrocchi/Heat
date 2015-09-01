Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models

    ''' <summary>
    ''' Rappresenta un generatore di calore: gruppo termico (quindi con bruciatore integerato) oppure caldaia.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ThermalUnit
        <Key> _
        Property ID As Integer

        '************
        'Proprietà copiate da Futura
        Property ManifacturerId As Integer
        Property Manifacturer As Manifacturer
        Property ModelID As Integer
        Property Model As ManifacturerModel
        Property SerialNumber As String
        Property InstallationDate As DateTime
        Property FirstStartUp As DateTime
        Property Warranty As String
        Property WarrantyExpiration As DateTime
        'Fine proprietà copiate da Futura

        '************
        'Proprietà del libretto di impianto
        Property FuelID As Integer
        Property Fuel As Fuel

        'Potenza termica utile nominale Pn max (kW)
        Property NominalThermalPowerMax As Single

        Property DismissDate As Nullable(Of DateTime)

        Property HeatTransferFluidID As Integer
        Property HeatTransferFluid As HeatTransferFluid
        'Rendimento termico utile a Pn max (%)
        Property ThermalEfficiencyPowerMax As Single

        'Esiste anche una classe 'ThermalUnitKind': da decidere cosa è meglio, se enum o classe.
        Property Kind As ThermalUnitKindEnum

        Property Heaters As List(Of Heater)

        '**************
        'fine proprietà del libretto di impianto



    End Class
End Namespace

