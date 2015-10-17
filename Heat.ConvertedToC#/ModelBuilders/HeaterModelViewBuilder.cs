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
using Heat.ViewModels.Heaters;
using System.Data.Entity;
namespace Heat
{


	public class HeaterModelViewBuilder
	{


		private IHeatDBContext _db;
		public HeaterModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		public CreateHeaterViewModel GetCreateHeaterViewModel(int thermalUnitID)
		{
			CreateHeaterViewModel result = new CreateHeaterViewModel();

			result.ThermalUnitID = thermalUnitID;
			result.ThermalUnitDescription = _db.ThermalUnits.Find(thermalUnitID).SerialNumber;
			result.ManifacturerList = _db.Manifacturers.OrderBy(m => m.Name).ToList().ToSelectListItems(m => m.Name, m => m.ID.ToString(), "");
			result.FuelList = _db.Fuels.OrderBy(f => f.Name).ToList().ToSelectListItems(f => f.Name, f => f.ID.ToString(), "");
			result.ModelList = _db.ManifacturerModels.Include(mm => mm.Manifacturer).OrderBy(mm => mm.Manifacturer.Name).ThenBy(mm => mm.Model).ToList().ToSelectListItems(x => x.Model, x => x.ID.ToString(), "");

			result.InstallationDate = DateAndTime.Now;

			return result;

		}

	}
}
