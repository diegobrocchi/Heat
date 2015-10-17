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
using System.Linq.Dynamic;
using AutoMapper.QueryableExtensions;
using Heat.ViewModels.Plants;

namespace Heat.Manager
{
	public class PlantManager
	{

		private IHeatDBContext _db;
		public PlantManager(IHeatDBContext context)
		{
			_db = context;
		}

		/// <summary>
		/// Esegue una ricerca sui Plants in base alla request del datatable.
		/// </summary>
		/// <param Name="request"></param>
		/// <returns></returns>
		public DataTablesJsonResult GetPagedPlants(IDataTablesRequest request)
		{
			IQueryable<Plant> baseData = null;
			IQueryable<Plant> filteredData = null;
			IOrderedQueryable<Plant> orderedData = null;
			IOrderedQueryable<Plant> pagedData = null;

			//per prima cosa tutti gli impianti
			baseData = _db.Plants;

			//poi filtra in base al termine inserito dall'utente
			filteredData = baseData.Where(p => p.Name.Contains(request.Search.Value));

			string sortColumn = "plantdistinctcode";
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
			orderedData =(IOrderedQueryable<Models.Plant>) filteredData.OrderBy(sortColumn + " " + sortDirection);

			//pagina il set
			pagedData =(IOrderedQueryable<Models.Plant>) orderedData.Skip(request.Start).Take(request.Length);

			//json-izza e ritorna
			return new DataTablesJsonResult(DataTablesResponse.Create(request, baseData.Count(), filteredData.Count(), pagedData.Project().To<IndexDataTablePlantViewModel>()), JsonRequestBehavior.AllowGet);

		}

	}
}

