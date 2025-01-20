using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        public Task<ProductGet> GetProductById(int id); 

        public Task<IEnumerable<ProductPost>> GetAllByCategory(string category);

        public Task<ProductPost> AddProduct(Product prod);

        public Task<ProductPut> UpdateProduct(int id);

        public Task<ProductGet> DeleteProduct(int id);
    }
}
