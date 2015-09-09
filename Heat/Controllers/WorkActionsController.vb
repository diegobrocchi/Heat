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
Imports Heat.ViewModels.WorkActions

Namespace Controllers
    Public Class WorkActionsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As WorkActionModelViewBuilder

        Sub New(dbContext As IHeatDBContext)
            _db = dbContext
            _mb = New WorkActionModelViewBuilder(_db)
        End Sub

        


        Function Index() As ActionResult
            Dim workactions = _db.WorkActions.Include(Function(w) w.AssignedOperator).Include(Function(w) w.Operation).Include(Function(w) w.Type)
            Return View(workactions.ToList())
        End Function


        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workAction As WorkAction = _db.WorkActions.Find(id)
            If IsNothing(workAction) Then
                Return HttpNotFound()
            End If
            Return View(workAction)
        End Function

         

        <HttpGet> _
        Function Create(Optional plantID As Integer = -1) As ActionResult
            Try
                Dim model As CreateWorkActionViewModel

                If plantID = -1 Then

                    model = _mb.GetCreateWorkActionViewModel

                Else
                    If Not _db.Plants.Any(Function(x) x.ID = plantID) Then
                        Return HttpNotFound()
                    End If

                    model = _mb.GetCreateWorkActionViewModel(plantID)
                End If

                'If IsNothing(plantID) Then
                '    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                'End If

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(newWorkAction As CreateWorkActionViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim wa As WorkAction
                    wa = AutoMapper.Mapper.Map(Of WorkAction)(newWorkAction)
                    wa.Plant = _db.Plants.Find(newWorkAction.PlantID)

                    _db.WorkActions.Add(wa)
                    _db.SaveChanges()

                    Return RedirectToAction("index", "plants", Nothing)
                Else

                    _mb.BindSelectListItems(newWorkAction)

                    Return View(newWorkAction)
                    
                End If
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        ' GET: WorkActions/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workAction As WorkAction = _db.WorkActions.Find(id)
            If IsNothing(workAction) Then
                Return HttpNotFound()
            End If
            ViewBag.AssignedOperatorID = New SelectList(_db.WorkOperators, "ID", "Name", workAction.AssignedOperatorID)
            'ViewBag.CustomerID = New SelectList(_db.Customers, "ID", "Name", workAction.CustomerID)
            ViewBag.OperationID = New SelectList(_db.Operations, "ID", "Code", workAction.OperationID)
            ViewBag.TypeID = New SelectList(_db.ActionTypes, "ID", "Description", workAction.TypeID)
            Return View(workAction)
        End Function

        ' POST: WorkActions/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,CustomerID,ActionDate,OperationID,AssignedOperatorID,TypeID")> ByVal workAction As WorkAction) As ActionResult
            If ModelState.IsValid Then
                '_db.Entry(workAction).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AssignedOperatorID = New SelectList(_db.WorkOperators, "ID", "Name", workAction.AssignedOperatorID)
            'ViewBag.CustomerID = New SelectList(_db.Customers, "ID", "Name", workAction.CustomerID)
            ViewBag.OperationID = New SelectList(_db.Operations, "ID", "Code", workAction.OperationID)
            ViewBag.TypeID = New SelectList(_db.ActionTypes, "ID", "Description", workAction.TypeID)
            Return View(workAction)
        End Function

        ' GET: WorkActions/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim workAction As WorkAction = _db.WorkActions.Find(id)
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
            Dim workAction As WorkAction = _db.WorkActions.Find(id)
            _db.WorkActions.Remove(workAction)
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
