using System.Collections.Generic;
using System.Linq;

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
