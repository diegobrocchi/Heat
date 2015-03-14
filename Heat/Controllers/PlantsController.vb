Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat

Namespace Controllers
    Public Class PlantsController
        Inherits System.Web.Mvc.Controller

        Private db As New HeatDBContext

        ' GET: Plants
        Function Index() As ActionResult
            Return View(db.Plants.ToList())
        End Function

        ' GET: Plants/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plant As Plant = db.Plants.Find(id)
            If IsNothing(plant) Then
                Return HttpNotFound()
            End If
            Return View(plant)
        End Function

        ' GET: Plants/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Plants/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="ID,Code,Name,Address,StreetNumber,City,PostalCode,Area,Zone,PlantTelephone1,PlantTelephone2,PlantTelephone3,PlantDistictCode,Fuel")> ByVal plant As Plant) As ActionResult
            If ModelState.IsValid Then
                db.Plants.Add(plant)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(plant)
        End Function

        ' GET: Plants/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plant As Plant = db.Plants.Find(id)
            If IsNothing(plant) Then
                Return HttpNotFound()
            End If
            Return View(plant)
        End Function

        ' POST: Plants/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="ID,Code,Name,Address,StreetNumber,City,PostalCode,Area,Zone,PlantTelephone1,PlantTelephone2,PlantTelephone3,PlantDistictCode,Fuel")> ByVal plant As Plant) As ActionResult
            If ModelState.IsValid Then
                db.Entry(plant).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(plant)
        End Function

        ' GET: Plants/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plant As Plant = db.Plants.Find(id)
            If IsNothing(plant) Then
                Return HttpNotFound()
            End If
            Return View(plant)
        End Function

        ' POST: Plants/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim plant As Plant = db.Plants.Find(id)
            db.Plants.Remove(plant)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        <HttpPost> _
        Function Import(uploadFilePlant As HttpPostedFileBase) As ActionResult
            If Not IsNothing(uploadFilePlant) AndAlso uploadFilePlant.ContentLength > 0 Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(uploadFilePlant.FileName).ToLower
                If fileExt = ".txt" Then
                    Dim ih As New ImportHelper(db)
                    Dim b(uploadFilePlant.ContentLength) As Byte
                    uploadFilePlant.InputStream.Read(b, 0, uploadFilePlant.ContentLength)
                    If ih.Plant(System.Text.Encoding.ASCII.GetString(b)) Then
                        Return RedirectToAction("index")
                    Else
                        ViewBag.error = "Errore durante l'importazione del file"
                        Return View()
                    End If
                Else
                    ViewBag.error = "Sono ammmessi solo file .txt"
                    Return View()
                End If

            Else
                Return View()
            End If
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
