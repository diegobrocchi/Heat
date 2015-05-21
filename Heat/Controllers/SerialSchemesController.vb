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
Imports AutoMapper

Namespace Controllers
    Public Class SerialSchemesController
        Inherits System.Web.Mvc.Controller

        Private _db As HeatDBContext
        Private _vmBuilder

        Sub New(context As HeatDBContext)
            _db = context
            _vmBuilder = New SerialSchemeViewModelBuilder(context)
        End Sub
        ' GET: SerialSchemes
        Function Index() As ActionResult
            Return View(_vmBuilder.getListViewModel)
        End Function

        ' GET: SerialSchemes/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serialScheme As SerialScheme = _db.SerialSchemes.Find(id)
            If IsNothing(serialScheme) Then
                Return HttpNotFound()
            End If
            Dim schemaDetails As CreateSerialSchemeViewModel
            schemaDetails = Mapper.Map(Of CreateSerialSchemeViewModel)(serialScheme)

            Return View(schemaDetails)
        End Function

        ' GET: SerialSchemes/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: SerialSchemes/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal newSerialScheme As CreateSerialSchemeViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim serialScheme As SerialScheme

                serialScheme = Mapper.Map(Of SerialScheme)(newSerialScheme)

                _db.SerialSchemes.Add(serialScheme)
                _db.SaveChanges()

                Return RedirectToAction("Index")
            End If
            Return View(newSerialScheme)
        End Function

        ' GET: SerialSchemes/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serialScheme As SerialScheme = _db.SerialSchemes.Find(id)
            If IsNothing(serialScheme) Then
                Return HttpNotFound()
            End If
            Dim editSerialScheme As CreateSerialSchemeViewModel
            editSerialScheme = Mapper.Map(Of CreateSerialSchemeViewModel)(serialScheme)
            Return View(editSerialScheme)
        End Function

        ' POST: SerialSchemes/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal editSerialScheme As CreateSerialSchemeViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim serialScheme As SerialScheme
                serialScheme = Mapper.Map(Of SerialScheme)(editSerialScheme)
                _db.Entry(serialScheme).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(editSerialScheme)
        End Function

        ' GET: SerialSchemes/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim serialScheme As SerialScheme = _db.SerialSchemes.Find(id)
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
            Dim serialScheme As SerialScheme = _db.SerialSchemes.Find(id)
            _db.SerialSchemes.Remove(serialScheme)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
