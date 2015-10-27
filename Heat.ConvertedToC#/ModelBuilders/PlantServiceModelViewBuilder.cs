using Heat.ViewModels.PlantServices;
namespace Heat
{

    public class PlantServiceModelViewBuilder
	{


		private IHeatDBContext _db;
		public PlantServiceModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		public CreatePlantServiceViewModel GetCreatePlantServiceViewModel(int plantID)
		{
			CreatePlantServiceViewModel result = new CreatePlantServiceViewModel();

			result.PlantID = plantID;
			result.PlantDescription = _db.Plants.Find(plantID).Name;

			return result;

		}

	}
}
