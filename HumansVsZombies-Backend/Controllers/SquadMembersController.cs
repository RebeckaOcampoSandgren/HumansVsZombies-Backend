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
    public class SquadMembersController : ControllerBase
    {
        private readonly HvZDbContext _context;

        public SquadMembersController(HvZDbContext context)
        {
            _context = context;
        }

        // GET: api/SquadMembers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadMember>>> GetSquadMember()
        {
            return await _context.SquadMember.ToListAsync();
        }

        // GET: api/SquadMembers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SquadMember>> GetSquadMember(int id)
        {
            var squadMember = await _context.SquadMember.FindAsync(id);

            if (squadMember == null)
            {
                return NotFound();
            }

            return squadMember;
        }

        // PUT: api/SquadMembers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquadMember(int id, SquadMember squadMember)
        {
            if (id != squadMember.SquadMemberId)
            {
                return BadRequest();
            }

            _context.Entry(squadMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SquadMemberExists(id))
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

        // POST: api/SquadMembers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SquadMember>> PostSquadMember(SquadMember squadMember)
        {
            _context.SquadMember.Add(squadMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSquadMember", new { id = squadMember.SquadMemberId }, squadMember);
        }

        // DELETE: api/SquadMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquadMember(int id)
        {
            var squadMember = await _context.SquadMember.FindAsync(id);
            if (squadMember == null)
            {
                return NotFound();
            }

            _context.SquadMember.Remove(squadMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SquadMemberExists(int id)
        {
            return _context.SquadMember.Any(e => e.SquadMemberId == id);
        }
    }
}
