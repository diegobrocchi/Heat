Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat
Imports Heat.Models
Imports Heat.Repositories

Namespace Controllers

    Public Class CustomersController
        Inherits System.Web.Mvc.Controller

        Private _db As HeatDBContext

        Sub New(dbcontext As HeatDBContext)
            _db = dbcontext
        End Sub

        ' GET: Customers

        Function Index(sortOrder As String) As ActionResult

            Dim custviewmodelb As New BusinessModelViewBuilder(_db)
            'TODO: jQ Datatable con server processing
            Return View(custviewmodelb.GetSortedAndPagedCustomer(sortOrder, 0, 1000))

        End Function

        ' GET: Customers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = _db.Customers.Find(id)
            If IsNothing(customer) Then
                Return HttpNotFound()
            End If
            Return View(customer)
        End Function

        ' GET: Customers/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Customers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name,Address,City,PostalCode,VAT,EMail,Website")> ByVal customer As Customer) As ActionResult
            If ModelState.IsValid Then
                _db.Customers.Add(customer)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(customer)
        End Function

        ' GET: Customers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = _db.Customers.Find(id)
            If IsNothing(customer) Then
                Return HttpNotFound()
            End If
            Return View(customer)
        End Function

        ' POST: Customers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name,Surname,CompanyName,EMail,Website")> ByVal customer As Customer) As ActionResult
            If ModelState.IsValid Then
                _db.Entry(customer).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(customer)
        End Function

        ' GET: Customers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = _db.Customers.Find(id)
            If IsNothing(customer) Then
                Return HttpNotFound()
            End If
            Return View(customer)
        End Function

        ' POST: Customers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim customer As Customer = _db.Customers.Find(id)
            _db.Customers.Remove(customer)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Function Search(searchstring As String) As ActionResult
            Dim result As New List(Of Customer)
            result = _db.Customers.Where(Function(customer) customer.Name.Contains(searchstring)).ToList

            Return View(result)

        End Function

        <HttpGet> _
        Function Import() As ActionResult
            Return View()
        End Function

        <HttpPost> _
        Function Import(uploadFileCustomers As HttpPostedFileBase) As ActionResult
            If Not IsNothing(uploadFileCustomers) AndAlso uploadFileCustomers.ContentLength > 0 Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(uploadFileCustomers.FileName).ToLower
                If fileExt = ".txt" Then
                    Dim ih As New ImportHelper(_db)
                    Dim b(uploadFileCustomers.ContentLength) As Byte
                    uploadFileCustomers.InputStream.Read(b, 0, uploadFileCustomers.ContentLength)
                    If ih.Customer(System.Text.Encoding.ASCII.GetString(b)) Then
                        Return RedirectToAction("index")
                    Else
                        ViewBag.error = "Errore durante l'importazione del file"
                        Return View()
                    End If
                Else
                    ViewBag.error = "Sono ammmessi solo file .txt"
                    Return View()
                End If

            Else
                Return View()
            End If
        End Function

        <HttpGet> _
        Function GetCustomersByName(searchText As String) As ActionResult
            Return Json(_db.Customers.Where(Function(x) x.Name.Contains(searchText)).Select(Function(x) New With {.id = x.ID, .name = x.Name}).ToList, JsonRequestBehavior.AllowGet)
        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


    End Class
End Namespace
