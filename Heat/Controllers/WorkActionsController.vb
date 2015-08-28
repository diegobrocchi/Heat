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
    Public Class WorkActionsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: WorkActions
        Function Index() As ActionResult
            Dim actions = db.Actions.Include(Function(w) w.AssignedOperator).Include(Function(w) w.Customer).Include(Function(w) w.Operation).Include(Function(w) w.Type)
            Return View(actions.ToList())
        End Function

        ' GET: WorkActions/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workAction As WorkAction = db.Actions.Find(id)
            If IsNothing(workAction) Then
                Return HttpNotFound()
            End If
            Return View(workAction)
        End Function

        ' GET: WorkActions/Create
        Function Create() As ActionResult
            ViewBag.AssignedOperatorID = New SelectList(db.WorkOperators, "ID", "Name")
            ViewBag.CustomerID = New SelectList(db.Customers, "ID", "Name")
            ViewBag.OperationID = New SelectList(db.Operations, "ID", "Code")
            ViewBag.TypeID = New SelectList(db.ActionTypes, "ID", "Description")
            ViewBag.PlantID = New SelectList(db.Plants, "ID", "Code")
            Return View()
        End Function

        ' POST: WorkActions/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,CustomerID,ActionDate,OperationID,AssignedOperatorID,TypeID, PlantID")> ByVal workAction As WorkAction) As ActionResult
            If ModelState.IsValid Then
                db.Actions.Add(workAction)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AssignedOperatorID = New SelectList(db.WorkOperators, "ID", "Name", workAction.AssignedOperatorID)
            ViewBag.CustomerID = New SelectList(db.Customers, "ID", "Name", workAction.CustomerID)
            ViewBag.OperationID = New SelectList(db.Operations, "ID", "Code", workAction.OperationID)
            ViewBag.TypeID = New SelectList(db.ActionTypes, "ID", "Description", workAction.TypeID)
            ViewBag.PlantID = New SelectList(db.Plants, "ID", "Code", workAction.PlantID)
            Return View(workAction)
        End Function

        ' GET: WorkActions/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workAction As WorkAction = db.Actions.Find(id)
            If IsNothing(workAction) Then
                Return HttpNotFound()
            End If
            ViewBag.AssignedOperatorID = New SelectList(db.WorkOperators, "ID", "Name", workAction.AssignedOperatorID)
            ViewBag.CustomerID = New SelectList(db.Customers, "ID", "Name", workAction.CustomerID)
            ViewBag.OperationID = New SelectList(db.Operations, "ID", "Code", workAction.OperationID)
            ViewBag.TypeID = New SelectList(db.ActionTypes, "ID", "Description", workAction.TypeID)
            Return View(workAction)
        End Function

        ' POST: WorkActions/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,CustomerID,ActionDate,OperationID,AssignedOperatorID,TypeID")> ByVal workAction As WorkAction) As ActionResult
            If ModelState.IsValid Then
                db.Entry(workAction).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AssignedOperatorID = New SelectList(db.WorkOperators, "ID", "Name", workAction.AssignedOperatorID)
            ViewBag.CustomerID = New SelectList(db.Customers, "ID", "Name", workAction.CustomerID)
            ViewBag.OperationID = New SelectList(db.Operations, "ID", "Code", workAction.OperationID)
            ViewBag.TypeID = New SelectList(db.ActionTypes, "ID", "Description", workAction.TypeID)
            Return View(workAction)
        End Function

        ' GET: WorkActions/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workAction As WorkAction = db.Actions.Find(id)
            If IsNothing(workAction) Then
                Return HttpNotFound()
            End If
            Return View(workAction)
        End Function

        ' POST: WorkActions/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim workAction As WorkAction = db.Actions.Find(id)
            db.Actions.Remove(workAction)
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
