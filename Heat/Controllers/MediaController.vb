﻿Imports System
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
    Public Class MediaController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Media
        Function Index() As ActionResult
            Return View(db.Media.ToList())
        End Function

        ' GET: Media/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim medium As Medium = db.Media.Find(id)
            If IsNothing(medium) Then
                Return HttpNotFound()
            End If
            Return View(medium)
        End Function

        ' GET: Media/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Media/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,FileName,RelativePath,AbsolutePath,Lenght,Extension,Description,Tags")> ByVal medium As Medium) As ActionResult
            If ModelState.IsValid Then
                db.Media.Add(medium)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(medium)

        End Function

        ' GET: Media/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim medium As Medium = db.Media.Find(id)
            If IsNothing(medium) Then
                Return HttpNotFound()
            End If
            Return View(medium)
        End Function

        ' POST: Media/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,FileName,RelativePath,AbsolutePath,Lenght,Extension,Description,Tags")> ByVal medium As Medium) As ActionResult
            If ModelState.IsValid Then
                db.Entry(medium).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(medium)
        End Function

        ' GET: Media/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim medium As Medium = db.Media.Find(id)
            If IsNothing(medium) Then
                Return HttpNotFound()
            End If
            Return View(medium)
        End Function

        ' POST: Media/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim medium As Medium = db.Media.Find(id)
            db.Media.Remove(medium)
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
