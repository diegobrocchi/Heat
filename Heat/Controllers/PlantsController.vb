Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Heat
Imports Heat.Repositories
Imports Heat.Models
Imports Heat.ViewModels.Plants
Imports DataTables.AspNet.Core
Imports Heat.Manager
Imports System.IO

Namespace Controllers
    <Authorize>
    Public Class PlantsController
        Inherits System.Web.Mvc.Controller

        Private _db As IHeatDBContext
        Private _mb As PlantModelViewBuilder
        Private _pm As PlantManager


        Sub New(dbcontext As IHeatDBContext)
            _db = dbcontext
            _mb = New PlantModelViewBuilder(_db)
            _pm = New PlantManager(_db)
        End Sub


        ' GET: Plants
        Function Index() As ActionResult
            Try
                Dim model As List(Of IndexPlantViewModel)

                model = _mb.GetIndexPlantViewModel

                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpGet>
        Function Details(ByVal id As Integer?) As ActionResult
            Try
                If IsNothing(id) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                'Dim plant As Plant = _db.Plants.Find(id)
                If Not _db.Plants.Any(Function(p) p.ID = id) Then
                    Return HttpNotFound()
                End If
                Dim model As DetailsPlantViewModel
                model = _mb.GetDetailsPlantViewModel(id)
                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpGet>
        Function Create() As ActionResult
            Try

                Return View()
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try
        End Function


        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(newPlant As CreatePlantViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim p As Plant

                    p = AutoMapper.Mapper.Map(Of Plant)(newPlant)

                    _db.Plants.Add(p)
                    _db.SaveChanges()
                    'dopo aver salvato i dati dell'ubicazione passo ai dati del contatto
                    Return RedirectToAction("AddContact", New With {.plantID = p.ID})
                Else
                    'il modello non è valido
                    Return View(newPlant)
                End If

            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpGet>
        Function AddContact(ID As Integer) As ActionResult
            Try
                If IsNothing(ID) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                'Dim plant As Plant = _db.Plants.Find(plantID)
                If Not _db.Plants.Any(Function(p) p.ID = ID) Then
                    Return HttpNotFound()
                End If

                Dim model As AddContactPlantViewModel

                model = _mb.GetAddContactPlantViewModel(ID)
                Return View(model)

            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function AddContact(newContact As AddContactPlantViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim c As Contact
                    Dim p As Plant

                    c = AutoMapper.Mapper.Map(Of Contact)(newContact)
                    p = _db.Plants.Find(newContact.PlantID)

                    If Not IsNothing(p) Then
                        p.Contacts.Add(c)
                        _db.Contacts.Add(c)
                        _db.SaveChanges()
                        'dopo aver salvato i dati del contatto passo ai dati termici
                        Return RedirectToAction("AddThermInfo", New With {.plantID = p.ID})
                    Else
                        ViewBag.message = "Impossibile aggiungere il contatto. Sembra che l'impianto con id(" & newContact.PlantID & ") non esista"
                        Return View("error")
                    End If

                Else
                    'ripasso al modelBuilder per ricostruire la selectlist
                    Return View(_mb.GetAddContactPlantViewModel(newContact.PlantID))
                End If

            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try
        End Function

        <HttpGet>
        Function AddAnotherContact(ID As Integer) As ActionResult
            Try
                If IsNothing(ID) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If

                If Not _db.Plants.Any(Function(p) p.ID = ID) Then
                    Return HttpNotFound()
                End If

                Dim model As AddContactPlantViewModel

                model = _mb.GetAddContactPlantViewModel(ID)
                Return View(model)

            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Function AddAnotherContact(newContact As AddContactPlantViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim c As Contact
                    Dim p As Plant

                    c = AutoMapper.Mapper.Map(Of Contact)(newContact)
                    p = _db.Plants.Find(newContact.PlantID)

                    If Not IsNothing(p) Then
                        p.Contacts.Add(c)
                        _db.Contacts.Add(c)
                        _db.SaveChanges()
                        'dopo aver salvato i dati del contatto torno ai dettagli dell'impianto
                        Return RedirectToAction("details", New With {.ID = p.ID})
                    Else
                        ViewBag.message = "Impossibile aggiungere il contatto. Sembra che l'impianto con id(" & newContact.PlantID & ") non esista"
                        Return View("error")
                    End If

                Else
                    'ripasso al modelBuilder per ricostruire la selectlist
                    Return View(_mb.GetAddContactPlantViewModel(newContact.PlantID))
                End If

            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try
        End Function

        <HttpGet>
        Function AddThermInfo(plantId As Integer) As ActionResult
            Try
                If IsNothing(plantId) Then
                    Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                End If
                Dim plant As Plant = _db.Plants.Find(plantId)
                If IsNothing(plant) Then
                    Return HttpNotFound()
                End If
                Dim model As AddThermInfoPlantViewModel

                model = _mb.GetAddThermInfoPlantViewModel(plantId)
                Return View(model)

            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpPost>
        Function AddThermInfo(newThermInfo As AddThermInfoPlantViewModel) As ActionResult
            Try
                If ModelState.IsValid Then
                    Dim ActualPB As PlantBuilding
                    Dim actualPlant As Plant

                    actualPlant = _db.Plants.Find(newThermInfo.PlantID)
                    ActualPB = actualPlant.BuildingAddress

                    ActualPB = AutoMapper.Mapper.Map(Of AddThermInfoPlantViewModel, PlantBuilding)(newThermInfo, ActualPB)
                    actualPlant.PlantDistinctCode = newThermInfo.PlantDistinctCode

                    _db.SaveChanges()

                    Return RedirectToAction("index")
                Else
                    'ripasso al modelBuilder per ricreare le selectlist
                    Return View(_mb.GetAddThermInfoPlantViewModel(newThermInfo.PlantID))
                End If
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try
        End Function

        ' GET: Plants/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plant As Plant = _db.Plants.Find(id)
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
                '_db.Entry(plant).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(plant)
        End Function

        ' GET: Plants/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim plant As Plant = _db.Plants.Find(id)
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
            Dim plant As Plant = _db.Plants.Find(id)
            _db.Plants.Remove(plant)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        <HttpPost>
        Function Import(uploadFilePlant As HttpPostedFileBase) As ActionResult
            If Not IsNothing(uploadFilePlant) AndAlso uploadFilePlant.ContentLength > 0 Then
                Dim fileExt As String
                fileExt = System.IO.Path.GetExtension(uploadFilePlant.FileName).ToLower
                If fileExt = ".txt" Then
                    Dim ih As New ImportHelper(_db)
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

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="request"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <HttpGet>
        Public Function PagedPlants(request As IDataTablesRequest) As ActionResult
            If ModelState.IsValid Then
                Return _pm.GetPagedPlants(request)
            Else
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
                'Return Json(New With {.success = False, .responseText = "La richiesta non è valida!"}, JsonRequestBehavior.AllowGet)
            End If
        End Function

        <HttpGet>
        Public Function AddMediumToPlant(plantID As Integer) As ActionResult
            If IsNothing(plantID) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            If Not _db.Plants.Any(Function(p) p.ID = plantID) Then
                Return HttpNotFound()
            End If
            Try
                Dim model As New AddMediumPlantViewModel
                model.PlantId = plantID
                Return View(model)
            Catch ex As Exception
                ViewBag.message = ex.ToString
                Return View("error")
            End Try

        End Function

        <HttpPost>
        <ValidateAntiForgeryToken>
        Public Function AddMediumToPlant(newMedium As AddMediumPlantViewModel) As ActionResult
            If IsNothing(newMedium.UploadFile) OrElse newMedium.UploadFile.ContentLength <= 0 Then
                ModelState.AddModelError("UploadFile", "Il file è richiesto!")
            End If
            Try
                If ModelState.IsValid Then
                    Dim medium As New Medium
                    Dim uploadDir As String
                    Dim uploadFileName As String
                    Dim uploadPath As String
                    Dim uploadURL As String

                    uploadDir = ConfigurationManager.AppSettings("MediaPlantFolder")
                    uploadFileName = Guid.NewGuid().ToString & Path.GetExtension(newMedium.UploadFile.FileName)

                    uploadPath = Path.Combine(Server.MapPath(uploadDir), uploadFileName)
                    uploadURL = Path.Combine(uploadDir, uploadFileName)

                    newMedium.UploadFile.SaveAs(uploadPath)

                    medium.Description = newMedium.Description
                    medium.Tags = newMedium.Tags
                    medium.OriginalFilename = newMedium.UploadFile.FileName
                    medium.UploadFilename = uploadFileName
                    medium.ContentType = newMedium.UploadFile.ContentType
                    medium.Lenght = newMedium.UploadFile.ContentLength

                    Dim p As Plant = _db.Plants.Find(newMedium.PlantId)
                    p.Media.Add(medium)
                    _db.Media.Add(medium)
                    _db.SaveChanges()
                    Return RedirectToAction("index")
                Else
                    Return View(newMedium)
                End If
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
