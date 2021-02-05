using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T27_API_ER_SQL_EX2.Model;

namespace T27_API_ER_SQL_EX2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Asignado_AController : ControllerBase
    {
        private readonly APIContext _context;

        public Asignado_AController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Asignado_A
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignado_A>>> GetAsignado_As()
        {
            return await _context.Asignado_As.ToListAsync();
        }

        // GET: api/Asignado_A/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignado_A>> GetAsignado_A(string id)
        {
            var asignado_A = await _context.Asignado_As.FindAsync(id);

            if (asignado_A == null)
            {
                return NotFound();
            }

            return asignado_A;
        }

        // PUT: api/Asignado_A/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignado_A(string id, Asignado_A asignado_A)
        {
            if (id != asignado_A.Proyecto)
            {
                return BadRequest();
            }

            _context.Entry(asignado_A).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Asignado_AExists(id))
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

        // POST: api/Asignado_A
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Asignado_A>> PostAsignado_A(Asignado_A asignado_A)
        {
            _context.Asignado_As.Add(asignado_A);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Asignado_AExists(asignado_A.Proyecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAsignado_A", new { id = asignado_A.Proyecto }, asignado_A);
        }

        // DELETE: api/Asignado_A/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Asignado_A>> DeleteAsignado_A(string id)
        {
            var asignado_A = await _context.Asignado_As.FindAsync(id);
            if (asignado_A == null)
            {
                return NotFound();
            }

            _context.Asignado_As.Remove(asignado_A);
            await _context.SaveChangesAsync();

            return asignado_A;
        }

        private bool Asignado_AExists(string id)
        {
            return _context.Asignado_As.Any(e => e.Proyecto == id);
        }
    }
}
