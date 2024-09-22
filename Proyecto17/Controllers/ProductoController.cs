using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto17.Context;
using Proyecto17.Entities;

namespace Proyecto17.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoContext _context;

        public ProductoController(ProductoContext context)
        {
            _context = context;
        }

        [HttpGet("Obtenerproductos")]
        public async Task<ActionResult<IEnumerable<Productos>>> Get()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("ObtenerproductoByid{id}")]
        public async Task<ActionResult<Productos>> Get(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost("Agregarproductos")]
        public async Task<ActionResult<Productos>> Post(Productos productos)
        {
            _context.Productos.Add(productos);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Actualizarproducto{id}")]
        public async Task<IActionResult> Put(int id, Productos productos)
        {
            if (id != productos.Id)
            {
                return BadRequest();
            }

            _context.Entry(productos).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Eliminarproducto{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
