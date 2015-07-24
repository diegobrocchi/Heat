Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat.Models
Imports Heat.Repositories
Imports Heat.ViewModels

Namespace Controllers
    Public Class InvoiceRowsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _modelBuilder As InvoiceModelBuilder

        Sub New(context As IHeatDBContext)
            _db = context
            _modelBuilder = New InvoiceModelBuilder(_db)

        End Sub
        ' GET: InvoiceRows
        Function Index() As ActionResult
            Return View(_db.InvoiceRows.ToList())
        End Function

        ' GET: InvoiceRows/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoiceRow As InvoiceRow = _db.InvoiceRows.Find(id)
            If IsNothing(invoiceRow) Then
                Return HttpNotFound()
            End If
            Return View(invoiceRow)
        End Function

        ' GET: InvoiceRows/Create
        Function Create(invoiceID As Integer) As ActionResult
            Dim invoiceRow As AddNewInvoiceRowViewModel
            invoiceRow = _modelBuilder.GetAddInvoiceRowViewModel(invoiceID)


            Return View(invoiceRow)
        End Function

        ' POST: InvoiceRows/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(invoiceRow As AddNewInvoiceRowViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim invoiceRowDB As New InvoiceRow
                invoiceRowDB.Invoice = _db.Invoices.Find(invoiceRow.InvoiceID)
                If _db.InvoiceRows.Where(Function(x) x.Invoice.ID = invoiceRow.InvoiceID).Count > 0 Then
                    invoiceRowDB.ItemOrder = _db.InvoiceRows.Where(Function(x) x.Invoice.ID = invoiceRow.InvoiceID).Max(Function(x) x.ItemOrder) + 1
                Else
                    invoiceRowDB.ItemOrder = 1
                End If
                invoiceRowDB.Product = _db.Products.Find(invoiceRow.ProductID)
                invoiceRowDB.Quantity = invoiceRow.Quantity
                invoiceRowDB.RateDiscount1 = invoiceRow.Discount1
                invoiceRowDB.RateDiscount2 = invoiceRow.Discount2
                invoiceRowDB.RateDiscount3 = invoiceRow.Discount3
                invoiceRowDB.UnitPrice = invoiceRow.UnitPrice
                invoiceRowDB.VAT_Rate = invoiceRow.VAT


                _db.InvoiceRows.Add(invoiceRowDB)
                _db.SaveChanges()
                Return RedirectToAction("edit", "invoices", New With {.ID = invoiceRow.InvoiceID})
            Else
                ViewBag.message = "Errore nel salvataggio della riga"
                Return View("error")
            End If

        End Function

        ' GET: InvoiceRows/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoiceRow As InvoiceRow = _db.InvoiceRows.Find(id)
            If IsNothing(invoiceRow) Then
                Return HttpNotFound()
            End If
            Return View(invoiceRow)
        End Function

        ' POST: InvoiceRows/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,RowID,ItemOrder,Quantity,UnitPrice,VAT_Rate,RateDiscount1,RateDiscount2,RateDiscount3")> ByVal invoiceRow As InvoiceRow) As ActionResult
            If ModelState.IsValid Then
                '_db.Entry(invoiceRow).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(invoiceRow)
        End Function

        ' GET: InvoiceRows/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoiceRow As InvoiceRow = _db.InvoiceRows.Find(id)
            If IsNothing(invoiceRow) Then
                Return HttpNotFound()
            End If
            Return View(invoiceRow)
        End Function

        ' POST: InvoiceRows/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim invoiceRow As InvoiceRow = _db.InvoiceRows.Find(id)
            _db.InvoiceRows.Remove(invoiceRow)
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
