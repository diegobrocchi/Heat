﻿Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat
Imports Heat.Repositories
Imports AutoMapper

Namespace Controllers
    Public Class SerialSchemesController
        Inherits System.Web.Mvc.Controller

        Private db As HeatDBContext

        Sub New(context As HeatDBContext)
            db = context
        End Sub
        ' GET: SerialSchemes
        Function Index() As ActionResult
            Return View(db.SerialSchemes.ToList())
        End Function

        ' GET: SerialSchemes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serialScheme As SerialScheme = db.SerialSchemes.Find(id)
            If IsNothing(serialScheme) Then
                Return HttpNotFound()
            End If

            Return View(serialScheme)
        End Function

        ' GET: SerialSchemes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: SerialSchemes/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal newSerialScheme As AddNewSerialSchemeViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim serialScheme As SerialScheme
                serialScheme = Mapper.Map(Of SerialScheme)(newSerialScheme)
                db.SerialSchemes.Add(serialScheme)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(newSerialScheme)
        End Function

        ' GET: SerialSchemes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serialScheme As SerialScheme = db.SerialSchemes.Find(id)
            If IsNothing(serialScheme) Then
                Return HttpNotFound()
            End If
            Dim editSerialScheme As AddNewSerialSchemeViewModel
            editSerialScheme = Mapper.Map(Of AddNewSerialSchemeViewModel)(serialScheme)
            Return View(editSerialScheme)
        End Function

        ' POST: SerialSchemes/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,InitialValue,Increment,MinValue,MaxValue,FormatMask,ExpiryDate,RecycleWhenExpired,Period,RecycleWhenMaxIsReached")> ByVal serialScheme As SerialScheme) As ActionResult
            If ModelState.IsValid Then
                db.Entry(serialScheme).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(serialScheme)
        End Function

        ' GET: SerialSchemes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serialScheme As SerialScheme = db.SerialSchemes.Find(id)
            If IsNothing(serialScheme) Then
                Return HttpNotFound()
            End If
            Return View(serialScheme)
        End Function

        ' POST: SerialSchemes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim serialScheme As SerialScheme = db.SerialSchemes.Find(id)
            db.SerialSchemes.Remove(serialScheme)
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