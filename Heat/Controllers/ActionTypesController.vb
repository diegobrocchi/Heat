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
    Public Class ActionTypesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: ActionTypes
        Function Index() As ActionResult
            Return View(db.ActionTypes.ToList())
        End Function

        ' GET: ActionTypes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim actionType As ActionType = db.ActionTypes.Find(id)
            If IsNothing(actionType) Then
                Return HttpNotFound()
            End If
            Return View(actionType)
        End Function

        ' GET: ActionTypes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: ActionTypes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Description")> ByVal actionType As ActionType) As ActionResult
            If ModelState.IsValid Then
                db.ActionTypes.Add(actionType)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(actionType)
        End Function

        ' GET: ActionTypes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim actionType As ActionType = db.ActionTypes.Find(id)
            If IsNothing(actionType) Then
                Return HttpNotFound()
            End If
            Return View(actionType)
        End Function

        ' POST: ActionTypes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Description")> ByVal actionType As ActionType) As ActionResult
            If ModelState.IsValid Then
                db.Entry(actionType).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(actionType)
        End Function

        ' GET: ActionTypes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim actionType As ActionType = db.ActionTypes.Find(id)
            If IsNothing(actionType) Then
                Return HttpNotFound()
            End If
            Return View(actionType)
        End Function

        ' POST: ActionTypes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim actionType As ActionType = db.ActionTypes.Find(id)
            db.ActionTypes.Remove(actionType)
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
