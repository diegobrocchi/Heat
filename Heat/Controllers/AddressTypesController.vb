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
    Public Class AddressTypesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: AddressTypes
        Function Index() As ActionResult
            Return View(db.AddressTypes.ToList())
        End Function

        ' GET: AddressTypes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim addressType As AddressType = db.AddressTypes.Find(id)
            If IsNothing(addressType) Then
                Return HttpNotFound()
            End If
            Return View(addressType)
        End Function

        ' GET: AddressTypes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: AddressTypes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Description")> ByVal addressType As AddressType) As ActionResult
            If ModelState.IsValid Then
                db.AddressTypes.Add(addressType)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(addressType)
        End Function

        ' GET: AddressTypes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim addressType As AddressType = db.AddressTypes.Find(id)
            If IsNothing(addressType) Then
                Return HttpNotFound()
            End If
            Return View(addressType)
        End Function

        ' POST: AddressTypes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Description")> ByVal addressType As AddressType) As ActionResult
            If ModelState.IsValid Then
                db.Entry(addressType).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(addressType)
        End Function

        ' GET: AddressTypes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim addressType As AddressType = db.AddressTypes.Find(id)
            If IsNothing(addressType) Then
                Return HttpNotFound()
            End If
            Return View(addressType)
        End Function

        ' POST: AddressTypes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim addressType As AddressType = db.AddressTypes.Find(id)
            db.AddressTypes.Remove(addressType)
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
