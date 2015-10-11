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
using Heat.ViewModels.Customers;
using AutoMapper;
namespace Heat
{

	public class CustomerModelViewBuilder
	{


		private IHeatDBContext _db;
		public CustomerModelViewBuilder(IHeatDBContext db)
		{
			_db = db;
		}

		public IndexCustomerViewModel GetIndexCustomerViewModel(bool includeDisabled)
		{
			IndexCustomerViewModel result = new IndexCustomerViewModel();
			List<Customer> customerList = null;

			if (includeDisabled) {
				customerList = _db.Customers.OrderBy(c => c.Name).ToList();
				result.IsIncludeDisable = true;
			} else {
				customerList = _db.Customers.Where(c => c.IsEnabled == true).OrderBy(c => c.Name).ToList();
				result.IsIncludeDisable = false;
			}

			result.HasDisabled = _db.Customers.Where(c => c.IsEnabled == false).Count() > 0;
			result.Rows = Mapper.Map<List<IndexCustomerGridViewModel>>(customerList);

			return result;

		}

		public DisableCustomerViewModel GetDisableCustomerViewModel(int id)
		{
			DisableCustomerViewModel result = new DisableCustomerViewModel();
			Customer c = null;

			c = _db.Customers.Find(id);
			result.ID = c.ID;
			result.CustomerName = c.Name;

			return result;

		}

		public EnableCustomerViewModel GetEnableCustomerViewModel(int id)
		{
			EnableCustomerViewModel result = new EnableCustomerViewModel();
			Customer c = null;
			c = _db.Customers.Find(id);

			result.ID = c.ID;
			result.CustomerName = c.Name;
			result.DisableDate = c.DisableDate;

			return result;
		}
		public EditCustomerViewModel GetEditCustomerViewModel(int id)
		{
			EditCustomerViewModel result = new EditCustomerViewModel();
			Customer editingItem = null;

			editingItem = _db.Customers.Find(id);

			result = Mapper.Map<EditCustomerViewModel>(editingItem);

			return result;
		}


		public ManageCustomerViewModel GetManageCustomerViewModel(int id)
		{
			ManageCustomerViewModel result = new ManageCustomerViewModel();
			Customer dbCustomer = null;
			dbCustomer = _db.Customers.Find(id);

			result.ID = id;
			result.Name = dbCustomer.Name;
			result.IsEnabled = dbCustomer.IsEnabled;

			return result;
		}
	}
}
