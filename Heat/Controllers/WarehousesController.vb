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
    Public Class WarehousesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Warehouses
        Function Index() As ActionResult
            Return View(db.Warehouses.ToList())
        End Function

        ' GET: Warehouses/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim warehouse As Warehouse = db.Warehouses.Find(id)
            If IsNothing(warehouse) Then
                Return HttpNotFound()
            End If
            Return View(warehouse)
        End Function

        ' GET: Warehouses/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Warehouses/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Descrition,HasValue")> ByVal warehouse As Warehouse) As ActionResult
            If ModelState.IsValid Then
                db.Warehouses.Add(warehouse)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(warehouse)
        End Function

        ' GET: Warehouses/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim warehouse As Warehouse = db.Warehouses.Find(id)
            If IsNothing(warehouse) Then
                Return HttpNotFound()
            End If
            Return View(warehouse)
        End Function

        ' POST: Warehouses/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Descrition,HasValue")> ByVal warehouse As Warehouse) As ActionResult
            If ModelState.IsValid Then
                db.Entry(warehouse).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(warehouse)
        End Function

        ' GET: Warehouses/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim warehouse As Warehouse = db.Warehouses.Find(id)
            If IsNothing(warehouse) Then
                Return HttpNotFound()
            End If
            Return View(warehouse)
        End Function

        ' POST: Warehouses/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim warehouse As Warehouse = db.Warehouses.Find(id)
            db.Warehouses.Remove(warehouse)
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
