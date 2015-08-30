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
Imports Heat.ViewModels.ManifacturerModels

Namespace Controllers
    Public Class ManifacturerModelsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As ManifacturerModelViewBuilder


        Sub New(context As IHeatDBContext)
            _db = context
            _mb = New ManifacturerModelViewBuilder(_db)
        End Sub

        ' GET: ManifacturerModels
        Function Index() As ActionResult
            Dim model As List(Of IndexManifacturerModelViewModel)

            model = _mb.GetIndexManifacturerModelViewModel

            Return View(model)
        End Function

        ' GET: ManifacturerModels/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim manifacturerModel As ManifacturerModel = _db.ManifacturerModels.Find(id)
            If IsNothing(manifacturerModel) Then
                Return HttpNotFound()
            End If
            Return View(manifacturerModel)
        End Function

        <HttpGet> _
        Function Create() As ActionResult
            Try
                Dim model As CreateManifacturerModelViewModel

                model = _mb.GetCreateManifacturerModelViewModel

                Return View(model)

            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try
        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(newManifacturerModel As CreateManifacturerModelViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim mm As ManifacturerModel

                    mm = AutoMapper.Mapper.Map(Of ManifacturerModel)(newManifacturerModel)

                    _db.ManifacturerModels.Add(mm)
                    _db.SaveChanges()
                    Return RedirectToAction("Index")
                Else
                    Return View(newManifacturerModel)
                End If
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try


        End Function

        ' GET: ManifacturerModels/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            
            Try
                If IsNothing(id) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                If Not _db.ManifacturerModels.Any(Function(x) x.ID = id) Then
                    Return HttpNotFound()
                End If
                Dim model As EditManifacturerModelViewModel
                model = _mb.geteditManifacturerModelViewModel(id)
                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        ' POST: ManifacturerModels/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(editedManifacturerModel As EditManifacturerModelViewModel) As ActionResult
             
            Try
                If ModelState.IsValid Then
                    Dim dbItem As ManifacturerModel
                    dbItem = _db.ManifacturerModels.Find(editedManifacturerModel.ID)

                    AutoMapper.Mapper.Map(editedManifacturerModel, dbItem)

                    _db.SaveChanges()

                    Return RedirectToAction("Index")
                Else
                    Return View(editedManifacturerModel)
                End If

            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try
             
        End Function

        ' GET: ManifacturerModels/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim manifacturerModel As ManifacturerModel = _db.ManifacturerModels.Find(id)
            If IsNothing(manifacturerModel) Then
                Return HttpNotFound()
            End If
            Return View(manifacturerModel)
        End Function

        ' POST: ManifacturerModels/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim manifacturerModel As ManifacturerModel = _db.ManifacturerModels.Find(id)
            _db.ManifacturerModels.Remove(manifacturerModel)
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
