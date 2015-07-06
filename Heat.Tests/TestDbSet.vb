Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Collections.ObjectModel
Imports System.Linq.Expressions
Imports System.Threading.Tasks
Imports System.Threading

Public Class TestDbSet(Of TEntity As Class)
    Inherits DbSet(Of TEntity)
    Implements IQueryable
    Implements IEnumerable(Of TEntity)
    Implements IDbAsyncEnumerable(Of TEntity)

    Private _data As ObservableCollection(Of TEntity)
    Private _query As IQueryable


    Public Sub New()
        _data = New ObservableCollection(Of TEntity)
        _query = _data.AsQueryable
    End Sub

    Public Overrides Function Find(ParamArray keyValues() As Object) As TEntity
        Return MyBase.Find(keyValues)
    End Function
     
    Public Overrides Function Add(item As TEntity) As TEntity
        _data.Add(item)
        Return item
    End Function

    Public Overrides Function Remove(item As TEntity) As TEntity
        _data.Remove(item)
        Return item
    End Function

    Public Overrides Function Attach(item As TEntity) As TEntity
        _data.Add(item)
        Return item
    End Function

    Public Overrides Function Create() As TEntity
        Return Activator.CreateInstance(Of TEntity)()
    End Function

    Public Overrides Function Create(Of TDerivedEntity As {Class, TEntity})() As TDerivedEntity
        Return MyBase.Create(Of TDerivedEntity)()
    End Function

    Public Overrides ReadOnly Property Local() As ObservableCollection(Of TEntity)
        Get
            Return _data
        End Get
    End Property

    Private ReadOnly Property IQueryable_ElementType() As Type Implements IQueryable.ElementType
        Get
            Return _query.ElementType
        End Get
    End Property

    Private ReadOnly Property IQueryable_Expression() As Expression Implements IQueryable.Expression
        Get
            Return _query.Expression
        End Get
    End Property

    Private ReadOnly Property IQueryable_Provider() As IQueryProvider Implements IQueryable.Provider
        Get
            Return New TestDbAsyncQueryProvider(Of TEntity)(_query.Provider)
        End Get
    End Property

    Private Function System_Collections_IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return _data.GetEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator(Of TEntity) Implements IEnumerable(Of TEntity).GetEnumerator
        Return _data.GetEnumerator()
    End Function

    Private Function IDbAsyncEnumerable_GetAsyncEnumerator() As IDbAsyncEnumerator(Of TEntity) Implements IDbAsyncEnumerable(Of TEntity).GetAsyncEnumerator
        Return New TestDbAsyncEnumerator(Of TEntity)(_data.GetEnumerator())
    End Function

End Class


Friend Class TestDbAsyncQueryProvider(Of TEntity)
    Implements IDbAsyncQueryProvider
    Private ReadOnly _inner As IQueryProvider

    Friend Sub New(inner As IQueryProvider)
        _inner = inner
    End Sub

    Public Function CreateQuery(expression As Expression) As IQueryable Implements IDbAsyncQueryProvider.CreateQuery
        Return New TestDbAsyncEnumerable(Of TEntity)(expression)
    End Function

    Public Function CreateQuery(Of TElement)(expression As Expression) As IQueryable(Of TElement) Implements IDbAsyncQueryProvider.CreateQuery
        Return New TestDbAsyncEnumerable(Of TElement)(expression)
    End Function

    Public Function Execute(expression As Expression) As Object Implements IDbAsyncQueryProvider.Execute
        Return _inner.Execute(expression)
    End Function

    Public Function Execute(Of TResult)(expression As Expression) As TResult Implements IQueryProvider.Execute
        Return _inner.Execute(Of TResult)(expression)
    End Function

    Public Function ExecuteAsync(expression As Expression, cancellationToken As CancellationToken) As Task(Of Object) Implements IDbAsyncQueryProvider.ExecuteAsync
        Return Task.FromResult(Execute(expression))
    End Function

    Public Function ExecuteAsync(Of TResult)(expression As Expression, cancellationToken As CancellationToken) As Task(Of TResult) Implements IDbAsyncQueryProvider.ExecuteAsync
        Return Task.FromResult(Execute(Of TResult)(expression))
    End Function
End Class

Friend Class TestDbAsyncEnumerable(Of T)
    Inherits EnumerableQuery(Of T)
    Implements IDbAsyncEnumerable(Of T)

    Public Sub New(enumerable As IEnumerable(Of T))
        MyBase.New(enumerable)
    End Sub

    Public Sub New(expression As Expression)
        MyBase.New(expression)
    End Sub

    Public Function GetAsyncEnumerator() As IDbAsyncEnumerator(Of T) Implements IDbAsyncEnumerable(Of T).GetAsyncEnumerator
        Return New TestDbAsyncEnumerator(Of T)(Me.AsEnumerable().GetEnumerator())
    End Function

    Private Function IDbAsyncEnumerable_GetAsyncEnumerator() As IDbAsyncEnumerator Implements IDbAsyncEnumerable.GetAsyncEnumerator
        Return GetAsyncEnumerator()
    End Function

    Public ReadOnly Property Provider() As IQueryProvider
        Get
            Return New TestDbAsyncQueryProvider(Of T)(Me)
        End Get
    End Property
     
     
End Class

Friend Class TestDbAsyncEnumerator(Of T)
    Implements IDbAsyncEnumerator(Of T)
    Implements IDisposable

    Private ReadOnly _inner As IEnumerator(Of T)

    Public Sub New(inner As IEnumerator(Of T))
        _inner = inner
    End Sub

    Public Sub Dispose()
        _inner.Dispose()
    End Sub

    Public Function MoveNextAsync(cancellationToken As CancellationToken) As Task(Of Boolean) Implements IDbAsyncEnumerator(Of T).MoveNextAsync
        Return Task.FromResult(_inner.MoveNext())
    End Function

    Public ReadOnly Property Current() As T Implements IDbAsyncEnumerator(Of T).Current
        Get
            Return _inner.Current
        End Get
    End Property

    Private ReadOnly Property IDbAsyncEnumerator_Current() As Object Implements IDbAsyncEnumerator.Current
        Get
            Return Current
        End Get
    End Property

    Public Sub Dispose1() Implements IDisposable.Dispose
    End Sub
End Class