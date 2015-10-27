using Microsoft.VisualBasic;
using System.Linq;
using Heat.ViewModels.WorkActions;
namespace Heat
{

    public class WorkActionModelViewBuilder
	{

		private IHeatDBContext _db;
		public WorkActionModelViewBuilder(IHeatDBContext dbContext)
		{
			_db = dbContext;
		}

		public CreateWorkActionViewModel GetCreateWorkActionViewModel()
		{
			var result = new CreateWorkActionViewModel();
			result.ActionDate = DateAndTime.Now;
			result.PlantIDSelected = false;
			result.PlantList = _db.Plants.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");
			BindSelectListItems(result);
			return result;

		}

		public CreateWorkActionViewModel GetCreateWorkActionViewModel(int plantID)
		{
			CreateWorkActionViewModel result = new CreateWorkActionViewModel();

			result.PlantID = plantID;
			result.PlantIDSelected = true;
			result.ActionDate = DateAndTime.Now;

			BindSelectListItems(result);

			return result;
		}

		/// <summary>
		/// Crea le associazioni delle proprietà con le liste delle opzioni tra cui l'utente sceglie.
		/// E' necessario ricreare le liste di SelectListItem per le SelectList, dopo il POST.
		/// </summary>
		/// <param Name="model"></param>
		/// <remarks></remarks>

		public void BindSelectListItems(CreateWorkActionViewModel model)
		{
			model.TypeList = _db.ActionTypes.OrderBy(x => x.Description).ToList().ToSelectListItems(x => x.Description, x => x.ID.ToString(), model.TypeID.ToString());
			model.OperationList = _db.Operations.OrderBy(x => x.Description).ToList().ToSelectListItems(x => x.Description, x => x.ID.ToString(), model.OperationID.ToString());
			model.AssignedOperatorList = _db.WorkOperators.OrderBy(x => x.Name).ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), model.AssignedOperatorID.ToString());

		}
	}
}
