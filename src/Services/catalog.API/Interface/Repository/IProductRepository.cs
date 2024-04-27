using catalog.API.Models;
using MongoRepo.Interfaces.Repository;

namespace catalog.API.Interface.Repository
{
    public interface IProductRepository : ICommonRepository<Product>
    {
    }
}
