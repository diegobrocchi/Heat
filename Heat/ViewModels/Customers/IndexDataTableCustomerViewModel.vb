Namespace ViewModels.Customers
    ''' <summary>
    ''' Il modello che viene mostrato nel jQuery Datatable.
    ''' E' un subset di Customer e ha solo le proprietà che interessa mostrare.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IndexDataTableCustomerViewModel
        ''' <summary>
        ''' Chiave primaria del Customer
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property ID As Integer
        Property Name As String
        Property Address As String
        Property City As String
        Property PostalCode As String
        Property Telephone1 As String
        Property IsEnabled As Boolean


    End Class
End Namespace



