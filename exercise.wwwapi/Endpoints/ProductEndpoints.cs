using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;
using exercise.wwwapi.ViewModel;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class ProductEndpoints
    {
        public static void ConfigureProductEndpoints(this WebApplication app)
        {
            var prod = app.MapGroup("products");

            prod.MapGet("/getbyid/{id}", GetProductById);

            prod.MapGet("/getallbycategory/{category}", GetAllByCategory);

            prod.MapPost("/createproduct", AddProduct);

            prod.MapPut("/updateproduct/{id}", UpdateProduct);

            prod.MapDelete("deleteproduct/{id}", DeleteProduct);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetProductById(IRepository repository, int id)
        {
            Product prodById = await repository.GetProductById(id);

            if (prodById == null)
            {
                return TypedResults.NotFound($"Product by id {id} do not exist");
            }

            return TypedResults.Ok(prodById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAllByCategory(IRepository repository, string category)
        {
            IEnumerable<Product> all = await repository.GetAllByCategory(category);

            if (all == null)
            {
                return TypedResults.NotFound($"Product by category {category} do not exist");
            }

            return TypedResults.Ok(all);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> AddProduct(IRepository repository, Product prod)
        {
            /*if (repository.GetProductById(prod.Id) != null)
                return TypedResults.BadRequest($"Product with the name {prod.Name} do already exist");
            */

            var temp = await repository.AddProduct(prod);
            return TypedResults.Created("",prod);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateProduct(IRepository repository, int id, ProductPut pp)
        {
            var temp = await repository.UpdateProduct(id, pp);
            return TypedResults.Ok(temp);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteProduct(IRepository repository, int id)
        {
            var temp = await repository.DeleteProduct(id);
            return TypedResults.Ok(temp);
        }
    }
}
