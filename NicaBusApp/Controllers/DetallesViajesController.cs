using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NicaBusApp.Data;
using NicaBusApp.Models;

namespace NicaBusApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesViajesController : ControllerBase
    {
        private readonly NicaBusAppContext _context;

        public DetallesViajesController(NicaBusAppContext context)
        {
            _context = context;
        }

        // GET: api/DetallesViajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesViaje>>> GetDetallesViaje()
        {
            return await _context.DetallesViaje.ToListAsync();
        }

        // GET: api/DetallesViajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesViaje>> GetDetallesViaje(int id)
        {
            var detallesViaje = await _context.DetallesViaje.FindAsync(id);

            if (detallesViaje == null)
            {
                return NotFound();
            }

            return detallesViaje;
        }

        // PUT: api/DetallesViajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesViaje(int id, DetallesViaje detallesViaje)
        {
            if (id != detallesViaje.Id)
            {
                return BadRequest();
            }

            _context.Entry(detallesViaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesViajeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetallesViajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesViaje>> PostDetallesViaje(DetallesViaje detallesViaje)
        {
            _context.DetallesViaje.Add(detallesViaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesViaje", new { id = detallesViaje.Id }, detallesViaje);
        }

        // DELETE: api/DetallesViajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesViaje(int id)
        {
            var detallesViaje = await _context.DetallesViaje.FindAsync(id);
            if (detallesViaje == null)
            {
                return NotFound();
            }

            _context.DetallesViaje.Remove(detallesViaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesViajeExists(int id)
        {
            return _context.DetallesViaje.Any(e => e.Id == id);
        }
    }
}
