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
    Public Class NumberingsController
        Inherits System.Web.Mvc.Controller

        Private _db As New HeatDBContext
        Private _modelBuilder As NumberingViewModelsBuilder

        Sub New(context As IHeatDBContext)
            _db = context
            _modelBuilder = New NumberingViewModelsBuilder(context)
        End Sub

        ' GET: Numerators
        Function Index() As ActionResult
            Return View(_modelBuilder.GetIndexModel)
        End Function

        ' GET: Numerators/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim numbering As Numbering = _db.Numberings.Find(id)
            If IsNothing(numbering) Then
                Return HttpNotFound()
            End If
            Return View(numbering)
        End Function

        ' GET: Numerators/Create
        Function Create() As ActionResult
            Return View(_modelBuilder.GetCreateModel)
        End Function

        ' POST: Numerators/Create
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(ByVal newNumbering As CreateNumberingViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim numbering As New Numbering

                numbering = Mapper.Map(Of Numbering)(newNumbering)

                numbering.LastFinalSerial = New SerialNumber
                numbering.LastTempSerial = New SerialNumber

                _db.Numberings.Add(numbering)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(newNumbering)
        End Function

        ' GET: Numerators/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            If Not _db.Numberings.AsNoTracking.Any(Function(x) x.ID = id) Then
                Return HttpNotFound()
            End If

            Dim editNumbering As EditNumberingViewModel
            editNumbering = _modelBuilder.GetEditModel(id)
            Return View(editNumbering)
        End Function

        ' POST: Numerators/Edit/5
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(ByVal editNumberingVM As EditNumberingViewModel) As ActionResult
            If ModelState.IsValid Then
                Dim editNumbering As Numbering
                editNumbering = _db.Numberings.Find(editNumberingVM.ID) 'Where(Function(x) x.ID = editNumberingVM.ID).FirstOrDefault
                'db.SerialSchemes.Attach(editNumberingVM.TempSerialSchema)
                'Try
                '    db.SerialSchemes.Attach(editNumberingVM.FinalSerialSchema)
                'Catch ex As Exception

                'End Try

                'editNumbering = Mapper.Map(Of Numbering)(editNumberingVM)
                'db.Numberings.Attach(editNumbering)

                'editNumbering.Code = editNumberingVM.Code
                'editNumbering.Description = editNumberingVM.Description
                'editNumbering.FinalSerialSchema = db.SerialSchemes.Find(editNumberingVM.FinalSerialSchema.ID)
                'editNumbering.TempSerialSchema = db.SerialSchemes.Find(editNumberingVM.TempSerialSchema.ID)

                'db.Entry(editNumbering).State = EntityState.Modified

                editNumbering = Mapper.Map(Of EditNumberingViewModel, Numbering)(editNumberingVM, editNumbering)

                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(editNumberingVM)
        End Function

        ' GET: Numerators/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim numbering As Numbering = _db.Numberings.Find(id)
            If IsNothing(numbering) Then
                Return HttpNotFound()
            End If
            Return View(numbering)
        End Function

        ' POST: Numerators/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim numbering As Numbering = _db.Numberings.Find(id)
            _db.Numberings.Remove(numbering)
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


'Imports System
'Imports System.Collections.Generic
'Imports System.Data
'Imports System.Data.Entity
'Imports System.Linq
'Imports System.Net
'Imports System.Web
'Imports System.Web.Mvc
'Imports Heat
'Imports Heat.Models
'Imports Heat.Repositories

'Namespace Controllers
'    Public Class NumberingsController
'        Inherits System.Web.Mvc.Controller

'        Private db As New HeatDBContext

'        ' GET: Numerators
'        Function Index() As ActionResult
'            Return View(db.Numberings.ToList())
'        End Function

'        ' GET: Numerators/Details/5
'        Function Details(ByVal id As Integer?) As ActionResult
'            If IsNothing(id) Then
'                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
'            End If
'            Dim numbering As Numbering = db.Numberings.Find(id)
'            If IsNothing(numbering) Then
'                Return HttpNotFound()
'            End If
'            Return View(numbering)
'        End Function

'        ' GET: Numerators/Create
'        Function Create() As ActionResult
'            Dim mb As New NumberingViewModelsBuilder(db)
'            Dim m As CreateNumberingViewModel
'            m = mb.GetCreateModel
'            Return View(m)
'        End Function

'        ' POST: Numerators/Create
'        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
'        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
'        <HttpPost()>
'        <ValidateAntiForgeryToken()>
'        Function Create(<Bind(Include:="ID,Code,Description,LastValue")> ByVal numbering As Numbering) As ActionResult
'            If ModelState.IsValid Then
'                numbering.LastFinalSerial = New SerialNumber
'                numbering.LastTempSerial = New SerialNumber
'                db.Numberings.Add(numbering)
'                db.SaveChanges()
'                Return RedirectToAction("Index")
'            End If
'            Return View(numbering)
'        End Function

'        ' GET: Numerators/Edit/5
'        Function Edit(ByVal id As Integer?) As ActionResult
'            If IsNothing(id) Then
'                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
'            End If
'            Dim numbering As Numbering = db.Numberings.Find(id)
'            If IsNothing(numbering) Then
'                Return HttpNotFound()
'            End If
'            Return View(numbering)
'        End Function

'        ' POST: Numerators/Edit/5
'        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
'        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
'        <HttpPost()>
'        <ValidateAntiForgeryToken()>
'        Function Edit(<Bind(Include:="ID,Code,Description,LastValue")> ByVal numbering As Numbering) As ActionResult
'            If ModelState.IsValid Then
'                db.Entry(numbering).State = EntityState.Modified
'                db.SaveChanges()
'                Return RedirectToAction("Index")
'            End If
'            Return View(numbering)
'        End Function

'        ' GET: Numerators/Delete/5
'        Function Delete(ByVal id As Integer?) As ActionResult
'            If IsNothing(id) Then
'                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
'            End If
'            Dim numbering As Numbering = db.Numberings.Find(id)
'            If IsNothing(numbering) Then
'                Return HttpNotFound()
'            End If
'            Return View(numbering)
'        End Function

'        ' POST: Numerators/Delete/5
'        <HttpPost()>
'        <ActionName("Delete")>
'        <ValidateAntiForgeryToken()>
'        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
'            Dim numbering As Numbering = db.Numberings.Find(id)
'            db.Numberings.Remove(numbering)
'            db.SaveChanges()
'            Return RedirectToAction("Index")
'        End Function

'        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
'            If (disposing) Then
'                db.Dispose()
'            End If
'            MyBase.Dispose(disposing)
'        End Sub
'    End Class
'End Namespace
