using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Heat.Models;
using Heat.ViewModels.Plants;
using System.Data.Entity;
namespace Heat
{

	public class PlantModelViewBuilder
	{


		private IHeatDBContext _db;
		public PlantModelViewBuilder(IHeatDBContext dbcontext)
		{
			_db = dbcontext;
		}

		//Function GetCreatePlantViewModel() As CreatePlantViewModel
		//    Dim result As New CreatePlantViewModel

		//    Return result
		//End Function

		public AddContactPlantViewModel GetAddContactPlantViewModel(int plantID)
		{
			AddContactPlantViewModel result = new AddContactPlantViewModel();

			result.PlantID = plantID;
			result.AddressTypeList = _db.AddressTypes.OrderBy(x => x.Description).ToList().ToSelectListItems(x => x.Description, x => x.ID.ToString(), "");

			return result;


		}

		public AddThermInfoPlantViewModel GetAddThermInfoPlantViewModel(int plantID)
		{
			AddThermInfoPlantViewModel result = new AddThermInfoPlantViewModel();

			result.PlantID = plantID;
			result.PlantClassList = _db.PlantClasses.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");
			result.PlantTypeList = _db.PlantTypes.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");

			return result;

		}

		public List<IndexPlantViewModel> GetIndexPlantViewModel()
		{
			List<IndexPlantViewModel> result = new List<IndexPlantViewModel>();

			result = _db.Plants.Include(x => x.BuildingAddress).OrderBy(x => x.PlantDistinctCode).Select(x => new IndexPlantViewModel {
				ID = x.ID,
				Address = x.BuildingAddress.Address + " " + x.BuildingAddress.City,
				Name = x.Name,
				PlantClass = x.PlantClass.Name,
				PlantType = x.PlantType.Name,
				PlantDistinctCode = x.PlantDistinctCode
			}).ToList();

			return result;

		}

		/// <summary>
		/// Costruisce il modello per la vista di dettaglio dell'impianto.
		/// La vista di dettaglio è organizzata in tab e in ogni tab una partial con un modello dedicato.
		/// </summary>
		/// <param Name="id"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public DetailsPlantViewModel GetDetailsPlantViewModel(int id)
		{
			DetailsPlantViewModel result = new DetailsPlantViewModel();

			result.IdentifyViewModel = GetDetailsIdentifyPlantViewModel(id);
			result.ContactViewModel = GetDetailsContactPlantViewModel(id);
			result.ThermalViewModel = GetDetailsThermalPlantViewModel(id);
			result.MediaViewModel = GetDetailsMediaPlantViewModel(id);
			result.ServiceViewModel = GetDetailsServicePlantViewModel(id);

			return result;
		}

		public DetailsIdentifyPlantViewModel GetDetailsIdentifyPlantViewModel(int id)
		{
			DetailsIdentifyPlantViewModel result = new DetailsIdentifyPlantViewModel();

			Plant p = null;
			PlantBuilding pb = null;

			p = _db.Plants.Find(id);
			pb = p.BuildingAddress;

			//Map Plant --> DetailsIdentifyPlantViewModel
			//aggiorna le proprietà dell'oggetto di destinazione (result)
			AutoMapper.Mapper.Map<Plant, DetailsIdentifyPlantViewModel>(p, result);

			//Map PlantBuilding --> DetailsIdentifyPlantViewModel
			//aggiorna le proprietà dell'oggetto di destinazione (result)
			AutoMapper.Mapper.Map<PlantBuilding, DetailsIdentifyPlantViewModel>(pb, result);

			return result;
		}

		public DetailsContactPlantViewModel GetDetailsContactPlantViewModel(int id)
		{
			DetailsContactPlantViewModel result = new DetailsContactPlantViewModel();
			List<Contact> cl = null;
			cl = _db.Plants.Include(p => p.Contacts.Select(c => c.Address)).Where(x => x.ID == id).First().Contacts;

			//Map Plant --> DetailsContactPlantViewModel
			result.ID = id;
			result.Contacts = cl;

			return result;
		}

		public DetailsThermalPlantViewModel GetDetailsThermalPlantViewModel(int id)
		{
			DetailsThermalPlantViewModel result = new DetailsThermalPlantViewModel();
			Plant p = null;
			PlantBuilding pb = null;
			ThermalUnit tu = null;

			p = _db.Plants.Include(x => x.ThermalUnit).Include(x => x.ThermalUnit.Manifacturer).Include(x => x.ThermalUnit.Model).Include(x => x.ThermalUnit.Fuel).Include(x => x.ThermalUnit.HeatTransferFluid).Where(x => x.ID == id).First();

			pb = p.BuildingAddress;
			tu = p.ThermalUnit;

			//Map Plant --> DetailsThermalPlantViewModel
			AutoMapper.Mapper.Map<Plant, DetailsThermalPlantViewModel>(p, result);

			//Map PlantBuilding --> DetailsThermalPlantViewModel
			AutoMapper.Mapper.Map<PlantBuilding, DetailsThermalPlantViewModel>(pb, result);

			//Map ThermalUnit --> DetailsThermaPlantViewModel
			AutoMapper.Mapper.Map<ThermalUnit, DetailsThermalPlantViewModel>(tu, result);

			return result;
		}

		public DetailsMediaPlantViewModel GetDetailsMediaPlantViewModel(int id)
		{
			DetailsMediaPlantViewModel result = new DetailsMediaPlantViewModel();
			Plant p = null;

			p = _db.Plants.Include(x => x.Media).Where(x => x.ID == id).First();

			result.ID = id;
			result.Media = p.Media;

			result.BaseHref = ConfigurationManager.AppSettings["MediaPlantFolder"];
			return result;

		}

		public DetailsServicePlantViewModel GetDetailsServicePlantViewModel(int id)
		{
			DetailsServicePlantViewModel result = new DetailsServicePlantViewModel();
			PlantService ps = null;

			ps = _db.Plants.Include(x => x.Service).Where(x => x.ID == id).First().Service;


			if ((ps != null)) {
				result.ID = ps.ID;
				result.PlantID = id;
				result.LegalExpirationDate = ps.LegalExpirationDate;
				result.Periodicity = ps.Periodicity;
				result.PlannedServiceDate = ps.PlannedServiceDate;
				result.PreviousServiceDate = ps.PreviousServiceDate;

			}

			return result;
		}
		public ManagePlantViewModel GetManagePlantViewModel(int id)
		{
			ManagePlantViewModel result = new ManagePlantViewModel();
			Plant p = null;

			p = _db.Plants.Find(id);

			result.ID = id;
			result.Name = p.Name;

			return result;
		}
	}
}
