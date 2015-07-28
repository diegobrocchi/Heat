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
    <OutputCache(duration:=0, NoStore:=True, varybyParam:="*")> _
    Public Class InvoicesController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _modelBuilder As InvoiceModelBuilder
        Private _businessService As InvoiceManager

        Sub New(context As IHeatDBContext)
            _db = context

            _modelBuilder = New InvoiceModelBuilder(_db)
            _businessService = New InvoiceManager(_db)
        End Sub

        ' GET: Invoices
        Function Index(Optional state As DocumentState = DocumentState.Confirmed) As ActionResult

            Select Case state
                Case DocumentState.Inserted
                    Return View("insertedIndex", _modelBuilder.GetInsertedInvoicesIndexViewModel)
                Case DocumentState.Confirmed
                    Return View("confirmedIndex", _modelBuilder.GetConfirmedInvoicesIndexViewModel)
                Case DocumentState.Deleted
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                Case Else
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End Select

        End Function

        <HttpGet> _
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoice As Invoice = _db.Invoices.Find(id)
            If IsNothing(invoice) Then
                Return HttpNotFound()
            End If

            Dim model As InvoiceDetailsViewModel
            model = _modelBuilder.GetDetailsInvoiceViewModel(id)
            Return View(model)
        End Function

        <HttpGet> _
        Function SelectCustomer() As ActionResult

            Return View()

        End Function

        <HttpPost> _
        Function SelectCustomer(id As Integer) As ActionResult
            Return RedirectToAction("create", New With {.customerID = id})
        End Function

        <HttpGet()> _
        Function Create(customerID As Integer) As ActionResult
            'La creazione di una fattura passa per:
            '1: creazione documento con numerazione temporanea
            '2: salvataggio del contesto, per persistere i numeratori
            '3: modifica del documento appena creato (aggiunta righe)

            Dim tmpDoc As Invoice

            tmpDoc = _businessService.GetTemporaryDocument(customerID)
            _db.SaveChanges()

            Return RedirectToAction("Edit", New With {.id = tmpDoc.ID})
        End Function


        <HttpGet> _
        Function Edit(ByVal id As Integer?) As ActionResult
            'secondo passo della creazione della fattura: aggiunta righe
            'la funzione è chiamata solo da GET per permettere l'aggiornamento
            'faciel della view durante l'immissione delle righe.

            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim invoice As Invoice = _db.Invoices.Include(Function(i) i.Customer).Where(Function(i) i.ID = id).Single

            If IsNothing(invoice) Then
                Return HttpNotFound()
            End If

            Dim validator As New EditableInvoiceValidator(_db, id)

            If validator.IsValid Then
                Dim model As EditInvoiceViewModel
                model = _modelBuilder.GetEditInvoiceViewModel(invoice)
                Return View(model)
            Else
                ViewBag.message = validator.ErrorMessage
                Return View("Error")
            End If
        End Function

        <HttpGet> _
        Public Function EditPayment(ID As Integer) As ActionResult
            Dim model As InvoicePaymentViewModel

            model = _modelBuilder.getEditInvoicePaymentViewModel(ID)

            Return View(model)
        End Function

        <HttpPost> _
        Public Function EditPayment(model As InvoicePaymentViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim dbInvoice As Invoice
                dbInvoice = _db.Invoices.Find(model.ID)

                dbInvoice.IsTaxExempt = model.IsTaxExempt
                dbInvoice.Payment = _db.Payments.Find(model.PaymentID)
                dbInvoice.TaxExemption = model.TaxExemption

                _db.SaveChanges()

                Return RedirectToAction("Confirm", New With {.id = model.ID})
            Else
                ViewBag.message = "Impossibile salvare il modello"
                Return View("error")
            End If
        End Function

        <HttpGet> _
        Public Function Confirm(ID As Integer) As ActionResult
            Dim model As ConfirmInvoiceViewModel

            Try
                model = _modelBuilder.getConfirmInvoiceViewModel(ID)

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")

            End Try
        End Function

        <HttpPost> _
        <ValidateAntiForgeryToken> _
        Public Function Confirm(invoice As EditInvoiceViewModel) As ActionResult
            'L'azione POST su Confirm è la conferma del documento e la attribuzione dello stato 'Confirmed'
            'Cerco la fattura con ID specificato,
            'se State = DocumentState.Inserted confermo l'inserimento.

            If ModelState.IsValid Then
                Dim validator As New EditableInvoiceValidator(_db, invoice.ID)

                If validator.IsValid Then
                    If _businessService.SetConfirmedDocument(invoice.ID) Then

                        _db.SaveChanges()

                        Return RedirectToAction("Index")

                    Else

                        ViewBag.message = "Impossibile confermare il documento"
                        Return View("Error")
                    End If
                Else
                    ViewBag.message = "Il documento non è in uno stato che ammette la conferma."
                    Return View("error")
                End If

            Else

                ViewBag.message = "Il documento non è editabile: impossibile confermare il documento!"
                Return View("error")
            End If
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

        ''' <summary>
        ''' prepara il modello per l'aggiunta di una riga alla fattura 
        ''' </summary>
        ''' <param name="invoiceID">ID della fattura</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <HttpGet> _
        Public Function addNewRow(invoiceID As Integer) As ActionResult
            'Dim invoiceRow As AddNewInvoiceRowViewModel
            'invoiceRow = _modelBuilder.GetAddInvoiceRowViewModel(invoiceID)

            'Return PartialView("partials/_addInvoiceRows", invoiceRow)
        End Function

        '<HttpPost> _
        'Public Function addNewRow(newRow As AddNewInvoiceRowViewModel) As ActionResult
        '    If ModelState.IsValid Then
        '        Dim newDBRow As New InvoiceRow
        '        newDBRow.Invoice = _db.Invoices.Find(newRow.InvoiceID)
        '        newDBRow.ItemOrder = _db.InvoiceRows.Where(Function(x) x.Invoice.ID = newRow.InvoiceID).Max(Function(x) x.ItemOrder) + 1
        '        newDBRow.Product = _db.Products.Find(newRow.ProductID)
        '        newDBRow.Quantity = newRow.Quantity
        '        newDBRow.UnitPrice = newRow.UnitPrice
        '        newDBRow.RateDiscount1 = newRow.Discount1
        '        newDBRow.RateDiscount2 = newRow.Discount2
        '        newDBRow.RateDiscount3 = newRow.Discount3
        '        newDBRow.VAT_Rate = newRow.VAT

        '        _db.InvoiceRows.Add(newDBRow)

        '        _db.SaveChanges()

        '        Return RedirectToAction("edit", New With {.id = newRow.InvoiceID})

        '    Else
        '        ViewBag.message = "Errore nel salvataggio della riga"
        '        Return View("error")
        '    End If
        'End Function



    End Class
End Namespace
