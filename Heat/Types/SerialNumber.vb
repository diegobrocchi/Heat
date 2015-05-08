''' <summary>
''' Rappresenta un numero di serie. Controllare la proprietà IsValid prima di utilizzarlo nel programma.
''' 
''' </summary>
''' <remarks></remarks>
Public Class SerialNumber
    Sub New()
    End Sub

    Sub New(serialInt As Integer, serialString As String, isValid As Boolean, invalidError As String)
        _SerialInteger = serialInt
        _SerialString = serialString
        _IsValid = isValid
        _InvalidError = invalidError
    End Sub

    Property SerialInteger As Integer
    Property SerialString As String
    Property IsValid As Boolean
    Property InvalidError As String

    Private Function Stringify(scheme As SerialScheme) As String
        Return _SerialInteger.ToString & "IN attesa di FORMATTAZIONE"
    End Function

    ''' <summary>
    ''' Restituisce il successivo elemento in base allo schema passato. 
    ''' Controlla la scadenza dello schema, la sua periodicità, i valori massimi e minimi e genera il successivo.
    ''' La proprietà IsValid indica se è stato possibile generare un numero di serie conforme allo schema.
    ''' </summary>
    ''' <param name="scheme"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Increment(scheme As SerialScheme) As SerialNumber
        Dim result As New SerialNumber
        'se lo schema è scaduto e non ricicla, restituisce un serial con IsValid = false.
        'se lo schema ha raggiunto il massimo e non ricicla, restituisce un serial con IsValid = false.
        'se lo schema è scaduto e ricicla, ricicla lo schema.
        'se lo schema ha raggiunto il massimo e ricicla, ricicla lo schema.

        If scheme.ExpiryDate > Now Then
            'lo schema non è scaduto
            If Me.SerialInteger + scheme.Increment > scheme.MaxValue Then
                If scheme.RecycleWhenMaxIsReached Then
                    Return New SerialNumber(scheme.InitialValue, "", True, String.Empty)
                Else
                    Return New SerialNumber(0, String.Empty, False, "Raggiunto il valore massimo dello schema!")
                End If
            End If
        Else
            'lo schema è scaduto
            If scheme.RecycleWhenExpired Then
                'rinnova lo schema
                Select Case scheme.Period
                    Case Periodicity.Daily
                        scheme.ExpiryDate = Now.EndOfDay
                    Case Periodicity.Weekly
                        scheme.ExpiryDate = Now.EndOfWeek
                    Case Periodicity.Monthly
                        scheme.ExpiryDate = Now.EndOfMonth
                    Case Periodicity.Quarterly
                        scheme.ExpiryDate = Now.EndOfQuarter
                    Case Periodicity.Yearly
                        scheme.ExpiryDate = Now.EndOfYear
                    Case Else
                        Return New SerialNumber(0, String.Empty, False, "Periodicità non definita")
                End Select
                'TODO: logica per formattare a string il numero.
                Return New SerialNumber(scheme.InitialValue, "diego " & scheme.InitialValue, True, String.Empty)
            Else
                'lo schema è scaduto e non ricicla.
                Return New SerialNumber(0, String.Empty, False, "Lo schema è scaduto e non ammette il riciclo!")
            End If
        End If



    End Function

End Class
