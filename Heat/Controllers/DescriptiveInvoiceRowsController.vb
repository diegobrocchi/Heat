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
Imports Heat.Manager
Imports Heat.ViewModels.Invoices

Namespace Controllers
    Public Class DescriptiveInvoiceRowsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _modelBuilder As InvoiceModelBuilder
        Private _manager As InvoiceManager

        Sub New(context As IHeatDBContext)
            _db = context
            _manager = New InvoiceManager(_db)
            _modelBuilder = New InvoiceModelBuilder(_db, _manager)

        End Sub

        ' GET: DescriptiveInvoiceRows
        Function Index() As ActionResult
            Return View(_db.DescriptiveInvoiceRows.ToList())
        End Function

        ' GET: DescriptiveInvoiceRows/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim descriptiveInvoiceRow As DescriptiveInvoiceRow = _db.InvoiceRows.Find(id)
            If IsNothing(descriptiveInvoiceRow) Then
                Return HttpNotFound()
            End If
            Return View(descriptiveInvoiceRow)
        End Function

        ' GET: DescriptiveInvoiceRows/Create
        Function Create(invoiceID As Integer) As ActionResult
            Dim invoiceRow As AddNewDescriptiveInvoiceRowViewModel

            invoiceRow = _modelBuilder.GetAddDescriptiveInvoiceRowViewModel(invoiceID)
            Return View(invoiceRow)
        End Function

        <HttpPost()>
       <ValidateAntiForgeryToken()>
        Function Create(descriptiveInvoiceRow As AddNewDescriptiveInvoiceRowViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim invoiceRowDB As New DescriptiveInvoiceRow
                invoiceRowDB.Invoice = _db.Invoices.Find(descriptiveInvoiceRow.InvoiceID)

                If _db.InvoiceRows.Where(Function(x) x.Invoice.ID = descriptiveInvoiceRow.InvoiceID).Count > 0 Then
                    invoiceRowDB.ItemOrder = _db.InvoiceRows.Where(Function(x) x.Invoice.ID = descriptiveInvoiceRow.InvoiceID).Max(Function(x) x.ItemOrder) + 1
                Else
                    invoiceRowDB.ItemOrder = 1
                End If

                invoiceRowDB.RowDescription = descriptiveInvoiceRow.RowDescription
                invoiceRowDB.Quantity = descriptiveInvoiceRow.Quantity
                invoiceRowDB.RateDiscount1 = descriptiveInvoiceRow.Discount1
                invoiceRowDB.RateDiscount2 = descriptiveInvoiceRow.Discount2
                invoiceRowDB.RateDiscount3 = descriptiveInvoiceRow.Discount3
                invoiceRowDB.UnitPrice = descriptiveInvoiceRow.UnitPrice
                invoiceRowDB.VAT_Rate = descriptiveInvoiceRow.VAT


                _db.InvoiceRows.Add(invoiceRowDB)
                _db.SaveChanges()
                Return RedirectToAction("edit", "invoices", New With {.ID = descriptiveInvoiceRow.InvoiceID})

            End If
            Return View(descriptiveInvoiceRow)
        End Function

        ' GET: DescriptiveInvoiceRows/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            Try
                If IsNothing(id) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                'Dim descriptiveInvoiceRow As DescriptiveInvoiceRow = _db.InvoiceRows.Find(id)
                'If IsNothing(descriptiveInvoiceRow) Then
                '    Return HttpNotFound()
                'End If
                Dim model As EditDescriptiveInvoiceRowViewModel
                model = _modelBuilder.GetEditDescriptiveInvoiceRowViewModel(id)
                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(editedDescriptiveInvoiceRow As EditDescriptiveInvoiceRowViewModel) As ActionResult

            If ModelState.IsValid Then
                Dim dbRow As DescriptiveInvoiceRow
                dbRow = _db.DescriptiveInvoiceRows.Find(editedDescriptiveInvoiceRow.ID)

                dbRow.Quantity = editedDescriptiveInvoiceRow.Quantity
                dbRow.RateDiscount1 = editedDescriptiveInvoiceRow.Discount1
                dbRow.RateDiscount2 = editedDescriptiveInvoiceRow.Discount2
                dbRow.RateDiscount3 = editedDescriptiveInvoiceRow.Discount3
                dbRow.RowDescription = editedDescriptiveInvoiceRow.RowDescription
                dbRow.UnitPrice = editedDescriptiveInvoiceRow.UnitPrice
                dbRow.VAT_Rate = editedDescriptiveInvoiceRow.VAT


                _db.SaveChanges()
                Return RedirectToAction("edit", "invoices", New With {.id = editedDescriptiveInvoiceRow.InvoiceID})
            Else
                'il modello non è valido, torna alla vista di edit.
                Return View(editedDescriptiveInvoiceRow)
            End If

        End Function

        ' GET: DescriptiveInvoiceRows/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim descriptiveInvoiceRow As DescriptiveInvoiceRow = _db.InvoiceRows.Find(id)
            If IsNothing(descriptiveInvoiceRow) Then
                Return HttpNotFound()
            End If
            Return View(descriptiveInvoiceRow)
        End Function

        ' POST: DescriptiveInvoiceRows/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim descriptiveInvoiceRow As DescriptiveInvoiceRow = _db.InvoiceRows.Find(id)
            _db.InvoiceRows.Remove(descriptiveInvoiceRow)
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
