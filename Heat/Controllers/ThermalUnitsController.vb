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
Imports Heat.ViewModels.ThermalUnits

Namespace Controllers
    Public Class ThermalUnitsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As ThermalUnitModelViewBuilder

        Sub New(dbContext As IHeatDBContext)
            _db = dbContext
            _mb = New ThermalUnitModelViewBuilder(_db)
        End Sub

        ' GET: ThermalUnits
        Function Index() As ActionResult
            Return View(_db.ThermalUnits.ToList())
        End Function

        ' GET: ThermalUnits/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim thermalUnit As ThermalUnit = _db.ThermalUnits.Find(id)
            If IsNothing(thermalUnit) Then
                Return HttpNotFound()
            End If
            Return View(thermalUnit)
        End Function

        '<HttpGet> _
        '<Route("ThermalUnits/Create")> _
        'Function Create() As ActionResult
        '    Try
        '        Dim model As CreateThermalUnitViewModel
        '        model = _mb.GetCreateThermalUnitViewModel
        '        Return View(model)
        '    Catch ex As Exception
        '        ViewBag.message = ex.ToString
        '        Return View("error")
        '    End Try

        'End Function

        <HttpGet> _
        Function Create(Optional plantID As Integer = -1) As ActionResult
            Try
                Dim model As CreateThermalUnitViewModel
                If plantID = -1 Then

                    model = _mb.GetCreateThermalUnitViewModel

                Else
                    If Not _db.Plants.Any(Function(x) x.ID = plantID) Then
                        Return HttpNotFound()
                    End If

                    model = _mb.GetCreateThermalUnitViewModel(plantID)

                End If
                Return View(model)


            Catch ex As Exception
                ViewBag.message = ex.Message
                Return View("error")
            End Try

        End Function



        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(newThermalUnit As CreateThermalUnitViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim tu As ThermalUnit
                Dim p As Plant

                p = _db.Plants.Find(newThermalUnit.PlantID)

                tu = AutoMapper.Mapper.Map(Of ThermalUnit)(newThermalUnit)

                p.ThermalUnit = tu
                _db.ThermalUnits.Add(tu)

                _db.SaveChanges()

                Return RedirectToAction("Index")
            Else
                'il modello non è valido, quindi torna in view per correggere gli errori.
                'il modelBuilder ricostruisce le select.

                Dim model As CreateThermalUnitViewModel
                If newThermalUnit.PlantID <> 0 Then
                    model = _mb.GetCreateThermalUnitViewModel(newThermalUnit.PlantID)
                Else
                    model = _mb.GetCreateThermalUnitViewModel
                End If

                Return View(model)

            End If
        End Function

        ' GET: ThermalUnits/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim thermalUnit As ThermalUnit = _db.ThermalUnits.Find(id)
            If IsNothing(thermalUnit) Then
                Return HttpNotFound()
            End If
            Return View(thermalUnit)
        End Function

        ' POST: ThermalUnits/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,SerialNumber,InstallationDate,FirstStartUp,Warranty,WarrantyExpiration,NominalThermalPowerMax,DismissDate,ThermalEfficiencyPowerMax,Kind")> ByVal thermalUnit As ThermalUnit) As ActionResult
            If ModelState.IsValid Then
                ' _db.Entry(thermalUnit).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(thermalUnit)
        End Function

        ' GET: ThermalUnits/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim thermalUnit As ThermalUnit = _db.ThermalUnits.Find(id)
            If IsNothing(thermalUnit) Then
                Return HttpNotFound()
            End If
            Return View(thermalUnit)
        End Function

        ' POST: ThermalUnits/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Try
                Dim thermalUnit As ThermalUnit = _db.ThermalUnits.Find(id)
                Dim plant As Plant = _db.Plants.Where(Function(x) x.ThermalUnit.ID = thermalUnit.ID).First
                plant.ThermalUnit = Nothing
                _db.ThermalUnits.Remove(thermalUnit)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            Catch ex As Exception
                ViewBag.message = ex.ToString
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
