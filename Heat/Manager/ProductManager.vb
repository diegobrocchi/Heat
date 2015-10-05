Imports DataTables.AspNet.Core
Imports DataTables.AspNet.Mvc5
Imports Heat.Models
Imports AutoMapper.QueryableExtensions
Imports System.Linq.Dynamic
Imports Heat.ViewModels.Product

Namespace Manager

    Public Class ProductManager
        Private _db As IHeatDBContext
        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub

        ''' <summary>
        ''' Esegue una ricerca sui Products in base alla request del datatable.
        ''' Restituisce un DataTablesJsonResult consumabile dalla datatable che l'ha richiesto.
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function GetPagedProducts(request As IDataTablesRequest) As DataTablesJsonResult
            Dim baseData As IQueryable(Of Product)
            Dim filteredData As IQueryable(Of Product)
            Dim orderedData As IOrderedQueryable(Of Product)
            Dim pagedData As IOrderedQueryable(Of Product)

            'per prima cosa tutti i prodotti
            baseData = _db.Products

            'poi filtra in base al termine inserito dall'utente
            filteredData = baseData.Where(Function(p) p.Description.Contains(request.Search.Value))

            Dim sortColumn As String = "description"
            Dim sortDirection As String = "ASC"
            For Each column In request.Columns
                If column.IsSortable Then
                    If Not IsNothing(column.Sort) Then
                        sortColumn = column.Field
                        If column.Sort.Direction = DataTables.AspNet.Core.SortDirection.Ascending Then
                            sortDirection = "ASC"
                        Else
                            sortDirection = "DESC"
                        End If
                        Exit For
                    End If
                End If
            Next

            'ordina il set
            orderedData = filteredData.OrderBy(sortColumn & " " & sortDirection)

            'pagina il set
            pagedData = orderedData.Skip(request.Start).Take(request.Length)

            'json-izza e ritorna
            Return New DataTablesJsonResult(DataTablesResponse.Create(request, baseData.Count, filteredData.Count, pagedData.Project.To(Of IndexDataTableProductViewModel)), JsonRequestBehavior.AllowGet)

        End Function
    End Class

End Namespace
