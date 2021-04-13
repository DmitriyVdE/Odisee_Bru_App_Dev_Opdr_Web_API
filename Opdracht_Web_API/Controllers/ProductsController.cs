using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Opdracht_Web_API.Data;
using Opdracht_Web_API.Models;

namespace Opdracht_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ProductsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return _context.Products
                .Include(p => p.TaxLevel)
                .Include(p => p.Category)
                .Where(p => p.Active == true)
                .ToList();
        }

        [HttpGet("inactive")]
        public ActionResult<IEnumerable<Product>> GetAllInactive()
        {
            return _context.Products
                .Include(p => p.TaxLevel)
                .Include(p => p.Category)
                .Where(p => p.Active == false)
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            Product product = _context.Products
                .Include(p => p.TaxLevel)
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            Tax tax = _context.Taxes.Find(product.TaxLevelId);

            return product;
        }

        [HttpGet("{id}/price")]
        public ActionResult<double> GetProductPrice(int id)
        {
            Product product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            Tax tax = _context.Taxes.Find(product.TaxLevelId);

            return product.BuyPrice * 1.2 * (1.0 + tax.TaxPercentage / 100.0);
        }

        [HttpPost("")]
        public ActionResult<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPost("{id}")]
        public ActionResult<Product> EditProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            Product toUpdate = _context.Products.Find(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Code = product.Code;
            toUpdate.Name = product.Name;
            toUpdate.CategoryId = product.CategoryId;
            toUpdate.BuyPrice = product.BuyPrice;
            toUpdate.TaxLevelId = product.TaxLevelId;
            toUpdate.AmountInStock = product.AmountInStock;
            toUpdate.Active = product.Active;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            Product toDelete = _context.Products.Find(id);

            if (toDelete == null)
            {
                return NotFound();
            }

            _context.Products.Remove(toDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
