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
Imports Heat.ViewModels.Heaters

Namespace Controllers
    Public Class HeatersController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As HeaterModelViewBuilder

        Sub New(dbContext As IHeatDBContext)
            _db = dbContext
            _mb = New Heatermodelviewbuilder(_db)
        End Sub

        ' GET: Heaters
        Function Index() As ActionResult
            Return View(_db.Heaters.ToList())
        End Function

        ' GET: Heaters/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim heater As Heater = _db.Heaters.Find(id)
            If IsNothing(heater) Then
                Return HttpNotFound()
            End If
            Return View(heater)
        End Function

        <HttpGet> _
        Function Create(thermalUnitID As Integer) As ActionResult
            Try
                If IsNothing(thermalUnitID) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                If Not _db.ThermalUnits.Any(Function(x) x.ID = thermalUnitID) Then
                    Return HttpNotFound()
                End If

                Dim model As CreateHeaterViewModel
                model = _mb.GetCreateHeaterViewModel(thermalUnitID)

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function

        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(newHeater As CreateHeaterViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim tu As ThermalUnit
                Dim h As Heater

                tu = _db.ThermalUnits.Find(newHeater.ThermalUnitID)

                h = AutoMapper.Mapper.Map(Of Heater)(newHeater)
                h.ThermalUnit = tu

                _db.Heaters.Add(h)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            Else
                Return View(newHeater)
            End If
        End Function

        ' GET: Heaters/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim heater As Heater = _db.Heaters.Find(id)
            If IsNothing(heater) Then
                Return HttpNotFound()
            End If
            Return View(heater)
        End Function

        ' POST: Heaters/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,SerialNumber,MinimumPowerKW,MaximumPowerKW,CertificationReference")> ByVal heater As Heater) As ActionResult
            If ModelState.IsValid Then
                '_db.Entry(heater).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(heater)
        End Function

        ' GET: Heaters/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim heater As Heater = _db.Heaters.Find(id)
            If IsNothing(heater) Then
                Return HttpNotFound()
            End If
            Return View(heater)
        End Function

        ' POST: Heaters/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim heater As Heater = _db.Heaters.Find(id)
            _db.Heaters.Remove(heater)
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
