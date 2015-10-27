using System;
using System.Collections.Generic;
using System.Linq;
using Heat.Models;
using AutoMapper;
namespace Heat
{

    public class SerialSchemeViewModelBuilder
	{


		private IHeatDBContext _db;
		public SerialSchemeViewModelBuilder(IHeatDBContext context)
		{
			if ((context == null)) {
				throw new Exception("Context!");
			}

			_db = context;
		}

		public List<IndexSerialSchemeViewModel> getListViewModel()
		{
			List<IndexSerialSchemeViewModel> result = new List<IndexSerialSchemeViewModel>();

			List<SerialScheme> l = new List<SerialScheme>();
			l = _db.SerialSchemes.ToList();

			result = Mapper.Map<List<SerialScheme>, List<IndexSerialSchemeViewModel>>(l);

			return result;


		}

	}
}
