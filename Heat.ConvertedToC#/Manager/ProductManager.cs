using System.Linq;
using System.Web.Mvc;
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
		/// <param Name="request"></param>
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

			//ordina il set
			orderedData = (IOrderedQueryable<Models.Product>) filteredData.OrderBy(sortColumn + " " + sortDirection);

			//pagina il set
			pagedData = (IOrderedQueryable<Models.Product>) orderedData.Skip(request.Start).Take(request.Length);

			//json-izza e ritorna
			return new DataTablesJsonResult(DataTablesResponse.Create(request, baseData.Count(), filteredData.Count(), pagedData.Project().To<IndexDataTableProductViewModel>()), JsonRequestBehavior.AllowGet);

		}
	}

}
