using exercise.wwwapi.Data;
using exercise.wwwapi.Models;
using exercise.wwwapi.ViewModel;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Product> GetProductById(int id)
        {
            return await db.Products.FindAsync(id);
        }
        public async Task<IEnumerable<Product>> GetAllByCategory(string category)
        {
            return await db.Products.ToListAsync();
        }
        public async Task<Product> AddProduct(Product prod)
        {
            await db.Products.AddAsync(prod);
            await db.SaveChangesAsync();

            return prod;
        }
        public async Task<Product> UpdateProduct(int id, ProductPut pp)
        {
            Product temp = await db.Products.FindAsync(id);
            var entity = db.Products.Update(temp);

            if (entity != null)
            {
                if (pp.Name != null)
                {
                    //temp.Name = pp.Name;
                    entity.Entity.Name = pp.Name;
                }
                if (pp.Category != null)
                {
                    //temp.Category = pp.Category;
                    entity.Entity.Category = pp.Category;
                }
                if (pp.Price != null)
                {
                    //temp.Price = (int)pp.Price;
                    entity.Entity.Price = (int)pp.Price;
                }
            }

            await db.SaveChangesAsync();

            return temp;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var deleted = await db.Products.FindAsync(id);
            db.Products.Remove(deleted);
            await db.SaveChangesAsync();

            return deleted;
        }


    }
}
