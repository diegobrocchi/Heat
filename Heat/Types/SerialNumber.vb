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
    ''' <summary>
    ''' TODO!!!
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="scheme"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Stringify(value As Integer, scheme As SerialScheme) As String
        Dim result As String

        scheme.FormatMask = scheme.FormatMask.Replace("{{yyyy}}", Now.Year)
        scheme.FormatMask = scheme.FormatMask.Replace("{{ww}}", Now.WeekOfTheYear)
        If Not String.IsNullOrEmpty(scheme.FormatMask) Then
            result = String.Format(scheme.FormatMask, value)
        Else
            result = value.ToString
        End If
        Return result
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
        If Not _IsValid Then
            Throw New Exception("Cannot increment invalid SerialNumber!")
        End If
        If IsNothing(scheme.ExpiryDate) Then
            scheme.ExpiryDate = DateTime.MaxValue
        End If

        If scheme.RecycleWhenExpired And IsNothing(scheme.Period) Then
            Throw New ArgumentException("Scheme recyles but period is null!")
        End If

        If IsNothing(scheme.MaxValue) And scheme.RecycleWhenMaxIsReached Then
            Throw New ArgumentException("Scheme recycles on Max reached, but MaxValue in null!")
        End If

        If IsNothing(scheme.FormatMask) Then
            scheme.FormatMask = String.Empty
        End If
        Dim result As New SerialNumber
        'se lo schema è scaduto e non ricicla, restituisce un serial con IsValid = false.
        'se lo schema ha raggiunto il massimo e non ricicla, restituisce un serial con IsValid = false.
        'se lo schema è scaduto e ricicla, ricicla lo schema.
        'se lo schema ha raggiunto il massimo e ricicla, ricicla lo schema.

        If scheme.ExpiryDate > Now Then
            'lo schema non è scaduto
            If Me.SerialInteger + scheme.Increment > scheme.MaxValue Then
                'lo schema non è scaduto, ma ha raggiunto il limite massimo
                If scheme.RecycleWhenMaxIsReached Then
                    Return New SerialNumber(scheme.InitialValue, Stringify(scheme.InitialValue, scheme), True, String.Empty)
                Else
                    Return New SerialNumber(0, String.Empty, False, "Raggiunto il valore massimo dello schema!")
                End If
            Else
                'lo schema non è scaduto e non ha raggiunto il limite massimo: 
                Return New SerialNumber(_SerialInteger + scheme.Increment, Stringify(_SerialInteger + scheme.Increment, scheme), True, String.Empty)
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

                Return New SerialNumber(scheme.InitialValue, Stringify(scheme.InitialValue, scheme), True, String.Empty)
            Else
                'lo schema è scaduto e non ricicla.
                Return New SerialNumber(0, String.Empty, False, "Lo schema è scaduto e non ammette il riciclo!")
            End If
        End If



    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If IsNothing(obj) Then
            Return False
        End If

        Dim other As SerialNumber = TryCast(obj, SerialNumber)

        If IsNothing(other) Then
            Return False
        End If

        If IsValid = other.IsValid And _
            SerialInteger = other.SerialInteger And _
            SerialString = other.SerialString And _
            InvalidError = other.InvalidError Then

            Return True
        Else
            Return False

        End If

    End Function

    Public Overrides Function GetHashCode() As Integer

        Dim hash As Integer
        hash = 13
        hash = hash * Me.IsValid.GetHashCode
        hash = hash * Me.SerialInteger.GetHashCode
        hash = hash * Me.SerialString.GetHashCode
        hash = hash * Me.InvalidError.GetHashCode

        Return hash
    End Function

End Class
