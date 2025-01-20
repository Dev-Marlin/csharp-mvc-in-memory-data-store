using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;
using Microsoft.EntityFrameworkCore.InMemory;

namespace exercise.wwwapi.Repository
{
    public class ProductRepository : IRepository
    {
        private DataContext db;

        public ProductRepository(DataContext db)
        {
            this.db = db;
        }

        public async Task<ProductGet> GetProductById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ProductPost>> GetAllByCategory(string category)
        {
            throw new NotImplementedException();
        }
        public async Task<ProductPost> AddProduct(Product prod)
        {
            throw new NotImplementedException();
        }
        public async Task<ProductPut> UpdateProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductGet> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }


    }
}
