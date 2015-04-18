Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat
Imports Heat.Repositories

Namespace Controllers
    Public Class NumberingsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Numerators
        Function Index() As ActionResult
            Return View(db.Numberings.ToList())
        End Function

        ' GET: Numerators/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim numbering As Numbering = db.Numberings.Find(id)
            If IsNothing(numbering) Then
                Return HttpNotFound()
            End If
            Return View(numbering)
        End Function

        ' GET: Numerators/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Numerators/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Description,LastValue")> ByVal numbering As Numbering) As ActionResult
            If ModelState.IsValid Then
                db.Numberings.Add(numbering)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(numbering)
        End Function

        ' GET: Numerators/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim numbering As Numbering = db.Numberings.Find(id)
            If IsNothing(numbering) Then
                Return HttpNotFound()
            End If
            Return View(numbering)
        End Function

        ' POST: Numerators/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Description,LastValue")> ByVal numbering As Numbering) As ActionResult
            If ModelState.IsValid Then
                db.Entry(numbering).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(numbering)
        End Function

        ' GET: Numerators/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim numbering As Numbering = db.Numberings.Find(id)
            If IsNothing(numbering) Then
                Return HttpNotFound()
            End If
            Return View(numbering)
        End Function

        ' POST: Numerators/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim numbering As Numbering = db.Numberings.Find(id)
            db.Numberings.Remove(numbering)
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
