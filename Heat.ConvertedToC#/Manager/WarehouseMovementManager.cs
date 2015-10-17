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
namespace Heat
{

	public class WarehouseMovementManager
	{

		private IHeatDBContext _db;
		public WarehouseMovementManager(IHeatDBContext db)
		{
			_db = db;
		}

		/// <summary>
		/// Inserisce un movimento di magazzino
		/// </summary>
		/// <param Name="wareMov"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public bool Insert(WarehouseMovement wareMov)
		{
			//controlla se il movimento è di prelievo o di versamento.
			//se è di prelievo controlla se il magazzino richiede la verifica della giacenza.
			if (wareMov.CausalWarehouse.Type == CausalWarehouseTypeEnum.Prelievo & wareMov.Source.CheckStockBefore) {
				decimal InStock = default(decimal);
				InStock =(decimal) _db.WarehouseMovements.Where(x => x.Product.Equals(wareMov.Product)).Where(x => x.Source.Equals(wareMov.Source)).Sum(m => m.Quantity);
				if (InStock >(decimal) wareMov.Quantity) {
					_db.WarehouseMovements.Add(wareMov);
					return true;
				} else {
					return false;
				}
			} else {
				_db.WarehouseMovements.Add(wareMov);
				return true;
			}
		}


	}
}
