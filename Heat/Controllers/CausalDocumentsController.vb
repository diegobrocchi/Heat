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

Namespace Controllers
    Public Class CausalDocumentsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: CausalDocuments
        Function Index() As ActionResult
            Return View("index", db.CausalDocuments.ToList())
        End Function

        ' GET: CausalDocuments/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalDocument As CausalDocument = db.CausalDocuments.Find(id)
            If IsNothing(causalDocument) Then
                Return HttpNotFound()
            End If
            Return View(causalDocument)
        End Function

        ' GET: CausalDocuments/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: CausalDocuments/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Description")> ByVal causalDocument As CausalDocument) As ActionResult
            If ModelState.IsValid Then
                db.CausalDocuments.Add(causalDocument)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(causalDocument)
        End Function

        ' GET: CausalDocuments/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalDocument As CausalDocument = db.CausalDocuments.Find(id)
            If IsNothing(causalDocument) Then
                Return HttpNotFound()
            End If
            Return View(causalDocument)
        End Function

        ' POST: CausalDocuments/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Description")> ByVal causalDocument As CausalDocument) As ActionResult
            If ModelState.IsValid Then
                db.Entry(causalDocument).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(causalDocument)
        End Function

        ' GET: CausalDocuments/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim causalDocument As CausalDocument = db.CausalDocuments.Find(id)
            If IsNothing(causalDocument) Then
                Return HttpNotFound()
            End If
            Return View(causalDocument)
        End Function

        ' POST: CausalDocuments/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim causalDocument As CausalDocument = db.CausalDocuments.Find(id)
            db.CausalDocuments.Remove(causalDocument)
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
