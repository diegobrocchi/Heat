using System.Collections.Generic;
using System.Linq;
using Heat.ViewModels.ManifacturerModels;
using Heat.Models;
using System.Data.Entity;
namespace Heat
{

    public class ManifacturerModelViewBuilder
	{

		private IHeatDBContext _db;
		public ManifacturerModelViewBuilder(IHeatDBContext context)
		{
			_db = context;
		}

		public List<IndexManifacturerModelViewModel> GetIndexManifacturerModelViewModel()
		{
			List<IndexManifacturerModelViewModel> result = null;

			result = _db.ManifacturerModels.Include(x => x.Manifacturer).Select(x => new IndexManifacturerModelViewModel {
				ID = x.ID,
				Model = x.Model,
				Manifacturer = x.Manifacturer.Name
			}).ToList();

			return result;


		}

		public CreateManifacturerModelViewModel GetCreateManifacturerModelViewModel()
		{
			CreateManifacturerModelViewModel result = new CreateManifacturerModelViewModel();

			result.ManifacturerList = _db.Manifacturers.ToList().OrderBy(x => x.Name).ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");

			return result;
		}

		public EditManifacturerModelViewModel GetEditManifacturerModelViewModel(int id)
		{
			EditManifacturerModelViewModel result = new EditManifacturerModelViewModel();
			ManifacturerModel dbItem = null;

			dbItem = _db.ManifacturerModels.Find(id);

			result.ID = id;
			result.ManifacturerID = dbItem.ManifacturerID;
			result.Model = dbItem.Model;
			result.ManifacturerList = _db.Manifacturers.ToList().OrderBy(x => x.Name).ToSelectListItems(x => x.Name, x => x.ID.ToString(), result.ManifacturerID.ToString());

			return result;

		}
	}
}
