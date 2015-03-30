Imports Heat.Repositories

Namespace Business

    Public NotInheritable Class NumeratorManager
        Private Shared ReadOnly lazy As New Lazy(Of NumeratorManager)(Function() New NumeratorManager)

        Public Shared ReadOnly Property Instance As NumeratorManager
            Get
                Return lazy.Value
            End Get
        End Property

        Private Sub New()
        End Sub

        Public Shared Function GetNext(numerator As Numerator) As Integer
            Dim db As New HeatDBContext
            Dim lastvalue As Integer

            Dim dbNum As Numerator

            dbNum = db.Numerators.Find(numerator.ID)

            lastvalue = dbNum.LastValue + 1
            dbNum.LastValue = lastvalue + 1

            db.SaveChanges()

            Return dbNum.LastValue
        End Function

         

    End Class
End Namespace
