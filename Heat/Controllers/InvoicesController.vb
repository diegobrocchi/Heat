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
Imports Heat.Viewmodels
Imports Heat.Manager

Namespace Controllers
    Public Class InvoicesController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private modelBuilder As InvoiceModelBuilder
        Private _businessService As InvoiceManager

        Sub New(context As IHeatDBContext)
            _db = context

            modelBuilder = New InvoiceModelBuilder(_db)
            _businessService = New InvoiceManager(_db)
        End Sub

        ' GET: Invoices
        Function Index() As ActionResult
            Return View(_db.Invoices.ToList())
        End Function

        ' GET: Invoices/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoice As Invoice = _db.Invoices.Find(id)
            If IsNothing(invoice) Then
                Return HttpNotFound()
            End If
            Return View(invoice)
        End Function

        ' GET: Invoices/Create
        Function Create(customerID As Integer) As ActionResult
            Dim ivm As InvoiceCreateViewModel
            Dim tmpDoc As Invoice

            tmpDoc = _businessService.GetTemporaryDocument(customerID)
            ivm = modelBuilder.GetInvoiceCreateViewModel(tmpDoc)

            _db.SaveChanges()

            Return View(ivm)
        End Function

        ' POST: Invoices/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,DocNumber,Sum")> ByVal invoice As Invoice) As ActionResult
            If ModelState.IsValid Then

                _businessService.Insert(invoice)

                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(invoice)
        End Function

        ' GET: Invoices/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoice As Invoice = _db.Invoices.Find(id)
            If IsNothing(invoice) Then
                Return HttpNotFound()
            End If
            Return View(invoice)
        End Function

        ' POST: Invoices/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,DocNumber,Sum")> ByVal invoice As Invoice) As ActionResult
            If ModelState.IsValid Then
                _db.SetModified(invoice)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(invoice)
        End Function

        ' GET: Invoices/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoice As Invoice = _db.Invoices.Find(id)
            If IsNothing(invoice) Then
                Return HttpNotFound()
            End If
            Return View(invoice)
        End Function

        ' POST: Invoices/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim invoice As Invoice = _db.Invoices.Find(id)
            _db.Invoices.Remove(invoice)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
