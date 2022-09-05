using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using System.Net.Mime;
using HumansVsZombies_Backend.DTOs.MissionDTO;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MissionsController : ControllerBase
    {
        private readonly HvZDbContext _context;

        public MissionsController(HvZDbContext context)
        {
            _context = context;
        }

        // GET: api/Missions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionReadDTO>>> GetMission()
        {
            return await _context.Mission.ToListAsync();
        }

        // GET: api/Missions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionReadDTO>> GetMission(int id)
        {
            var mission = await _context.Mission.FindAsync(id);

            if (mission == null)
            {
                return NotFound();
            }

            return mission;
        }

        // PUT: api/Missions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(int id, MissionUpdateDTO missionDto)
        {
            if (id != missionDto.MissionId)
            {
                return BadRequest();
            }

            _context.Entry(missionDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
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

        // POST: api/Missions
        [HttpPost]
        public async Task<ActionResult<Mission>> PostMission(MissionCreateDTO missionDto)
        {
            _context.Mission.Add(missionDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMission", new { id = mission.MissionId }, mission);
        }

        // DELETE: api/Missions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            var mission = await _context.Mission.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            _context.Mission.Remove(mission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionExists(int id)
        {
            return _context.Mission.Any(e => e.MissionId == id);
        }
    }
}
