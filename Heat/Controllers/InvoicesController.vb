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

Namespace Controllers
    Public Class InvoicesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Invoices
        Function Index() As ActionResult
            Return View(db.Invoices.ToList())
        End Function

        ' GET: Invoices/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoice As Invoice = db.Invoices.Find(id)
            If IsNothing(invoice) Then
                Return HttpNotFound()
            End If
            Return View(invoice)
        End Function

        ' GET: Invoices/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Invoices/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,DocNumber,Sum")> ByVal invoice As Invoice) As ActionResult
            If ModelState.IsValid Then
                db.Invoices.Add(invoice)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(invoice)
        End Function

        ' GET: Invoices/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoice As Invoice = db.Invoices.Find(id)
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
                db.Entry(invoice).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(invoice)
        End Function

        ' GET: Invoices/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim invoice As Invoice = db.Invoices.Find(id)
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
            Dim invoice As Invoice = db.Invoices.Find(id)
            db.Invoices.Remove(invoice)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
