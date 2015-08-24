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

Namespace Controllers
    Public Class OperationsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Operations
        Function Index() As ActionResult
            Return View(db.Operations.ToList())
        End Function

        ' GET: Operations/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim operation As Operation = db.Operations.Find(id)
            If IsNothing(operation) Then
                Return HttpNotFound()
            End If
            Return View(operation)
        End Function

        ' GET: Operations/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Operations/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Description")> ByVal operation As Operation) As ActionResult
            If ModelState.IsValid Then
                db.Operations.Add(operation)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(operation)
        End Function

        ' GET: Operations/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim operation As Operation = db.Operations.Find(id)
            If IsNothing(operation) Then
                Return HttpNotFound()
            End If
            Return View(operation)
        End Function

        ' POST: Operations/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Description")> ByVal operation As Operation) As ActionResult
            If ModelState.IsValid Then
                db.Entry(operation).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(operation)
        End Function

        ' GET: Operations/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim operation As Operation = db.Operations.Find(id)
            If IsNothing(operation) Then
                Return HttpNotFound()
            End If
            Return View(operation)
        End Function

        ' POST: Operations/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim operation As Operation = db.Operations.Find(id)
            db.Operations.Remove(operation)
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
