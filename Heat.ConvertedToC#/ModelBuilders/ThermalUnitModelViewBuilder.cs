using Microsoft.VisualBasic;
using System.Linq;
using Heat.ViewModels.ThermalUnits;
using System.Data.Entity;
namespace Heat
{

    public class ThermalUnitModelViewBuilder
	{


		private IHeatDBContext _db;
		public ThermalUnitModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		/// <summary>
		/// Genera il modello per la view Create, con la lista dei PlantID
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		public CreateThermalUnitViewModel GetCreateThermalUnitViewModel()
		{
			CreateThermalUnitViewModel result = new CreateThermalUnitViewModel();
			result.PlantIDSelected = false;

			result.PlantList = _db.Plants.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");

			BindSelectLists(result);

			result.InstallationDate = DateAndTime.Now;

			return result;
		}


		/// <summary>
		/// Genera il modello della view Create, con il PlantID specificato.
		/// </summary>
		/// <param Name="plantID"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public CreateThermalUnitViewModel GetCreateThermalUnitViewModel(int plantID)
		{
			CreateThermalUnitViewModel result = new CreateThermalUnitViewModel();

			result.PlantIDSelected = true;
			result.PlantDescription = _db.Plants.Find(plantID).Name;

			BindSelectLists(result);

			result.InstallationDate = DateAndTime.Now;

			return result;

		}

		public void BindSelectLists(CreateThermalUnitViewModel model)
		{
			model.ManifacturerList = _db.Manifacturers.OrderBy(m => m.Name).ToList().ToSelectListItems(m => m.Name, m => m.ID.ToString(), "");
			model.ModelList = _db.ManifacturerModels.Include(mm => mm.Manifacturer).OrderBy(mm => mm.Manifacturer.Name).ThenBy(mm => mm.Model).ToList().ToSelectListItems(x => x.Model, x => x.ID.ToString(), "");
			model.FuelList = _db.Fuels.OrderBy(f => f.Name).ToList().ToSelectListItems(f => f.Name, f => f.ID.ToString(), "");
			model.HeatTransferFluidList = _db.HeatTransferFluids.OrderBy(htf => htf.Name).ToList().ToSelectListItems(htf => htf.Name, htf => htf.ID.ToString(), "");

		}

	}
}
