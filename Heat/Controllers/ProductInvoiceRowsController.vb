﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat.Models
Imports Heat.Repositories
Imports Heat.ViewModels.Invoices
Imports Heat.Manager

Namespace Controllers
    Public Class ProductInvoiceRowsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _modelBuilder As InvoiceModelBuilder
        Private _manager As InvoiceManager


        Sub New(context As IHeatDBContext)
            _db = context
            _manager = New InvoiceManager(_db)
            _modelBuilder = New InvoiceModelBuilder(_db, _manager)

        End Sub
        ' GET: InvoiceRows
        Function Index() As ActionResult
            Return View(_db.ProductInvoiceRows.ToList())
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

        <HttpGet> _
        Function Create(invoiceID As Integer) As ActionResult
            Dim invoiceRow As AddNewProductInvoiceRowViewModel

            invoiceRow = _modelBuilder.GetAddProductInvoiceRowViewModel(invoiceID)

            Return View(invoiceRow)
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(invoiceRow As AddNewProductInvoiceRowViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim invoiceRowDB As New ProductInvoiceRow
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


                _db.ProductInvoiceRows.Add(invoiceRowDB)
                _db.SaveChanges()
                Return RedirectToAction("edit", "invoices", New With {.ID = invoiceRow.InvoiceID})
            Else
                ViewBag.message = "Errore nel salvataggio della riga"
                Return View("error")
            End If

        End Function


        Function Edit(ByVal id As Integer?) As ActionResult
            Try
                If IsNothing(id) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                'Dim invoiceRow As ProductInvoiceRow = _db.ProductInvoiceRows.Include(Function(x) x.Invoice).Include(Function(x) x.Product).Where(Function(x) x.ID = id).Single

                'If IsNothing(invoiceRow) Then
                '    Return HttpNotFound()
                'End If

                Dim model As New EditProductInvoiceRowViewModel

                model = _modelBuilder.GetEditProductInvoiceRowViewModel(id)

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

         
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal editedProductInvoiceRow As EditProductInvoiceRowViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim dbInvoiceRow As ProductInvoiceRow
                dbInvoiceRow = _db.ProductInvoiceRows.Find(editedProductInvoiceRow.ID)

                dbInvoiceRow.Product = _db.Products.Find(editedProductInvoiceRow.ProductID)
                dbInvoiceRow.Quantity = editedProductInvoiceRow.Quantity
                dbInvoiceRow.RateDiscount1 = editedProductInvoiceRow.Discount1
                dbInvoiceRow.RateDiscount2 = editedProductInvoiceRow.Discount2
                dbInvoiceRow.RateDiscount3 = editedProductInvoiceRow.Discount3
                dbInvoiceRow.UnitPrice = editedProductInvoiceRow.UnitPrice
                dbInvoiceRow.VAT_Rate = editedProductInvoiceRow.VAT

                _db.SetModified(dbInvoiceRow)
                _db.SaveChanges()
                Return RedirectToAction("edit", "invoices", New With {.ID = editedProductInvoiceRow.InvoiceID})
            Else
                'il modello non è valido, torna alla vista di edit.
                Return View(editedProductInvoiceRow)
            End If

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
