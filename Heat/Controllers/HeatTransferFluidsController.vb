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
    Public Class HeatTransferFluidsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: HeatTransferFluids
        Function Index() As ActionResult
            Return View(db.HeatTransferFluids.ToList())
        End Function

        ' GET: HeatTransferFluids/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim heatTransferFluid As HeatTransferFluid = db.HeatTransferFluids.Find(id)
            If IsNothing(heatTransferFluid) Then
                Return HttpNotFound()
            End If
            Return View(heatTransferFluid)
        End Function

        ' GET: HeatTransferFluids/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: HeatTransferFluids/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name")> ByVal heatTransferFluid As HeatTransferFluid) As ActionResult
            If ModelState.IsValid Then
                db.HeatTransferFluids.Add(heatTransferFluid)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(heatTransferFluid)
        End Function

        ' GET: HeatTransferFluids/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim heatTransferFluid As HeatTransferFluid = db.HeatTransferFluids.Find(id)
            If IsNothing(heatTransferFluid) Then
                Return HttpNotFound()
            End If
            Return View(heatTransferFluid)
        End Function

        ' POST: HeatTransferFluids/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name")> ByVal heatTransferFluid As HeatTransferFluid) As ActionResult
            If ModelState.IsValid Then
                db.Entry(heatTransferFluid).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(heatTransferFluid)
        End Function

        ' GET: HeatTransferFluids/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim heatTransferFluid As HeatTransferFluid = db.HeatTransferFluids.Find(id)
            If IsNothing(heatTransferFluid) Then
                Return HttpNotFound()
            End If
            Return View(heatTransferFluid)
        End Function

        ' POST: HeatTransferFluids/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim heatTransferFluid As HeatTransferFluid = db.HeatTransferFluids.Find(id)
            db.HeatTransferFluids.Remove(heatTransferFluid)
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
