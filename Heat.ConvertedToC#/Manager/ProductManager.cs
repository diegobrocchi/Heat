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
using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using Heat.Models;
using AutoMapper.QueryableExtensions;
using System.Linq.Dynamic;
using Heat.ViewModels.Product;

namespace Heat.Manager
{

	public class ProductManager
	{
		private IHeatDBContext _db;
		public ProductManager(IHeatDBContext context)
		{
			_db = context;
		}

		/// <summary>
		/// Esegue una ricerca sui Products in base alla request del datatable.
		/// Restituisce un DataTablesJsonResult consumabile dalla datatable che l'ha richiesto.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public DataTablesJsonResult GetPagedProducts(IDataTablesRequest request)
		{
			IQueryable<Product> baseData = null;
			IQueryable<Product> filteredData = null;
			IOrderedQueryable<Product> orderedData = null;
			IOrderedQueryable<Product> pagedData = null;

			//per prima cosa tutti i prodotti
			baseData = _db.Products;

			//poi filtra in base al termine inserito dall'utente
			filteredData = baseData.Where(p => p.Description.Contains(request.Search.Value));

			string sortColumn = "description";
			string sortDirection = "ASC";
			foreach (IColumn column_loopVariable in request.Columns) {
				column = column_loopVariable;
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

			//ordina il set
			orderedData = filteredData.OrderBy(sortColumn + " " + sortDirection);

			//pagina il set
			pagedData = orderedData.Skip(request.Start).Take(request.Length);

			//json-izza e ritorna
			return new DataTablesJsonResult(DataTablesResponse.Create(request, baseData.Count(), filteredData.Count(), pagedData.Project().To<IndexDataTableProductViewModel>()), JsonRequestBehavior.AllowGet);

		}
	}

}
