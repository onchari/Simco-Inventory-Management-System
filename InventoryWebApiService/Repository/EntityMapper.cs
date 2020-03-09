

namespace InventoryWebApiService.Repository
{
    public class EntityMapper<TSource, TDestination> where TSource  : class where TDestination : class
    {
        public EntityMapper()
        {
            Mapper.CreateMap<Models.Product, Product>();
            Mapper.CreateMap<Product, Models.Product>();
        }

        public TDestination Translate(TSource obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }
}
//https://www.c-sharpcorner.com/article/web-api-crud-operations-and-consume-service-in-asp-net-mvc-application/