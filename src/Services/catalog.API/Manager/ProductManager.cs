using catalog.API.Interface.Manager;
using catalog.API.Models;
using catalog.API.Repository;
using MongoRepo.Interfaces.Manager;
using MongoRepo.Manager;

namespace catalog.API.Manager
{
    public class ProductManager : CommonManager<Product>, IProductManager
    {
        public ProductManager() : base(new ProductRepository())
        {

        }

        public List<Product> GetByCatagory(string catagory)
        {
            return GetAll(c => c.Category == catagory).ToList();
        }
    }
}
