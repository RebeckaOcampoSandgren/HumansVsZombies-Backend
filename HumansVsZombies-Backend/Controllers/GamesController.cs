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
using HumansVsZombies_Backend.DTOs.GameDTO;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class GamesController : ControllerBase
    {
        private readonly HvZDbContext _context;

        public GamesController(HvZDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameReadDTO>>> GetGame()
        {
            return await _context.Game.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameReadDTO>> GetGame(int id)
        {
            var game = await _context.Game.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, GameUpdateDTO gameDto)
        {
            if (id != gameDto.GameId)
            {
                return BadRequest();
            }

            _context.Entry(gameDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(id))
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

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(GameCreateDTO gameDto)
        {
            _context.Game.Add(gameDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGame", new { id = gameDto.GameId }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }
    }
}
