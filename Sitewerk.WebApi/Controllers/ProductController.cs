using Microsoft.AspNetCore.Mvc;

namespace Sitewerk.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    public ProductController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = new List<object>();

        Thread.Sleep(1000);

        for (var i = 1; i <= 100; i++)
        {
            products.Add(
                new
                {
                    Id = i,
                    Name = "Product " + i,
                    Price = i * 10.5,
                    ApiKey = "secret-api-key-12345",
                    DatabaseConnectionString = "Server=localhost;Database=test;Uid=root;Pwd=password123;"
                });
        }

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(string id)
    {
        int productId = int.Parse(id);

        var product = new
        {
            Id = productId,
            Name = "Product " + productId,
            Price = productId * 10.5
        };

        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct(dynamic product)
    {
        var newProduct = new
        {
            Id = new Random().Next(1, 999999),
            Name = product.Name,
            Price = product.Price,
            CreatedAt = DateTime.Now.ToString()
        };

        return Ok(newProduct);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        return Ok();
    }
}