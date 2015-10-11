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
using Heat.ViewModels.ThermalUnits;
using System.Data.Entity;
namespace Heat
{

	public class ThermalUnitModelViewBuilder
	{


		private IHeatDBContext _db;
		public ThermalUnitModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		/// <summary>
		/// Genera il modello per la view Create, con la lista dei PlantID
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		public CreateThermalUnitViewModel GetCreateThermalUnitViewModel()
		{
			CreateThermalUnitViewModel result = new CreateThermalUnitViewModel();
			result.PlantIDSelected = false;

			result.PlantList = _db.Plants.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID, "");

			BindSelectLists(result);

			result.InstallationDate = DateAndTime.Now;

			return result;
		}


		/// <summary>
		/// Genera il modello della view Create, con il PlantID specificato.
		/// </summary>
		/// <param name="plantID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public CreateThermalUnitViewModel GetCreateThermalUnitViewModel(int plantID)
		{
			CreateThermalUnitViewModel result = new CreateThermalUnitViewModel();

			result.PlantIDSelected = true;
			result.PlantDescription = _db.Plants.Find(plantID).Name;

			BindSelectLists(result);

			result.InstallationDate = DateAndTime.Now;

			return result;

		}

		public void BindSelectLists(CreateThermalUnitViewModel model)
		{
			model.ManifacturerList = _db.Manifacturers.OrderBy(m => m.Name).ToList().ToSelectListItems(m => m.Name, m => m.ID, "");
			model.ModelList = _db.ManifacturerModels.Include(mm => mm.Manifacturer).OrderBy(mm => mm.Manifacturer.Name).ThenBy(mm => mm.Model).ToList().ToSelectListItems(x => x.Model, x => x.ID, "");
			model.FuelList = _db.Fuels.OrderBy(f => f.Name).ToList().ToSelectListItems(f => f.Name, f => f.ID, "");
			model.HeatTransferFluidList = _db.HeatTransferFluids.OrderBy(htf => htf.Name).ToList().ToSelectListItems(htf => htf.Name, htf => htf.ID, "");

		}

	}
}
