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
Imports Heat.ViewModels.Customers
Imports Heat.Manager

Namespace Controllers

    Public Class CustomersController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As CustomerModelViewBuilder

        Sub New(dbcontext As IHeatDBContext)
            _db = dbcontext
            _mb = New CustomerModelViewBuilder(_db)
        End Sub

        ' GET: Customers

        Function Index(Optional IncludeDisabled As Boolean = False) As ActionResult
            Dim l As List(Of Customer)
            If IncludeDisabled Then
                l = _db.Customers.OrderBy(Function(c) c.Name).ToList
            Else
                l = _db.Customers.Where(Function(c) c.IsEnabled = True).OrderBy(Function(c) c.Name).ToList
            End If

            Return View(l)

            'Dim custviewmodelb As New BusinessModelViewBuilder(_db)
            ''TODO: jQ Datatable con server processing
            'Return View(custviewmodelb.GetSortedAndPagedCustomer(sortOrder, 0, 1000))

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
                customer.IsEnabled = True
                customer.CreationDate = Now
                customer.EnableDate = Now
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
                '_db.Entry(customer).State = EntityState.Modified
                _db.SetModified(customer)
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

        <HttpGet> _
        Public Function DisableCustomer(id As Integer) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim customer As Customer = _db.Customers.Find(id)
            If IsNothing(customer) Then
                Return HttpNotFound()
            End If
            Dim dc As DisableCustomerViewModel
            dc = _mb.GetDisableCustomerViewModel(id)
            Return View(dc)
        End Function

        <HttpPost> _
        <ValidateAntiForgeryToken> _
        Public Function DisableCustomer(dc As DisableCustomerViewModel) As ActionResult
            If ModelState.IsValid Then
                Try
                    Dim cm As New CustomerManager(_db)
                    Dim c As Customer
                    c = _db.Customers.Find(dc.ID)
                    If Not IsNothing(c) Then
                        cm.DisableCustomer(c)
                        _db.SaveChanges()
                        Return RedirectToAction("index")
                    Else
                        ViewBag.message = "Impossibile trovare il cliente con ID specificato!"
                        Return View("error")
                    End If
                Catch ex As Exception
                    ViewBag.message = ex.Message
                    Return View("error")
                End Try

            Else
                ViewBag.message = "Modello non valido!"
                Return View("Error")
            End If

        End Function


        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


    End Class
End Namespace
