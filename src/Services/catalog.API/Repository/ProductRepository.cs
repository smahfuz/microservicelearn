using catalog.API.Interface.Repository;
using catalog.API.Models;
using Catalog.API.Context;
using MongoRepo.Repository;

namespace catalog.API.Repository
{
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository() : base(new CatalogDbContext())
        {
        }

 
    }
}
