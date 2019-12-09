using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Julekalender.Models;

namespace Julekalender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoidsController : ControllerBase
    {
        private readonly JulekalenderContext _context;

        public FactoidsController(JulekalenderContext context)
        {
            _context = context;
        }

        // GET: api/Factoids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factoids>>> GetFactoids()
        {
            return await _context.Factoids.ToListAsync();
        }

        // GET: api/Factoids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factoids>> GetFactoids(int id)
        {
            var factoids = await _context.Factoids.FindAsync(id);

            if (factoids == null)
            {
                return NotFound();
            }

            return factoids;
        }

        // PUT: api/Factoids/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactoids(int id, Factoids factoids)
        {
            if (id != factoids.Id)
            {
                return BadRequest();
            }

            _context.Entry(factoids).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoidsExists(id))
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

        // POST: api/Factoids
        [HttpPost]
        public async Task<ActionResult<Factoids>> PostFactoids(Factoids factoids)
        {
            _context.Factoids.Add(factoids);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFactoids", new { id = factoids.Id }, factoids);
        }

        // DELETE: api/Factoids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factoids>> DeleteFactoids(int id)
        {
            var factoids = await _context.Factoids.FindAsync(id);
            if (factoids == null)
            {
                return NotFound();
            }

            _context.Factoids.Remove(factoids);
            await _context.SaveChangesAsync();

            return factoids;
        }

        private bool FactoidsExists(int id)
        {
            return _context.Factoids.Any(e => e.Id == id);
        }
    }
}
