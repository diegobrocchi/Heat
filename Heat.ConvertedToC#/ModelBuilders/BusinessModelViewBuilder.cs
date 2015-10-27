namespace Heat
{

    public class BusinessModelViewBuilder
	{

		private IHeatDBContext _db;
		public BusinessModelViewBuilder(IHeatDBContext context)
		{
			_db = context;
		}

		//Public Function GetSortedAndPagedCustomer(sortOrder As String, skip As Integer, take As Integer) As IList(Of Customer)
		//    Dim cbl As New CustomerManager(_db)

		//    Return cbl.GetPagedCustomer(sortOrder, skip, take)

		//End Function

	}
}
