Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Mvc
Imports Heat.Manager
Imports Heat.Models
Imports Heat.Repositories

Namespace Controllers
    Public Class OutboundCallsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _ocm As OutboundCallManager


        Public Sub New(dbContext As IHeatDBContext)
            _db = dbContext
            _ocm = New OutboundCallManager(_db)
        End Sub

        ' GET: OutboundCalls
        Function Index() As ActionResult
            Dim outboundCalls = _db.OutboundCalls.Include(Function(o) o.Contact)
            Return View(outboundCalls.ToList())
        End Function

        ' GET: OutboundCalls/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim outboundCall As OutboundCall = _db.OutboundCalls.Find(id)
            If IsNothing(outboundCall) Then
                Return HttpNotFound()
            End If
            Return View(outboundCall)
        End Function

        ' GET: OutboundCalls/Create
        Function Create() As ActionResult
            ViewBag.ContactID = New SelectList(_db.Contacts, "ID", "Name")
            Return View()
        End Function

        ' POST: OutboundCalls/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,CallDate,ContactID,ResultID,Login")> ByVal outboundCall As OutboundCall) As ActionResult
            If ModelState.IsValid Then
                _db.OutboundCalls.Add(outboundCall)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ContactID = New SelectList(_db.Contacts, "ID", "Name", outboundCall.ContactID)
            Return View(outboundCall)
        End Function

        ' GET: OutboundCalls/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim outboundCall As OutboundCall = _db.OutboundCalls.Find(id)
            If IsNothing(outboundCall) Then
                Return HttpNotFound()
            End If
            ViewBag.ContactID = New SelectList(_db.Contacts, "ID", "Name", outboundCall.ContactID)
            Return View(outboundCall)
        End Function

        ' POST: OutboundCalls/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,CallDate,ContactID,ResultID,Login")> ByVal outboundCall As OutboundCall) As ActionResult
            If ModelState.IsValid Then
                '_db.Entry(outboundCall).State = EntityState.Modified
                _db.SetModified(outboundCall)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ContactID = New SelectList(_db.Contacts, "ID", "Name", outboundCall.ContactID)
            Return View(outboundCall)
        End Function

        ' GET: OutboundCalls/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim outboundCall As OutboundCall = _db.OutboundCalls.Find(id)
            If IsNothing(outboundCall) Then
                Return HttpNotFound()
            End If
            Return View(outboundCall)
        End Function

        ' POST: OutboundCalls/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim outboundCall As OutboundCall = _db.OutboundCalls.Find(id)
            _db.OutboundCalls.Remove(outboundCall)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        <HttpGet>
        Public Function CreateList(login As IPrincipal) As ActionResult
            Return View(_ocm.GetNextOutboundCallSet(login.Identity.Name))
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
