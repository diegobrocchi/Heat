using Microsoft.VisualBasic;
using System.Linq;
using Heat.ViewModels.Heaters;
using System.Data.Entity;
namespace Heat
{


    public class HeaterModelViewBuilder
	{


		private IHeatDBContext _db;
		public HeaterModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		public CreateHeaterViewModel GetCreateHeaterViewModel(int thermalUnitID)
		{
			CreateHeaterViewModel result = new CreateHeaterViewModel();

			result.ThermalUnitID = thermalUnitID;
			result.ThermalUnitDescription = _db.ThermalUnits.Find(thermalUnitID).SerialNumber;
			result.ManifacturerList = _db.Manifacturers.OrderBy(m => m.Name).ToList().ToSelectListItems(m => m.Name, m => m.ID.ToString(), "");
			result.FuelList = _db.Fuels.OrderBy(f => f.Name).ToList().ToSelectListItems(f => f.Name, f => f.ID.ToString(), "");
			result.ModelList = _db.ManifacturerModels.Include(mm => mm.Manifacturer).OrderBy(mm => mm.Manifacturer.Name).ThenBy(mm => mm.Model).ToList().ToSelectListItems(x => x.Model, x => x.ID.ToString(), "");

			result.InstallationDate = DateAndTime.Now;

			return result;

		}

	}
}
