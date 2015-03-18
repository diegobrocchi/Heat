Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat

Namespace Controllers
    <Authorize> _
    Public Class PlantTypesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: PlantTypes
        Function Index() As ActionResult
            Return View(db.PlantTypes.ToList())
        End Function

        ' GET: PlantTypes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantType As PlantType = db.PlantTypes.Find(id)
            If IsNothing(plantType) Then
                Return HttpNotFound()
            End If
            Return View(plantType)
        End Function

        ' GET: PlantTypes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: PlantTypes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name")> ByVal plantType As PlantType) As ActionResult
            If ModelState.IsValid Then
                db.PlantTypes.Add(plantType)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(plantType)
        End Function

        ' GET: PlantTypes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantType As PlantType = db.PlantTypes.Find(id)
            If IsNothing(plantType) Then
                Return HttpNotFound()
            End If
            Return View(plantType)
        End Function

        ' POST: PlantTypes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name")> ByVal plantType As PlantType) As ActionResult
            If ModelState.IsValid Then
                db.Entry(plantType).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(plantType)
        End Function

        ' GET: PlantTypes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantType As PlantType = db.PlantTypes.Find(id)
            If IsNothing(plantType) Then
                Return HttpNotFound()
            End If
            Return View(plantType)
        End Function

        ' POST: PlantTypes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim plantType As PlantType = db.PlantTypes.Find(id)
            db.PlantTypes.Remove(plantType)
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
