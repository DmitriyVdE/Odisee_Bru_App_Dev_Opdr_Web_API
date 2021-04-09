using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opdracht_Web_API.Data;

namespace Opdracht_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreItemsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public StoreItemsController(ApplicationContext context)
        {
            _context = context;
        }


    }
}
