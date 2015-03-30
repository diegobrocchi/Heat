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
    Public Class PaymentsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Payments
        Function Index() As ActionResult
            Return View(db.Payments.ToList())
        End Function

        ' GET: Payments/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim payment As Payment = db.Payments.Find(id)
            If IsNothing(payment) Then
                Return HttpNotFound()
            End If
            Return View(payment)
        End Function

        ' GET: Payments/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Payments/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Description")> ByVal payment As Payment) As ActionResult
            If ModelState.IsValid Then
                db.Payments.Add(payment)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(payment)
        End Function

        ' GET: Payments/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim payment As Payment = db.Payments.Find(id)
            If IsNothing(payment) Then
                Return HttpNotFound()
            End If
            Return View(payment)
        End Function

        ' POST: Payments/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Description")> ByVal payment As Payment) As ActionResult
            If ModelState.IsValid Then
                db.Entry(payment).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(payment)
        End Function

        ' GET: Payments/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim payment As Payment = db.Payments.Find(id)
            If IsNothing(payment) Then
                Return HttpNotFound()
            End If
            Return View(payment)
        End Function

        ' POST: Payments/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim payment As Payment = db.Payments.Find(id)
            db.Payments.Remove(payment)
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
