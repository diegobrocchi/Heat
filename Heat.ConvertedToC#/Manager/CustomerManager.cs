using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Web.Mvc;
using Heat.Models;
using DataTables.AspNet.Mvc5;
using DataTables.AspNet.Core;
using System.Linq.Dynamic;
using AutoMapper.QueryableExtensions;
using Heat.ViewModels.Customers;



namespace Heat.Manager
{

    public class CustomerManager
	{

		private IHeatDBContext _db;
		public CustomerManager(IHeatDBContext context)
		{
			_db = context;
		}

		//Public Function GetPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As List(Of Customer)

		//    Return _db.Customers.OrderBy(Function(customer) customer.Name).Skip(skip).Take(take).ToList

		//End Function


		/// <summary>
		/// Esegue una ricerca sui clienti in base alla richiesta del controllo Datatable.
		/// </summary>
		/// <param Name="request"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public DataTablesJsonResult GetPagedCustomers(IDataTablesRequest request, bool enabled)
		{

			IQueryable<Customer> baseData = null;
			IQueryable<Customer> filteredData = null;
			IQueryable<Customer> orderedData = null;
			IQueryable<Customer> pagedData = null;

			//per prima cosa seleziona dalla base dati solo i Customer abilitati/disabilitati
			baseData = _db.Customers.Where(c => c.IsEnabled == enabled);

			//poi filtra i dati in base alla indicazione dell'utente (Case Insensitive)
			filteredData = baseData.Where(c => c.Name.Contains(request.Search.Value) | c.City.Contains(request.Search.Value));

			//poi ordina (non è supportato l'ordiNamento multicolonna, quindi ordina per la prima colonna su cui è imposto l'ordiNamento)
			string sortColumn = "Name";
			string sortDirection = "ASC";
			foreach (IColumn column in request.Columns) {
				
				if (column.IsSortable) {
					if ((column.Sort != null)) {
						sortColumn = column.Field;
						if (column.Sort.Direction == DataTables.AspNet.Core.SortDirection.Ascending) {
							sortDirection = "ASC";
						} else {
							sortDirection = "DESC";
						}
						break; // TODO: might not be correct. Was : Exit For
					}
				}
			}

			orderedData = filteredData.OrderBy(sortColumn + " " + sortDirection);

			pagedData = orderedData.Skip(request.Start).Take(request.Length);

			return new DataTablesJsonResult(DataTablesResponse.Create(request, baseData.Count(), filteredData.Count(), pagedData.Project().To<IndexDataTableCustomerViewModel>()), JsonRequestBehavior.AllowGet);

		}


		public void EnableCustomer(Customer customer)
		{
			this.EnableCustomer(customer.ID);
		}

		public void EnableCustomer(int customerID)
		{
			Customer c = null;
			c = _db.Customers.Find(customerID);
			if ((c == null)) {
				throw new Exception("Impossibile trovare il Cliente richiesto!");
			}

			c.IsEnabled = true;
			c.EnableDate = DateAndTime.Now;

		}

		public void DisableCustomer(Customer customer)
		{
			this.DisableCustomer(customer.ID);
		}

		public void DisableCustomer(int customerID)
		{
			Customer c = null;
			c = _db.Customers.Find(customerID);
			if ((c == null)) {
				throw new Exception("Impossibile trovare il Cliente richiesto!");
			}

			c.IsEnabled = false;
			c.DisableDate = DateAndTime.Now;
		}
	}

}
