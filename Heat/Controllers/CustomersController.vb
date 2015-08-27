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
Imports AutoMapper
Imports iTextSharp.text
Imports iTextSharp.text.pdf



Namespace Controllers

    Public Class CustomersController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As CustomerModelViewBuilder
        Private _cm As CustomerManager

        Sub New(dbcontext As IHeatDBContext)
            _db = dbcontext
            _mb = New CustomerModelViewBuilder(_db)
            _cm = New CustomerManager(_db)
        End Sub


        Function Index(Optional IncludeDisabled As Boolean = False) As ActionResult
            Try
                Dim model As IndexCustomerViewModel
                model = _mb.GetIndexCustomerViewModel(IncludeDisabled)

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

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

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(newCustomer As CreateCustomerViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim c As New Customer
                c = Mapper.Map(Of Customer)(newCustomer)
                c.CreationDate = Now
                c.EnableDate = Now

                _db.Customers.Add(c)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            Else
                Return View(newCustomer)
            End If

        End Function

        ' GET: Customers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            Try
                If IsNothing(id) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                If Not _db.Customers.AsNoTracking.Any(Function(x) x.ID = id) Then
                    Return HttpNotFound()
                End If
                Dim model As EditCustomerViewModel
                model = _mb.GetEditCustomerViewModel(id)
                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(editedCustomer As EditCustomerViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim dbCustomer As Customer
                dbCustomer = _db.Customers.Find(editedCustomer.ID)

                Mapper.Map(editedCustomer, dbCustomer)

                _db.SaveChanges()
                Return RedirectToAction("Index")
            Else
                Return View(editedCustomer)
            End If
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


        <HttpGet> _
        Public Function EnableCustomer(id As Integer) As ActionResult
            Try
                If IsNothing(id) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                Dim customer As Customer = _db.Customers.Find(id)
                If IsNothing(customer) Then
                    Return HttpNotFound()
                End If
                Dim dc As EnableCustomerViewModel
                dc = _mb.GetEnableCustomerViewModel(id)
                Return View(dc)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpPost> _
        <ValidateAntiForgeryToken> _
        Public Function EnableCustomer(ec As EnableCustomerViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim c As Customer
                    c = _db.Customers.Find(ec.ID)
                    If Not IsNothing(c) Then
                        _cm.EnableCustomer(c)
                        _db.SaveChanges()
                        Return RedirectToAction("index")
                    Else
                        ViewBag.message = "impossibile trovare il cliente con ID specificato!"
                        Return View("error")
                    End If
                Else
                    ViewBag.message("Modello non valido")
                    Return View("error")
                End If
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("Error")
            End Try
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        <HttpGet> _
        Public Function Print(id As Integer) As ActionResult
            Dim d As New iTextSharp.text.Document
            PdfWriter.GetInstance(d, New System.IO.FileStream(Request.PhysicalApplicationPath & "\1.pdf", System.IO.FileMode.Create))
            d.Open()
            d.Add(New Paragraph("Hello " & id))
            d.Close()
            Return Redirect("~/1.pdf")

        End Function

    End Class
End Namespace
