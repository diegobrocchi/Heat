using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Heat.Models;
using Heat.ViewModels.Plants;
using DataTables.AspNet.Core;
using Heat.Manager;
using System.IO;
using System.Text;

namespace Heat.Controllers
{
    [Authorize()]
	public class PlantsController : System.Web.Mvc.Controller
	{

		private IHeatDBContext _db;
		private PlantModelViewBuilder _mb;

		private PlantManager _pm;

		public PlantsController(IHeatDBContext dbcontext)
		{
			_db = dbcontext;
			_mb = new PlantModelViewBuilder(_db);
			_pm = new PlantManager(_db);
		}


		// GET: Plants
		public ActionResult Index()
		{
			try {
				List<IndexPlantViewModel> model = null;

				model = _mb.GetIndexPlantViewModel();

				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpGet()]
		public ActionResult Details(int  id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				if (!_db.Plants.Any(p => p.ID == id)) {
					return HttpNotFound();
				}
				DetailsPlantViewModel model = null;
				model = _mb.GetDetailsPlantViewModel(id);
				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpGet()]
		public ActionResult Create()
		{

			try {
				return View();
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(CreatePlantViewModel newPlant)
		{
			try {
				if (ModelState.IsValid) {
					Plant p = null;

					p = AutoMapper.Mapper.Map<Plant>(newPlant);

					_db.Plants.Add(p);
					_db.SaveChanges();
					//dopo aver salvato i dati dell'ubicazione passo ai dati del contatto
					return RedirectToAction("AddContact", new { plantID = p.ID });
				} else {
					//il modello non è valido
					return View(newPlant);
				}

			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpGet()]
		public ActionResult AddContact(int ID)
		{
			try {
				if ((ID == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				//Dim plant As Plant = _db.Plants.Find(plantID)
				if (!_db.Plants.Any(p => p.ID == ID)) {
					return HttpNotFound();
				}

				AddContactPlantViewModel model = null;

				model = _mb.GetAddContactPlantViewModel(ID);
				return View(model);

			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult AddContact(AddContactPlantViewModel newContact)
		{
			try {
				if (ModelState.IsValid) {
					Contact c = null;
					Plant p = null;

					c = AutoMapper.Mapper.Map<Contact>(newContact);
					p = _db.Plants.Find(newContact.PlantID);

					if ((p != null)) {
						p.Contacts.Add(c);
						_db.Contacts.Add(c);
						_db.SaveChanges();
						//dopo aver salvato i dati del contatto passo ai dati termici
						return RedirectToAction("AddThermInfo", new { plantID = p.ID });
					} else {
						ViewBag.message = "Impossibile aggiungere il contatto. Sembra che l'impianto con id(" + newContact.PlantID + ") non esista";
						return View("error");
					}

				} else {
					//ripasso al modelBuilder per ricostruire la selectlist
					return View(_mb.GetAddContactPlantViewModel(newContact.PlantID));
				}

			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}
		}

		[HttpGet()]
		public ActionResult AddAnotherContact(int ID)
		{
			try {
				if ((ID == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}

				if (!_db.Plants.Any(p => p.ID == ID)) {
					return HttpNotFound();
				}

				AddContactPlantViewModel model = null;

				model = _mb.GetAddContactPlantViewModel(ID);
				return View(model);

			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult AddAnotherContact(AddContactPlantViewModel newContact)
		{
			try {
				if (ModelState.IsValid) {
					Contact c = null;
					Plant p = null;

					c = AutoMapper.Mapper.Map<Contact>(newContact);
					p = _db.Plants.Find(newContact.PlantID);

					if ((p != null)) {
						p.Contacts.Add(c);
						_db.Contacts.Add(c);
						_db.SaveChanges();
						//dopo aver salvato i dati del contatto torno ai dettagli dell'impianto
						return RedirectToAction("details", new { ID = p.ID });
					} else {
						ViewBag.message = "Impossibile aggiungere il contatto. Sembra che l'impianto con id(" + newContact.PlantID + ") non esista";
						return View("error");
					}

				} else {
					//ripasso al modelBuilder per ricostruire la selectlist
					return View(_mb.GetAddContactPlantViewModel(newContact.PlantID));
				}

			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}
		}

		[HttpGet()]
		public ActionResult AddThermInfo(int plantId)
		{
			try {
				if ((plantId == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Plant plant = _db.Plants.Find(plantId);
				if ((plant == null)) {
					return HttpNotFound();
				}
				AddThermInfoPlantViewModel model = null;

				model = _mb.GetAddThermInfoPlantViewModel(plantId);
				return View(model);

			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpPost()]
		public ActionResult AddThermInfo(AddThermInfoPlantViewModel newThermInfo)
		{
			try {
				if (ModelState.IsValid) {
					PlantBuilding ActualPB = null;
					Plant actualPlant = null;

					actualPlant = _db.Plants.Find(newThermInfo.PlantID);
					ActualPB = actualPlant.BuildingAddress;

					ActualPB = AutoMapper.Mapper.Map<AddThermInfoPlantViewModel, PlantBuilding>(newThermInfo, ActualPB);
					actualPlant.PlantDistinctCode = newThermInfo.PlantDistinctCode;

					_db.SaveChanges();

					return RedirectToAction("index");
				} else {
					//ripasso al modelBuilder per ricreare le selectlist
					return View(_mb.GetAddThermInfoPlantViewModel(newThermInfo.PlantID));
				}
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}
		}

		// GET: Plants/Edit/5
		public ActionResult Edit(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Plant plant = _db.Plants.Find(id);
			if ((plant == null)) {
				return HttpNotFound();
			}
			return View(plant);
		}

		// POST: Plants/Edit/5
		//To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit(		[Bind(Include = "ID,Code,Name,Address,StreetNumber,City,PostalCode,Area,Zone,PlantTelephone1,PlantTelephone2,PlantTelephone3,PlantDistictCode,Fuel")]
Plant plant)
		{
			if (ModelState.IsValid) {
				//_db.Entry(plant).State = EntityState.Modified
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(plant);
		}

		/// <summary>
		/// Prepara la pagina con i link alle operazioni che è possibile svolgere sull'impianto.
		/// </summary>
		/// <param Name="id"></param>
		/// <returns></returns>
		[HttpGet()]
		public ActionResult Manage(int id)
		{
			try {
				if ((id == null)) {
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				//Dim customer As Plant = _db.Plants.Find(id)
				if (!_db.Plants.Any(x => x.ID == id)) {
					return HttpNotFound();
				}
				ManagePlantViewModel m = null;
				m = _mb.GetManagePlantViewModel(id);
				return View(m);
			} catch (Exception ex) {
				ViewBag.message = ex.Message;
				return View("error");
			}
		}

		// GET: Plants/Delete/5
		public ActionResult Delete(int? id)
		{
			if ((id == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Plant plant = _db.Plants.Find(id);
			if ((plant == null)) {
				return HttpNotFound();
			}
			return View(plant);
		}

		// POST: Plants/Delete/5
		[HttpPost()]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Plant plant = _db.Plants.Find(id);
			_db.Plants.Remove(plant);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpPost()]
		public ActionResult Import(HttpPostedFileBase uploadFilePlant, HttpPostedFileBase uploadFileThermalUnit)
		{
			if (uploadFilePlant != null && uploadFilePlant.ContentLength > 0 && uploadFileThermalUnit != null && uploadFileThermalUnit.ContentLength>0) {
				string plantFileExt;
                string thermUnitFileExt;

				plantFileExt = Path.GetExtension(uploadFilePlant.FileName).ToLower();
                thermUnitFileExt = Path.GetExtension(uploadFileThermalUnit.FileName).ToLower();

                if (plantFileExt == ".txt" && thermUnitFileExt == ".txt") {
					ImportHelper ih = new ImportHelper(_db);
					byte[] plantsFileBytes = new byte[uploadFilePlant.ContentLength + 1];
                    byte[] thermalUnitsFileBytes = new byte[uploadFileThermalUnit.ContentLength + 1];

					uploadFilePlant.InputStream.Read(plantsFileBytes, 0, uploadFilePlant.ContentLength);
                    uploadFileThermalUnit.InputStream.Read(thermalUnitsFileBytes, 0, uploadFileThermalUnit.ContentLength);

                    string plantFileText = Encoding.ASCII.GetString(plantsFileBytes);
                    string thermalUnitFileText = Encoding.ASCII.GetString(thermalUnitsFileBytes);

					if (ih.Plant(plantFileText, thermalUnitFileText )) {
						return RedirectToAction("index");
					} else {
						ViewBag.error = "Errore durante l'importazione del file";
						return View();
					}
				} else {
					ViewBag.error = "Sono ammmessi solo file .txt";
					return View();
				}

			} else {
				return View();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param Name="request"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		[HttpGet()]
		public ActionResult PagedPlants(IDataTablesRequest request)
		{
			if (ModelState.IsValid) {
				return _pm.GetPagedPlants(request);
			} else {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				//Return Json(New With {.success = False, .responseText = "La richiesta non è valida!"}, JsonRequestBehavior.AllowGet)
			}
		}

		/// <summary>
		/// Aggiunge un file all'impianto, come allegato.
		/// E' possibile allegare qualunque tipo di file.
		/// </summary>
		/// <param Name="ID">ID dell'impianto</param>
		/// <returns></returns>
		/// <remarks></remarks>
		[HttpGet()]
		public ActionResult AddMedium(int ID)
		{
			//http://cpratt.co/file-uploads-in-asp-net-mvc-with-view-models/
			if ((ID == null)) {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			if (!_db.Plants.Any(p => p.ID == ID)) {
				return HttpNotFound();
			}
			try {
				AddMediumPlantViewModel model = new AddMediumPlantViewModel();
				model.PlantId = ID;
				return View(model);
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult AddMedium(AddMediumPlantViewModel newMedium)
		{
			if ((newMedium.UploadFile == null) || newMedium.UploadFile.ContentLength <= 0) {
				ModelState.AddModelError("UploadFile", "Il file è richiesto!");
			}

			string[] validImageTypes = new string[] {
				"image/gif",
				"image/jpeg",
				"image/pjpeg",
				"image/png"
			};
			if (!validImageTypes.Contains(newMedium.UploadFile.ContentType)) {
				ModelState.AddModelError("UploadFile", "Questo tipo di file non è ancora supportato!");
			}


			try {
				if (ModelState.IsValid) {
					Medium medium = new Medium();
					string uploadDir = null;
					string uploadFileName = null;
					string uploadPath = null;
					string uploadURL = null;

					uploadDir = ConfigurationManager.AppSettings["MediaPlantFolder"];
					uploadFileName = Guid.NewGuid().ToString() + Path.GetExtension(newMedium.UploadFile.FileName);

					uploadPath = Path.Combine(Server.MapPath(uploadDir), uploadFileName);
					uploadURL = Path.Combine(uploadDir, uploadFileName);

					newMedium.UploadFile.SaveAs(uploadPath);

					medium.Description = newMedium.Description;
					medium.Tags = newMedium.Tags;
					medium.OriginalFileName = newMedium.UploadFile.FileName;
					medium.UploadFileName = uploadFileName;
					medium.ContentType = newMedium.UploadFile.ContentType;
					medium.Lenght = newMedium.UploadFile.ContentLength;

					Plant p = _db.Plants.Find(newMedium.PlantId);
					p.Media.Add(medium);

					_db.Media.Add(medium);
					_db.SaveChanges();
					return RedirectToAction("details", new { id = p.ID });
				} else {
					return View(newMedium);
				}
			} catch (Exception ex) {
				ViewBag.message = ex.ToString();
				return View("error");
			}

		}

		protected override void Dispose(bool disposing)
		{
			if ((disposing)) {
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

	}
}
