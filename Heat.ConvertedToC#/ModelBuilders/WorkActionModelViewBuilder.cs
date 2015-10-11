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
using Heat.ViewModels.WorkActions;
namespace Heat
{

	public class WorkActionModelViewBuilder
	{

		private IHeatDBContext _db;
		public WorkActionModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		public CreateWorkActionViewModel GetCreateWorkActionViewModel()
		{
			var result = new CreateWorkActionViewModel();
			result.ActionDate = DateAndTime.Now;
			result.PlantIDSelected = false;
			result.PlantList = _db.Plants.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID, "");
			BindSelectListItems(result);
			return result;

		}

		public CreateWorkActionViewModel GetCreateWorkActionViewModel(int plantID)
		{
			CreateWorkActionViewModel result = new CreateWorkActionViewModel();

			result.PlantID = plantID;
			result.PlantIDSelected = true;
			result.ActionDate = DateAndTime.Now;

			BindSelectListItems(result);

			return result;
		}

		/// <summary>
		/// Crea le associazioni delle proprietà con le liste delle opzioni tra cui l'utente sceglie.
		/// E' necessario ricreare le liste di SelectListItem per le SelectList, dopo il POST.
		/// </summary>
		/// <param name="model"></param>
		/// <remarks></remarks>

		public void BindSelectListItems(CreateWorkActionViewModel model)
		{
			model.TypeList = _db.ActionTypes.OrderBy(x => x.Description).ToList().ToSelectListItems(x => x.Description, x => x.ID, model.TypeID);
			model.OperationList = _db.Operations.OrderBy(x => x.Description).ToList().ToSelectListItems(x => x.Description, x => x.ID, model.OperationID);
			model.AssignedOperatorList = _db.WorkOperators.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID, model.AssignedOperatorID);

		}
	}
}
