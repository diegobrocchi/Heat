Imports System.Data.Entity
Imports System.Net
Imports System.Security.Principal
Imports Heat.Manager
Imports Heat.Models
Imports Heat.ViewModels.OutboundCall

Namespace Controllers
    Public Class OutboundCallsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        'Private _ocm As OutboundCallManager
        Private _mb As OutboundCallsModelViewBuilder

        Public Sub New(dbContext As IHeatDBContext)
            _db = dbContext
            _mb = New OutboundCallsModelViewBuilder(_db)
            '_ocm = New OutboundCallManager(_db)
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
        Public Function GetNextProposed(login As IPrincipal) As ActionResult
            Try
                Dim model As ProposedOutboundCallsViewModel
                model = _mb.GetNextProposed(login.Identity.Name)
                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
