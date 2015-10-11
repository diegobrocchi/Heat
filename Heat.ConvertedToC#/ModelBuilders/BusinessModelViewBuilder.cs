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
using Heat.Manager;
namespace Heat
{

	public class BusinessModelViewBuilder
	{

		private IHeatDBContext _db;
		public BusinessModelViewBuilder(IHeatDBContext context)
		{
			_db = context;
		}

		//Public Function GetSortedAndPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As IList(Of Customer)
		//    Dim cbl As New CustomerManager(_db)

		//    Return cbl.GetPagedCustomer(sortOrder, skip, take)

		//End Function

	}
}
