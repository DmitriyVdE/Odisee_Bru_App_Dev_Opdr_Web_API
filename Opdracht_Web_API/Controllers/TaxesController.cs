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
    public class TaxesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TaxesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Tax>> GetAll()
        {
            return _context.Taxes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Tax> GetTax(int id)
        {
            Tax tax = _context.Taxes
                .Include(u => u.Products)
                .FirstOrDefault(u => u.Id == id);

            if (tax == null)
            {
                return NotFound();
            }

            return tax;
        }

        [HttpGet("{id}/products")]
        public ActionResult<IEnumerable<Product>> GetTaxProducts(int id)
        {
            Tax tax = _context.Taxes
                .Include(u => u.Products)
                .FirstOrDefault(u => u.Id == id);

            if (tax == null)
            {
                return NotFound();
            }

            return tax.Products.ToList();
        }

        [HttpPost("")]
        public ActionResult<Tax> AddTaxLevel(Tax tax)
        {
            _context.Taxes.Add(tax);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTax), new { id = tax.Id }, tax);
        }

        [HttpPut("{id}")]
        public ActionResult<Tax> EditTaxLevel(int id, Tax tax)
        {
            if (id != tax.Id)
            {
                return BadRequest();
            }

            Tax toUpdate = _context.Taxes.Find(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Name = tax.Name;
            toUpdate.TaxPercentage = tax.TaxPercentage;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaxLevel(int id, Tax tax)
        {
            if (id != tax.Id)
            {
                return BadRequest();
            }

            Tax toDelete = _context.Taxes.Find(id);

            if (toDelete == null)
            {
                return NotFound();
            }

            _context.Taxes.Remove(toDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
