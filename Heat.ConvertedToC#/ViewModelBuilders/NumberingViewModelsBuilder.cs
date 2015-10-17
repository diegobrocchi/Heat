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
using AutoMapper;
namespace Heat
{

	public class NumberingViewModelsBuilder
	{

		private IHeatDBContext _db;

		public NumberingViewModelsBuilder(IHeatDBContext context)
		{
			_db = context;
		}

		public CreateNumberingViewModel GetCreateModel()
		{
			CreateNumberingViewModel result = new CreateNumberingViewModel();
			result.FinalSerialSchemaList = _db.SerialSchemes.ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");
			result.TempSerialSchemaList = _db.SerialSchemes.ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");

			return result;
		}

		public EditNumberingViewModel GetEditModel(int id)
		{
			EditNumberingViewModel result = new EditNumberingViewModel();
			Numbering editingItem = null;

			editingItem = _db.Numberings.AsNoTracking().Include("FinalSerialSchema").Include("TempSerialSchema").ToList().Find(x => x.ID == id);
			// _db.Numberings.Find(id)

			result = AutoMapper.Mapper.Map<EditNumberingViewModel>(editingItem);

			result.FinalSerialSchemaList = _db.SerialSchemes.ToSelectListItems(x => x.Name, x => x.ID.ToString() , editingItem.FinalSerialSchema.ID.ToString(), false);
			result.TempSerialSchemaList = _db.SerialSchemes.ToSelectListItems(x => x.Name, x => x.ID.ToString(), editingItem.TempSerialSchema.ID.ToString(), false);

			return result;
		}

		public List<IndexNumberingViewModel> GetIndexModel()
		{
			List<IndexNumberingViewModel> result = null;
			List<Numbering> numberingList = null;

			numberingList = _db.Numberings.ToList();
			result = Mapper.Map<List<IndexNumberingViewModel>>(numberingList);

			return result;
		}

	}
}

//Public Class NumberingViewModelsBuilder
//    Private _db As IHeatDBContext

//    Sub New()
//    End Sub

//    Sub New(context As IHeatDBContext)
//        _db = context
//    End Sub
//    Public Function GetCreateModel() As CreateNumberingViewModel
//        Dim result As New CreateNumberingViewModel
//        result.FinalSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
//        result.TempSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

//        Return result
//    End Function

//End Class
