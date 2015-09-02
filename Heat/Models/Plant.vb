Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Models
    ''' <summary>
    ''' Rappresenta un Impianto: un impianto ha un libretto di impianto.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Plant

        Sub New()
            Me.Contacts = New List(Of Contact)
        End Sub

        <Key> _
        Property ID As Integer

        <Display(name:="Codice impianto")> _
        Property Code As Integer
        <Display(name:="Nominativo")> _
        Property Name As String
        '<Display(name:="Indirizzo impianto")> _
        'Property Address As String
        '<Display(name:="Numero civico")> _
        'Property StreetNumber As String
        '<Display(name:="Comune")> _
        'Property City As String
        '<Display(name:="CAP")> _
        'Property PostalCode As String
        '<Display(name:="Frazione")> _
        'Property Area As String
        '<Display(name:="Zona")> _
        'Property Zone As String
        '<Display(name:="Telefono impianto 1")> _
        'Property PlantTelephone1 As String
        '<Display(name:="Telefono impianto 2")> _
        'Property PlantTelephone2 As String
        '<Display(name:="Telefono impianto 3")> _
        'Property PlantTelephone3 As String

        <Display(name:="Classe impianto")> _
        Property PlantClassID As Integer
        Property PlantClass As PlantClass

        <Display(name:="Tipologia impianto")> _
        Property PlantTypeID As Integer
        Property PlantType As PlantType


        <Display(name:="Codice dell'impianto per la provincia")> _
        Property PlantDistinctCode As String

        Property BuildingAddress As PlantBuilding

        Property ThermalUnit As ThermalUnit

        Property Contacts As List(Of Contact)

        Overridable Property Service As PlantService

    End Class

End Namespace
