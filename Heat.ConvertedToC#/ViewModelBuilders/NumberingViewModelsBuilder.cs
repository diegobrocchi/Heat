using System.Collections.Generic;
using System.Linq;
using Heat.Models;
using AutoMapper;
namespace Heat
{

    public class NumberingViewModelsBuilder
	{

		private IHeatDBContext _db;

		public NumberingViewModelsBuilder(IHeatDBContext context)
		{
			_db = context;
		}

		public CreateNumberingViewModel GetCreateModel()
		{
			CreateNumberingViewModel result = new CreateNumberingViewModel();
			result.FinalSerialSchemaList = _db.SerialSchemes.ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");
			result.TempSerialSchemaList = _db.SerialSchemes.ToList().ToSelectListItems(x => x.Name, x => x.ID.ToString(), "");

			return result;
		}

		public EditNumberingViewModel GetEditModel(int id)
		{
			EditNumberingViewModel result = new EditNumberingViewModel();
			Numbering editingItem = null;

			editingItem = _db.Numberings.AsNoTracking().Include("FinalSerialSchema").Include("TempSerialSchema").ToList().Find(x => x.ID == id);
			// _db.Numberings.Find(id)

			result = AutoMapper.Mapper.Map<EditNumberingViewModel>(editingItem);

			result.FinalSerialSchemaList = _db.SerialSchemes.ToSelectListItems(x => x.Name, x => x.ID.ToString() , editingItem.FinalSerialSchema.ID.ToString(), false);
			result.TempSerialSchemaList = _db.SerialSchemes.ToSelectListItems(x => x.Name, x => x.ID.ToString(), editingItem.TempSerialSchema.ID.ToString(), false);

			return result;
		}

		public List<IndexNumberingViewModel> GetIndexModel()
		{
			List<IndexNumberingViewModel> result = null;
			List<Numbering> numberingList = null;

			numberingList = _db.Numberings.ToList();
			result = Mapper.Map<List<IndexNumberingViewModel>>(numberingList);

			return result;
		}

	}
}

//Public Class NumberingViewModelsBuilder
//    Private _db As IHeatDBContext

//    Sub New()
//    End Sub

//    Sub New(context As IHeatDBContext)
//        _db = context
//    End Sub
//    Public Function GetCreateModel() As CreateNumberingViewModel
//        Dim result As New CreateNumberingViewModel
//        result.FinalSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")
//        result.TempSerialSchema = _db.SerialSchemes.ToList.ToSelectListItems(Function(x) x.Name, Function(x) x.ID, "")

//        Return result
//    End Function

//End Class
