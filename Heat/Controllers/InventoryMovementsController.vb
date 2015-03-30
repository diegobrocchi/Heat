﻿Imports System
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
    Public Class WarehouseMovementsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: InventoryMovements
        Function Index() As ActionResult
            Return View(db.WarehouseMovement.ToList())
        End Function

        ' GET: InventoryMovements/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim inventoryMovement As WarehouseMovement = db.WarehouseMovement.Find(id)
            If IsNothing(inventoryMovement) Then
                Return HttpNotFound()
            End If
            Return View(inventoryMovement)
        End Function

        ' GET: InventoryMovements/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: InventoryMovements/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Quantity,ExecDate,Note")> ByVal inventoryMovement As WarehouseMovement) As ActionResult
            If ModelState.IsValid Then
                db.WarehouseMovement.Add(inventoryMovement)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(inventoryMovement)
        End Function

        ' GET: InventoryMovements/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim inventoryMovement As WarehouseMovement = db.WarehouseMovement.Find(id)
            If IsNothing(inventoryMovement) Then
                Return HttpNotFound()
            End If
            Return View(inventoryMovement)
        End Function

        ' POST: InventoryMovements/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Quantity,ExecDate,Note")> ByVal inventoryMovement As WarehouseMovement) As ActionResult
            If ModelState.IsValid Then
                db.Entry(inventoryMovement).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(inventoryMovement)
        End Function

        ' GET: InventoryMovements/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim inventoryMovement As WarehouseMovement = db.WarehouseMovement.Find(id)
            If IsNothing(inventoryMovement) Then
                Return HttpNotFound()
            End If
            Return View(inventoryMovement)
        End Function

        ' POST: InventoryMovements/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim inventoryMovement As WarehouseMovement = db.WarehouseMovement.Find(id)
            db.WarehouseMovement.Remove(inventoryMovement)
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
