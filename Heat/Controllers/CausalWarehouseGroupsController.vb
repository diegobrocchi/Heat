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
    Public Class CausalWarehouseGroupsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: CausalWarehouseGroups
        Function Index() As ActionResult
            Return View(db.CausalWarehouseGroups.ToList())
        End Function

        ' GET: CausalWarehouseGroups/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalWarehouseGroup As CausalWarehouseGroup = db.CausalWarehouseGroups.Find(id)
            If IsNothing(causalWarehouseGroup) Then
                Return HttpNotFound()
            End If
            Return View(causalWarehouseGroup)
        End Function

        ' GET: CausalWarehouseGroups/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CausalWarehouseGroups/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Description")> ByVal causalWarehouseGroup As CausalWarehouseGroup) As ActionResult
            If ModelState.IsValid Then
                db.CausalWarehouseGroups.Add(causalWarehouseGroup)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(causalWarehouseGroup)
        End Function

        ' GET: CausalWarehouseGroups/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalWarehouseGroup As CausalWarehouseGroup = db.CausalWarehouseGroups.Find(id)
            If IsNothing(causalWarehouseGroup) Then
                Return HttpNotFound()
            End If
            Return View(causalWarehouseGroup)
        End Function

        ' POST: CausalWarehouseGroups/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Description")> ByVal causalWarehouseGroup As CausalWarehouseGroup) As ActionResult
            If ModelState.IsValid Then
                db.Entry(causalWarehouseGroup).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(causalWarehouseGroup)
        End Function

        ' GET: CausalWarehouseGroups/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalWarehouseGroup As CausalWarehouseGroup = db.CausalWarehouseGroups.Find(id)
            If IsNothing(causalWarehouseGroup) Then
                Return HttpNotFound()
            End If
            Return View(causalWarehouseGroup)
        End Function

        ' POST: CausalWarehouseGroups/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim causalWarehouseGroup As CausalWarehouseGroup = db.CausalWarehouseGroups.Find(id)
            db.CausalWarehouseGroups.Remove(causalWarehouseGroup)
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
