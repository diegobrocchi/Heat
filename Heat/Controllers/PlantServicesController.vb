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
Imports Heat.ViewModels.PlantServices

Namespace Controllers
    Public Class PlantServicesController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As PlantServiceModelViewBuilder

        Sub New(dbContext As IHeatDBContext)
            _db = dbContext
            _mb = New PlantServiceModelViewBuilder(_db)
        End Sub


        ' GET: PlantServices
        Function Index() As ActionResult
            'Dim plantServices = _db.PlantServices.Include(Function(p) p.Plant)
            Return View(_db.PlantServices.ToList())
        End Function

        ' GET: PlantServices/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantService As PlantService = _db.PlantServices.Find(id)
            If IsNothing(plantService) Then
                Return HttpNotFound()
            End If
            Return View(plantService)
        End Function

        <HttpGet> _
        Function Create(plantID As Integer) As ActionResult
            Try
                If IsNothing(plantID) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                If Not _db.Plants.Any(Function(x) x.ID = plantID) Then
                    Return HttpNotFound()
                End If

                Dim model As createPlantServiceViewModel
                model = _mb.GetCreatePlantServiceViewModel(plantID)

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try
            ViewBag.ID = New SelectList(_db.Plants, "ID", "Name")
            Return View()
        End Function

        
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(newPlantService As CreatePlantServiceViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim ps As PlantService

                    ps = AutoMapper.Mapper.Map(Of PlantService)(newPlantService)
                    'ps.Plant = _db.Plants.Find(newPlantService.PlantID)

                    _db.PlantServices.Add(ps)
                    _db.SaveChanges()
                    Return RedirectToAction("Index")

                Else

                    Return View(newPlantService)

                End If
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try


        End Function

        ' GET: PlantServices/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantService As PlantService = _db.PlantServices.Find(id)
            If IsNothing(plantService) Then
                Return HttpNotFound()
            End If
            ViewBag.ID = New SelectList(_db.Plants, "ID", "Name", plantService.ID)
            Return View(plantService)
        End Function

        ' POST: PlantServices/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,PlantID,PreviousServiceDate,Periodicity,LegalExpirationDate,PlannedServiceDate")> ByVal plantService As PlantService) As ActionResult
            If ModelState.IsValid Then
                '_db.Entry(plantService).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.ID = New SelectList(_db.Plants, "ID", "Name", plantService.ID)
            Return View(plantService)
        End Function

        ' GET: PlantServices/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plantService As PlantService = _db.PlantServices.Find(id)
            If IsNothing(plantService) Then
                Return HttpNotFound()
            End If
            Return View(plantService)
        End Function

        ' POST: PlantServices/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim plantService As PlantService = _db.PlantServices.Find(id)
            _db.PlantServices.Remove(plantService)
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
