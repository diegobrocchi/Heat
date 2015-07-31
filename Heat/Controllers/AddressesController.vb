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
    Public Class AddressesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Addresses
        Function Index() As ActionResult
            Dim address = db.Address.Include(Function(a) a.AddressType)
            Return View(address.ToList())
        End Function

        ' GET: Addresses/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim address As Address = db.Address.Find(id)
            If IsNothing(address) Then
                Return HttpNotFound()
            End If
            Return View(address)
        End Function

        ' GET: Addresses/Create
        Function Create() As ActionResult
            ViewBag.AddressTypeID = New SelectList(db.AddressTypes, "ID", "Description")
            Return View()
        End Function

        <HttpGet> _
        Function Create(customerID As Integer) As ActionResult

        End Function

        ' POST: Addresses/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,AddressTypeID,Street,StreetNumber,City,PostalCode,Province,State,Phone,CellPhone,Fax,Note")> ByVal address As Address) As ActionResult
            If ModelState.IsValid Then
                db.Address.Add(address)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AddressTypeID = New SelectList(db.AddressTypes, "ID", "Description", address.AddressTypeID)
            Return View(address)
        End Function

        ' GET: Addresses/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim address As Address = db.Address.Find(id)
            If IsNothing(address) Then
                Return HttpNotFound()
            End If
            ViewBag.AddressTypeID = New SelectList(db.AddressTypes, "ID", "Description", address.AddressTypeID)
            Return View(address)
        End Function

        ' POST: Addresses/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,AddressTypeID,Street,StreetNumber,City,PostalCode,Province,State,Phone,CellPhone,Fax,Note")> ByVal address As Address) As ActionResult
            If ModelState.IsValid Then
                db.Entry(address).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.AddressTypeID = New SelectList(db.AddressTypes, "ID", "Description", address.AddressTypeID)
            Return View(address)
        End Function

        ' GET: Addresses/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim address As Address = db.Address.Find(id)
            If IsNothing(address) Then
                Return HttpNotFound()
            End If
            Return View(address)
        End Function

        ' POST: Addresses/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim address As Address = db.Address.Find(id)
            db.Address.Remove(address)
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
