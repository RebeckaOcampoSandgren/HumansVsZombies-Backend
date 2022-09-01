using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KillsController : ControllerBase
    {
        private readonly HvZDbContext _context;

        public KillsController(HvZDbContext context)
        {
            _context = context;
        }

        // GET: api/Kills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kill>>> GetKill()
        {
            return await _context.Kill.ToListAsync();
        }

        // GET: api/Kills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kill>> GetKill(int id)
        {
            var kill = await _context.Kill.FindAsync(id);

            if (kill == null)
            {
                return NotFound();
            }

            return kill;
        }

        // PUT: api/Kills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKill(int id, Kill kill)
        {
            if (id != kill.KillId)
            {
                return BadRequest();
            }

            _context.Entry(kill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KillExists(id))
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

        // POST: api/Kills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kill>> PostKill(Kill kill)
        {
            _context.Kill.Add(kill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKill", new { id = kill.KillId }, kill);
        }

        // DELETE: api/Kills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKill(int id)
        {
            var kill = await _context.Kill.FindAsync(id);
            if (kill == null)
            {
                return NotFound();
            }

            _context.Kill.Remove(kill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KillExists(int id)
        {
            return _context.Kill.Any(e => e.KillId == id);
        }
    }
}
