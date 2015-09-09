Imports System.ComponentModel.DataAnnotations
Imports Heat.Models

Namespace ViewModels.Plants
    Public Class AddContactPlantViewModel
        Property PlantID As Integer

        <Required> _
        <Display(name:="Nominativo")> _
        Property Name As String

        <Display(name:="Tipo contatto")> _
        Property AddressTypeID As Integer
        Property AddressTypeList As IEnumerable(Of SelectListItem)

        <Display(name:="Indirizzo")> _
        Property Street As String

        <Display(name:="Numero civico")> _
        Property StreetNumber As String

        <Display(name:="Località")> _
        Property City As String

        <Display(name:="CAP")> _
        Property PostalCode As String

        <Display(name:="Provincia")> _
        Property District As String


        <Display(name:="Note")> _
        <DataType(DataType.MultilineText)> _
        Property Note As String

        <Display(name:="Telefono")> _
        Property Phone As String

        <Display(name:="Cellulare")> _
        Property CellPhone As String

        <Display(name:="Fax")> _
        Property Fax As String

        <Display(name:="Email")> _
        <DataType(DataType.EmailAddress)> _
        Property Email As String

        <Display(name:="Web")> _
        <DataType(DataType.Url)> _
        Property URL As String


    End Class

End Namespace
