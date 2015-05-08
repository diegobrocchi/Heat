''' <summary>
''' Schema di numerazione utilizzabile per un numeratore.
''' Specifica il modo in cui viene creato un numero di serie.
''' </summary>
''' <remarks></remarks>
Public Class SerialScheme

    Property ID As Integer
    ''' <summary>
    ''' Valore iniziale della serie; se lo schema prevede il riciclo è il numero da cui riparte.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InitialValue As Integer
    ''' <summary>
    ''' Valore dell'incremento tra un elemento della serie e il successivo.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Increment As Integer
    ''' <summary>
    ''' Se diverso da Nothing è il valore minimo assegnabile a un elemento della serie.
    ''' Se è nullo allora il valore minimo assegnabile è Integer.minValue.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MinValue As Nullable(Of Integer)
    ''' <summary>
    ''' Se diverso da Nothing è il valore massimo assegnabile a un elemento della serie.
    ''' Se è Nothing allora il valore massimo assegnabile è Integer.MaxValue.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MaxValue As Nullable(Of Integer)
    ''' <summary>
    ''' Stringa di formattazione da utilizzare per la rappresentazione testuale del numero della serie.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property FormatMask As String
    ''' <summary>
    ''' Data ultima di validità dello schema; viene ricalcolata se RecycleWhenExpired = true.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ExpiryDate As DateTime
    ''' <summary>
    ''' Indica se lo schema deve essere re-inizializzato quando scade.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property RecycleWhenExpired As Boolean
    ''' <summary>
    ''' Indica il periodo di tempo di validità dello schema (nessuno, giornaliero, settimanale, mensile, annuale).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property Period As Periodicity
    ''' <summary>
    ''' Indica se lo schema deve essere re-inizializzato quando viene raggiunto il massimo.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property RecycleWhenMaxIsReached As Boolean


End Class
