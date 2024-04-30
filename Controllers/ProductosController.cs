using Microsoft.AspNetCore.Mvc;
using servicios.Models;
using System.Collections.Generic;

namespace servicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _context;

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_context.Productos);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            var producto = _context.Productos.Find(id);
            
            if(producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<string> Post(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return Ok(producto);
        }
    }
}