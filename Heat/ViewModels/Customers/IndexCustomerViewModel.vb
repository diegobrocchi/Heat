 
Namespace ViewModels.Customers

    Public Class IndexCustomerViewModel

        ''' <summary>
        ''' Indica se sono visualizzati anche i clienti disabilitati.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property IsIncludeDisable As Boolean

        ''' <summary>
        ''' Indica se nella lista dei clienti ci sono soggetti disabilitati.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property HasDisabled As Boolean

        Property Rows As List(Of IndexCustomerGridViewModel)

    End Class

End Namespace
