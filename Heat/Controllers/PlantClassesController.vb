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
    <Authorize> _
    Public Class PlantClassesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: PlantClasses
        Function Index() As ActionResult
            Return View(db.PlantClasses.ToList())
        End Function

        ' GET: PlantClasses/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantClass As PlantClass = db.PlantClasses.Find(id)
            If IsNothing(plantClass) Then
                Return HttpNotFound()
            End If
            Return View(plantClass)
        End Function

        ' GET: PlantClasses/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: PlantClasses/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name")> ByVal plantClass As PlantClass) As ActionResult
            If ModelState.IsValid Then
                db.PlantClasses.Add(plantClass)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(plantClass)
        End Function

        ' GET: PlantClasses/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantClass As PlantClass = db.PlantClasses.Find(id)
            If IsNothing(plantClass) Then
                Return HttpNotFound()
            End If
            Return View(plantClass)
        End Function

        ' POST: PlantClasses/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name")> ByVal plantClass As PlantClass) As ActionResult
            If ModelState.IsValid Then
                db.Entry(plantClass).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(plantClass)
        End Function

        ' GET: PlantClasses/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantClass As PlantClass = db.PlantClasses.Find(id)
            If IsNothing(plantClass) Then
                Return HttpNotFound()
            End If
            Return View(plantClass)
        End Function

        ' POST: PlantClasses/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim plantClass As PlantClass = db.PlantClasses.Find(id)
            db.PlantClasses.Remove(plantClass)
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
