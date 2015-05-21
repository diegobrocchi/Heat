Imports Heat.Repositories
Imports Heat.Models

Namespace Manager

    Public NotInheritable Class NumeratorManager
        Private Shared ReadOnly lazy As New Lazy(Of NumeratorManager)(Function() New NumeratorManager)
        Private Shared ReadOnly _lockObject As New Object

        Public Shared ReadOnly Property Instance As NumeratorManager
            Get
                Return lazy.Value
            End Get
        End Property

        Private Sub New()
        End Sub

        ''' <summary>
        ''' Ritorna il successivo numero di serie di tipo temporaneo per il numeratore assegnato e aggiorna lo stesso numeratore.
        ''' </summary>
        ''' <param name="numbering"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNextTemp(ByRef numbering As Numbering) As SerialNumber

            SyncLock _lockObject
                Dim currentserial As SerialNumber
                Dim NextSerial As SerialNumber

                currentserial = numbering.LastTempSerial

                Try
                    NextSerial = currentserial.Increment(numbering.TempSerialSchema)
                    If NextSerial.IsValid Then
                        numbering.LastTempSerial = NextSerial
                        Return NextSerial
                    Else
                        Throw New Exception("Impossibile generare un seriale valido per il numeratore!")
                    End If
                Catch ex As Exception
                    Throw
                End Try

            End SyncLock

            
        End Function

        ''' <summary>
        ''' Ritorna il primo numero seriale di tipo definitivo per il numeratore assegnato
        ''' </summary>
        ''' <param name="numbering"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetNextFinal(numbering As Numbering) As Integer

        End Function

        'Private Function GetNext(lastValue As Integer, schema As SerialScheme) As SerialNumber

        '    Dim minValueAdmitted As Integer
        '    Dim maxValueAdmitted As Integer

        '    If schema.ExpiryDate < Now Then
        '        If schema.RecycleWhenExpired Then
        '            'rinnova lo schema


        '        Else
        '            Throw New Exception("Lo schema è scaduto!")
        '        End If
        '    End If
        'End Function

         

        Public Shared Function EndOfWeek() As DateTime
            Dim startDayOfCurrentWeek As DateTime
            startDayOfCurrentWeek = Now.AddDays(-Now.DayOfWeek).AddDays(7)
            Return Now.AddDays(-Now.DayOfWeek).AddDays(7)
        End Function
    End Class


End Namespace
