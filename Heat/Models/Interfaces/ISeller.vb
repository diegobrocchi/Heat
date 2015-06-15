Namespace Models
    ''' <summary>
    ''' Un ente che può emettere una fattura
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface ISeller
        ''' <summary>
        ''' Identificativo univoco 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ID As Integer
        ''' <summary>
        ''' Nome o ragione sociale
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Name As String
        ''' <summary>
        ''' Indirizzo della sede legale
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Address As Address
        ''' <summary>
        ''' Numero di Partita IVA
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Vat_Number As String
        ''' <summary>
        ''' Codice fiscale
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property FiscalCode As String
        ''' <summary>
        ''' Codice IBAN 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property IBAN As String
        ''' <summary>
        ''' Percorso del file del logo
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Logo As String
    End Interface

End Namespace
