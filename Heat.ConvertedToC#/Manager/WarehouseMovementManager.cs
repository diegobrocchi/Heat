using System.Linq;
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
