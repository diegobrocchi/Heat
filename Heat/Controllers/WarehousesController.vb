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
    Public Class WarehousesController
        Inherits System.Web.Mvc.Controller

        Private _db As HeatDBContext

        Public Sub New(context As IHeatDBContext)
            _db = context
        End Sub


        ' GET: Warehouses
        Function Index() As ActionResult
            Return View(_db.Warehouses.ToList())
        End Function

        ' GET: Warehouses/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim warehouse As Warehouse = _db.Warehouses.Find(id)
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
        Function Create(<Bind(Include:="ID,Code,Description,HasValue")> ByVal warehouse As Warehouse) As ActionResult
            If ModelState.IsValid Then
                _db.Warehouses.Add(warehouse)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(warehouse)
        End Function

        ' GET: Warehouses/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim warehouse As Warehouse = _db.Warehouses.Find(id)
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
        Function Edit(<Bind(Include:="ID,Code,Description,HasValue")> ByVal warehouse As Warehouse) As ActionResult
            If ModelState.IsValid Then
                _db.Entry(warehouse).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(warehouse)
        End Function

        ' GET: Warehouses/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim warehouse As Warehouse = _db.Warehouses.Find(id)
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
            Dim warehouse As Warehouse = _db.Warehouses.Find(id)
            _db.Warehouses.Remove(warehouse)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
