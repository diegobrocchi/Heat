Namespace Models
    ''' <summary>
    ''' Rappresenta un ente in grado di emettere una fattura
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Seller
        Implements ISeller

        Public Property Address As Address Implements ISeller.Address

        Public Property FiscalCode As String Implements ISeller.FiscalCode

        Public Property IBAN As String Implements ISeller.IBAN

        Public Property ID As Integer Implements ISeller.ID

        Public Property Logo As String Implements ISeller.Logo

        Public Property Name As String Implements ISeller.Name

        Public Property Vat_Number As String Implements ISeller.Vat_Number
    End Class
End Namespace

