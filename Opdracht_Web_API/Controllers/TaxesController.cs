using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("levels")]
        public ActionResult<IEnumerable<Tax>> GetAll()
        {
            return _context.Taxes.ToList();
        }
    }
}
