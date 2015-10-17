using AutoMapper;
namespace Heat
{

    public static class AutomapperExtensions
	{

		public static void Bidirectional<TSource, TDestination>(this IMappingExpression<TSource, TDestination> @this)
		{
			Mapper.CreateMap<TDestination, TSource>();
		}






	}
}
