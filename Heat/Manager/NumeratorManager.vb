﻿Imports Heat.Repositories

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
        ''' Ritorna il successivo numero di serie di tipo temporaneo per il numeratore assegnato.
        ''' </summary>
        ''' <param name="numbering"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetNextTemp(numbering As Numbering) As SerialNumber

            SyncLock _lockObject
                Dim minValueAdmitted As Integer
                Dim maxValueAdmitted As Integer
                Dim currentScheme As SerialScheme

                currentScheme = numbering.TempSerialSchema
                minValueAdmitted = numbering.TempSerialSchema.MinValue
                maxValueAdmitted = numbering.TempSerialSchema.MaxValue

                If currentScheme.ExpiryDate < Now Then
                    If currentScheme.RecycleWhenExpired Then
                        'rinnova lo schema
                        Select Case currentScheme.Period
                            Case Periodicity.Daily
                                currentScheme.ExpiryDate = Now.EndOfDay
                                numbering.LastTempSerial.SerialInteger = currentScheme.InitialValue - currentScheme.Increment
                            Case Periodicity.Weekly
                                currentScheme.ExpiryDate = Now.EndOfWeek
                                numbering.LastTempSerial.SerialInteger = currentScheme.InitialValue - currentScheme.Increment
                            Case Periodicity.Monthly
                                currentScheme.ExpiryDate = Now.EndOfMonth
                                numbering.LastTempSerial.SerialInteger = currentScheme.InitialValue - currentScheme.Increment
                            Case Periodicity.Quarterly
                                currentScheme.ExpiryDate = Now.EndOfQuarter
                                numbering.LastTempSerial.SerialInteger = currentScheme.InitialValue - currentScheme.Increment
                            Case Periodicity.Yearly
                                currentScheme.ExpiryDate = Now.EndOfYear
                                numbering.LastTempSerial.SerialInteger = currentScheme.InitialValue - currentScheme.Increment
                            Case Else
                                Throw New Exception("Periodicità non definita!")
                        End Select
                    Else
                        Throw New Exception("Lo schema è scaduto!")
                    End If
                Else
                    'Return New SerialNumber(numbering.)
                End If

            End SyncLock

            'Dim lastvalue As Integer
            'Dim dbNum As Numbering

            'dbNum = context.Numberings.Find(numbering.ID)

            'lastvalue = dbNum.LastValue + 1
            'dbNum.LastValue = lastvalue + 1

            'db.SaveChanges()

            'Return dbNum.LastValue
        End Function

        ''' <summary>
        ''' Ritorna il primo numero seriale di tipo definitivo per il numeratore assegnato
        ''' </summary>
        ''' <param name="numbering"></param>
        ''' <param name="context"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetNextFinal(numbering As Numbering) As Integer

        End Function

        Private Function GetNext(lastValue As Integer, schema As SerialScheme) As SerialNumber

            Dim minValueAdmitted As Integer
            Dim maxValueAdmitted As Integer

            If schema.ExpiryDate < Now Then
                If schema.RecycleWhenExpired Then
                    'rinnova lo schema


                Else
                    Throw New Exception("Lo schema è scaduto!")
                End If
            End If
        End Function

         

        Public Shared Function EndOfWeek() As DateTime
            Dim startDayOfCurrentWeek As DateTime
            startDayOfCurrentWeek = Now.AddDays(-Now.DayOfWeek).AddDays(7)
            Return Now.AddDays(-Now.DayOfWeek).AddDays(7)
        End Function
    End Class


End Namespace
