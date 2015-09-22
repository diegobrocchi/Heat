Imports Heat.Models
Imports DataTables.AspNet.Mvc5
Imports DataTables.AspNet.Core
Imports System.Linq.Dynamic
Imports AutoMapper.QueryableExtensions
Imports Heat.ViewModels.Customers



Namespace Manager

    Public Class CustomerManager

        Private _db As IHeatDBContext
        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub

        'Public Function GetPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As List(Of Customer)

        '    Return _db.Customers.OrderBy(Function(customer) customer.Name).Skip(skip).Take(take).ToList

        'End Function


        ''' <summary>
        ''' Esegue una ricerca sui clienti in base alla richiesta del controllo Datatable.
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPagedCustomers(request As IDataTablesRequest, enabled As Boolean) As DataTablesJsonResult

            Dim baseData As IQueryable(Of Customer)
            Dim filteredData As IQueryable(Of Customer)
            Dim orderedData As IQueryable(Of Customer)
            Dim pagedData As IQueryable(Of Customer)

            'per prima cosa seleziona dalla base dati solo i Customer abilitati/disabilitati
            baseData = _db.Customers.Where(Function(c) c.IsEnabled = enabled)

            'poi filtra i dati in base alla indicazione dell'utente (Case Insensitive)
            filteredData = baseData.Where(Function(c) c.Name.Contains(request.Search.Value) Or c.City.Contains(request.Search.Value))

            'poi ordina (non è supportato l'ordinamento multicolonna, quindi ordina per la prima colonna su cui è imposto l'ordinamento)
            Dim sortColumn As String = "name"
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

            Return New DataTablesJsonResult(DataTablesResponse.Create(request, baseData.Count, filteredData.Count, pagedData.Project.To(Of IndexDataTableCustomerViewModel)), JsonRequestBehavior.AllowGet)

        End Function


        Public Sub EnableCustomer(customer As Customer)
            Me.EnableCustomer(customer.ID)
        End Sub

        Public Sub EnableCustomer(customerID As Integer)
            Dim c As Customer
            c = _db.Customers.Find(customerID)
            If IsNothing(c) Then
                Throw New Exception("Impossibile trovare il Cliente richiesto!")
            End If

            c.IsEnabled = True
            c.EnableDate = Now

        End Sub

        Public Sub DisableCustomer(customer As Customer)
            Me.DisableCustomer(customer.ID)
        End Sub

        Public Sub DisableCustomer(customerID As Integer)
            Dim c As Customer
            c = _db.Customers.Find(customerID)
            If IsNothing(c) Then
                Throw New Exception("Impossibile trovare il Cliente richiesto!")
            End If

            c.IsEnabled = False
            c.DisableDate = Now
        End Sub
    End Class

End Namespace
