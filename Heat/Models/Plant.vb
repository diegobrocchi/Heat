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

        <Display(name:="Classe impianto")> _
        Property PlantClass As PlantClass

        <Display(name:="Tipologia impianto")> _
        Property PlantType As PlantType

        <Display(name:="Codice dell'impianto per la provincia")> _
        Property PlantDistinctCode As String

        Property BuildingAddress As PlantBuilding

        Property ThermalUnit As ThermalUnit

        Property Contacts As List(Of Contact)

        Overridable Property Service As PlantService

    End Class

End Namespace
