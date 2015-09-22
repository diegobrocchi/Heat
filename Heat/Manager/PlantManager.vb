Imports DataTables.AspNet.Core
Imports DataTables.AspNet.Mvc5
Imports Heat.Models
Imports System.Linq.Dynamic
Imports AutoMapper.QueryableExtensions
Imports Heat.ViewModels.Plants

Namespace Manager
    Public Class PlantManager

        Private _db As IHeatDBContext
        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub

        ''' <summary>
        ''' Esegue una ricerca sui Plants in base alla request del datatable.
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        Public Function GetPagedPlants(request As IDataTablesRequest) As DataTablesJsonResult
            Dim baseData As IQueryable(Of Plant)
            Dim filteredData As IQueryable(Of Plant)
            Dim orderedData As IOrderedQueryable(Of Plant)
            Dim pagedData As IOrderedQueryable(Of Plant)

            'per prima cosa tutti gli impianti
            baseData = _db.Plants

            'poi filtra in base al termine inserito dall'utente
            filteredData = baseData.Where(Function(p) p.Name.Contains(request.Search.Value))

            Dim sortColumn As String = "plantdistinctcode"
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
            orderedData = filteredData.OrderBy(sortColumn & " " & sortDirection)

            pagedData = orderedData.Skip(request.Start).Take(request.Length)

            Return New DataTablesJsonResult(DataTablesResponse.Create(request, baseData.Count, filteredData.Count, pagedData.Project.To(Of IndexDataTablePlantViewModel)), JsonRequestBehavior.AllowGet)

        End Function

    End Class
End Namespace

