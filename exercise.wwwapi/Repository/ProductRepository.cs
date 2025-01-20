using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;

namespace exercise.wwwapi.Repository
{
    public class ProductRepository : IRepository
    {
        public Task<ProductPost> AddProduct(Product prod)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductGet>> GetAllByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<ProductGet> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductPut> UpdateProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
