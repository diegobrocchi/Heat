Imports System
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
Imports System.Security.Claims
Imports log4net
 
Namespace Controllers
    Public Class FuelsController
        Inherits System.Web.Mvc.Controller

        Public db As New HeatDBContext
         
        ' GET: Fuels
        '<Authorize(roles:="canViewFuels")> _
        <ClaimsAutorize(ClaimTypes.Name, "demo")> _
        Function Index() As ActionResult
            Return View(db.Fuels.ToList())
        End Function

        ' GET: Fuels/Details/5
        <ResourceAuthorize(ResourceOperations.ReadOwn, "FuelDetail")> _
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fuel As Fuel = db.Fuels.Find(id)
            If IsNothing(fuel) Then
                Return HttpNotFound()
            End If
            Return View(fuel)
        End Function

        ' GET: Fuels/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Fuels/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name")> ByVal fuel As Fuel) As ActionResult
            If ModelState.IsValid Then
                db.Fuels.Add(fuel)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(fuel)
        End Function

        ' GET: Fuels/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fuel As Fuel = db.Fuels.Find(id)
            If IsNothing(fuel) Then
                Return HttpNotFound()
            End If
            Return View(fuel)
        End Function

        ' POST: Fuels/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name")> ByVal fuel As Fuel) As ActionResult
            If ModelState.IsValid Then
                db.Entry(fuel).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(fuel)
        End Function

        ' GET: Fuels/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim fuel As Fuel = db.Fuels.Find(id)
            If IsNothing(fuel) Then
                Return HttpNotFound()
            End If
            Return View(fuel)
        End Function

        ' POST: Fuels/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim fuel As Fuel = db.Fuels.Find(id)
            db.Fuels.Remove(fuel)
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
