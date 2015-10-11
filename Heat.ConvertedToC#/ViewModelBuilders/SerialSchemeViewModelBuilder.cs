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

	public class SerialSchemeViewModelBuilder
	{


		private IHeatDBContext _db;
		public SerialSchemeViewModelBuilder(IHeatDBContext context)
		{
			if ((context == null)) {
				throw new Exception("Context!");
			}

			_db = context;
		}

		public List<IndexSerialSchemeViewModel> getListViewModel()
		{
			List<IndexSerialSchemeViewModel> result = new List<IndexSerialSchemeViewModel>();

			List<SerialScheme> l = new List<SerialScheme>();
			l = _db.SerialSchemes.ToList();

			result = Mapper.Map<List<SerialScheme>, List<IndexSerialSchemeViewModel>>(l);

			return result;


		}

	}
}
