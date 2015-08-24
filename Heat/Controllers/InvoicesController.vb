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
Imports Heat.Manager
Imports Heat.ViewModels.Invoices

Namespace Controllers
    <OutputCache(duration:=0, NoStore:=True, varybyParam:="*")> _
    <HandleError> _
    Public Class InvoicesController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _modelBuilder As InvoiceModelBuilder
        Private _businessService As InvoiceManager

        Sub New(context As IHeatDBContext)
            _db = context

            _businessService = New InvoiceManager(_db)
            _modelBuilder = New InvoiceModelBuilder(_db, _businessService)
        End Sub

        Function Index(Optional state As DocumentState = DocumentState.Confirmed) As ActionResult
            Try
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
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try


        End Function

        <HttpGet> _
        Function Details(ByVal id As Integer?) As ActionResult
            Try
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
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpGet()> _
        Function Create(customerID As Integer) As ActionResult
            'La creazione di una fattura passa per:
            '1: creazione documento con numerazione temporanea
            '2: salvataggio del contesto, per persistere i numeratori
            '3: modifica del documento appena creato (aggiunta righe)

            Try
                Dim tmpDoc As Invoice

                tmpDoc = _businessService.GetTemporaryDocument(customerID)
                _db.SaveChanges()

                Return RedirectToAction("Edit", New With {.id = tmpDoc.ID})
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpGet> _
        Function Edit(ByVal id As Integer?) As ActionResult
            'secondo passo della creazione della fattura: aggiunta righe
            'la funzione è chiamata solo da GET per permettere l'aggiornamento
            'facile della view durante l'immissione delle righe.

            Try
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
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpGet> _
        Public Function EditPayment(ID As Integer) As ActionResult
            Try
                Dim model As InvoicePaymentViewModel

                model = _modelBuilder.getEditInvoicePaymentViewModel(ID)

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpPost> _
        Public Function EditPayment(model As InvoicePaymentViewModel) As ActionResult
            Try
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
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpGet> _
        Public Function Confirm(ID As Integer) As ActionResult

            Try
                Dim model As ConfirmInvoiceViewModel
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
            Try
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
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function


        ' GET: Invoices/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            Try
                If IsNothing(id) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                Dim invoice As Invoice = _db.Invoices.Find(id)
                If IsNothing(invoice) Then
                    Return HttpNotFound()
                End If
                If invoice.State = DocumentState.Inserted Then

                    Return View("delete", _modelBuilder.getDeleteInvoiceViewModel(id))

                Else
                    ViewBag.message = "Impossibile eliminare una fattura già confermata, o già eliminata."
                    Return View("error")
                End If
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        ' POST: Invoices/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim invoice As Invoice = _db.Invoices.Find(id)

            If IsNothing(invoice) Then
                Return HttpNotFound()
            End If

            If invoice.State = DocumentState.Inserted Then
                _db.Invoices.Remove(invoice)
                _db.SaveChanges()
            Else
                ViewBag.message = "Impossibile eliminare una fattura già confermata, o già eliminata."
            End If
            Return RedirectToAction("Index", New With {.state = DocumentState.Inserted})
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub


    End Class
End Namespace
