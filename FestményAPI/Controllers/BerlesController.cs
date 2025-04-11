using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestményAPI.Data;
using FestményAPI.Model;

namespace FestményAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BerlesController : ControllerBase
    {
        private readonly FestményAPIContext _context;

        public BerlesController(FestményAPIContext context)
        {
            _context = context;
        }

        // GET: api/Berles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Berles>>> GetBerles()
        {
            return await _context.Berles.ToListAsync();
        }

        // GET: api/Berles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Berles>> GetBerles(int id)
        {
            var berles = await _context.Berles.FindAsync(id);

            if (berles == null)
            {
                return NotFound();
            }

            return berles;
        }

        // PUT: api/Berles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBerles(int id, Berles berles)
        {
            if (id != berles.id)
            {
                return BadRequest();
            }

            _context.Entry(berles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BerlesExists(id))
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

        // POST: api/Berles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Berles>> PostBerles(Berles berles)
        {
            if (berles.startDate < DateTime.Today.AddDays(1)) 
            {
                return BadRequest("A bérlés nem lehet korábbi mint holnap");
            }
            if (berles.Duration < 3 || berles.Duration > 90)
            {
                return BadRequest("A bérlés legalább 3 napnak és max 90 nap lehet");
            }
            var conflictIds = await _context.Berles
              .Where(x => x.paintingId == berles.paintingId &&
                          x.endDate > berles.startDate &&
                          x.startDate < berles.endDate)
              .Select(x => x.id)
              .ToListAsync();
            if (conflictIds.Any())
            {
                return BadRequest("Ez a festmény már foglalt az adott időszakban.");
            }

            var TotalPrice = berles.TotalPrice;
            _context.Berles.Add(berles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBerles", new { id = berles.id }, new
            {
                berles
            });
        }
        // DELETE: api/Berles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBerles(int id)
        {
            var berles = await _context.Berles.FindAsync(id);
            if (berles == null)
            {
                return NotFound();
            }

            _context.Berles.Remove(berles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BerlesExists(int id)
        {
            return _context.Berles.Any(e => e.id == id);
        }
    }
}
