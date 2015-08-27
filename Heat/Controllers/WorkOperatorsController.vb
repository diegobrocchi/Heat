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
    Public Class WorkOperatorsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: WorkOperators
        Function Index() As ActionResult
            Return View(db.WorkOperators.ToList())
        End Function

        ' GET: WorkOperators/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workOperator As WorkOperator = db.WorkOperators.Find(id)
            If IsNothing(workOperator) Then
                Return HttpNotFound()
            End If
            Return View(workOperator)
        End Function

        ' GET: WorkOperators/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: WorkOperators/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name")> ByVal workOperator As WorkOperator) As ActionResult
            If ModelState.IsValid Then
                db.WorkOperators.Add(workOperator)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(workOperator)
        End Function

        ' GET: WorkOperators/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workOperator As WorkOperator = db.WorkOperators.Find(id)
            If IsNothing(workOperator) Then
                Return HttpNotFound()
            End If
            Return View(workOperator)
        End Function

        ' POST: WorkOperators/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name")> ByVal workOperator As WorkOperator) As ActionResult
            If ModelState.IsValid Then
                db.Entry(workOperator).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(workOperator)
        End Function

        ' GET: WorkOperators/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workOperator As WorkOperator = db.WorkOperators.Find(id)
            If IsNothing(workOperator) Then
                Return HttpNotFound()
            End If
            Return View(workOperator)
        End Function

        ' POST: WorkOperators/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim workOperator As WorkOperator = db.WorkOperators.Find(id)
            db.WorkOperators.Remove(workOperator)
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
