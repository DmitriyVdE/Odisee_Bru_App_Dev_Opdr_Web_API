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
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            Category category = _context.Categories
                .Include(u => u.Products)
                .FirstOrDefault(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpGet("{id}/products")]
        public ActionResult<IEnumerable<Product>> GetCategoryProducts(int id)
        {
            _ = _context.Taxes.ToList();

            Category category = _context.Categories
                .Include(u => u.Products)
                .FirstOrDefault(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return category.Products.ToList();
        }

        [HttpPost("")]
        public ActionResult<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return CreatedAtAction(nameof(AddCategory), new { id = category.Id }, category);
        }

        [HttpPost("{id}")]
        public ActionResult<Category> Editcategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            Category toUpdate = _context.Categories.Find(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Name = category.Name;

            _context.SaveChanges();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Deletecategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            Category toDelete = _context.Categories.Find(id);

            if (toDelete == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(toDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
