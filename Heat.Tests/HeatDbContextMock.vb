'https://visualstudiomagazine.com/articles/2014/06/01/test-driven-development.aspx

Public Class HeatDbContextMock
    Implements IHeatDBContext




    Public Property Numberings As Entity.DbSet(Of Models.Numbering) Implements IHeatDBContext.Numberings
    Public Property SerialScheme As Entity.DbSet(Of Models.SerialScheme) Implements IHeatDBContext.SerialSchemes
    Public Property Customers As Entity.DbSet(Of Models.Customer) Implements IHeatDBContext.Customers


    Public Sub New()
        Customers = New TestDbSet(Of Models.Customer)
    End Sub

    Public Function SaveChanges() As Integer Implements IHeatDBContext.SaveChanges
        Return 0
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
