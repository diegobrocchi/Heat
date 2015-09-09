Namespace Models

    ''' <summary>
    ''' Rappresenta una operazione di manutenzione di impianto per la caldaia.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BoilerService

        Property ID As Integer
        Property Boiler As Boiler
        Property Type As BoilerServiceType

        ''' <summary>
        ''' Data della ultima manutenzione eseguita.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PreviousServiceDate As DateTime

        ''' <summary>
        ''' Periodicità della manutenzione.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property Periodicity As Periodicity

        ''' <summary>
        ''' Scadenza legale della manutenzione.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property LegalExpirationDate As DateTime

        ''' <summary>
        ''' Data programmata di esecuzione della manutenzione. 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Property PlannedServiceDate As DateTime

    End Class
End Namespace
