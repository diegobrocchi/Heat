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
Imports Heat.Viewmodels

Namespace Controllers
    Public Class DocumentTypesController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: DocumentTypes
        Function Index() As ActionResult
            Return View(db.DocumentTypes.ToList())
        End Function

        ' GET: DocumentTypes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim documentType As DocumentType = db.DocumentTypes.Find(id)
            If IsNothing(documentType) Then
                Return HttpNotFound()
            End If
            Return View(documentType)
        End Function

        ' GET: DocumentTypes/Create
        Function Create() As ActionResult
            Dim dtvm As New DocumentTypeAddViewModel

            dtvm.NumberingList = New SelectList(db.Numberings.ToList, "ID", "Code")

            Return View(dtvm)
        End Function

        ' POST: DocumentTypes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Name,Description")> ByVal documentType As DocumentType) As ActionResult
            If ModelState.IsValid Then
                db.DocumentTypes.Add(documentType)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(documentType)
        End Function

        ' GET: DocumentTypes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim documentType As DocumentType = db.DocumentTypes.Find(id)
            If IsNothing(documentType) Then
                Return HttpNotFound()
            End If
            Return View(documentType)
        End Function

        ' POST: DocumentTypes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Name,Description")> ByVal documentType As DocumentType) As ActionResult
            If ModelState.IsValid Then
                db.Entry(documentType).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(documentType)
        End Function

        ' GET: DocumentTypes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim documentType As DocumentType = db.DocumentTypes.Find(id)
            If IsNothing(documentType) Then
                Return HttpNotFound()
            End If
            Return View(documentType)
        End Function

        ' POST: DocumentTypes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim documentType As DocumentType = db.DocumentTypes.Find(id)
            db.DocumentTypes.Remove(documentType)
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
