using ShoppingApi.Models;
using System.Linq;
using System.Web.Http;

namespace ShoppingApi.Controllers
{
    [Route("api/products")]
    public class ProductsController : ApiController
    {
        private Product[] _products =
        {
            new Product{Id = 1, Name="Mechanical Keyboard", Category="Electronics", Price=60 },
            new Product{Id = 2, Name="UX Design for Dummies", Category="Books", Price=29.99M },
            new Product{Id = 3, Name="Mixer", Category="Electronics", Price=49.9M }
        };

        [HttpGet]
       
        public IHttpActionResult GetProducts()
        {
            return Ok(_products);
        }

        [HttpGet]
        [Route("{api/products/id}")]
        public IHttpActionResult GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
