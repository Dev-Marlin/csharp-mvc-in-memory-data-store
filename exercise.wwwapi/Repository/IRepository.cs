using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        public Task<Product> GetProductById(int id); 

        public Task<IEnumerable<Product>> GetAllByCategory(string category);

        public Task<Product> AddProduct(Product prod);

        public Task<Product> UpdateProduct(int id, ProductPut pp);

        public Task<Product> DeleteProduct(int id);
    }
}
