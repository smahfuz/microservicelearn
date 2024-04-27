using catalog.API.Models;
using MongoRepo.Interfaces.Manager;

namespace catalog.API.Interface.Manager
{
    public interface IProductManager : ICommonManager<Product>
    {
        public List<Product> GetByCatagory(string catagory);
    }
}
