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
using HumansVsZombies_Backend.Services;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GamesController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameReadDTO>>> GetAllGames()
        {
            return _mapper.Map<List<GameReadDTO>>(await _gameService.GetAllGamesAsync());
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameReadDTO>> GetGame(int id)
        {
            var game = await _gameService.GetGameAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return _mapper.Map<GameReadDTO>(game);
        }

        // PUT: api/Games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, GameUpdateDTO gameDto)
        {
            if (id != gameDto.GameId)
            {
                return BadRequest();
            }
            if (!_gameService.GameExists(id))
            {
                return NotFound();
            }

            Game domainGame = _mapper.Map<Game>(gameDto);
            await _gameService.UpdateGameAsync(domainGame);

            return NoContent();
        }

        // POST: api/Games
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(GameCreateDTO gameDto)
        {
            Game domainGame = _mapper.Map<Game>(gameDto);
            domainGame = await _gameService.AddGameAsync(domainGame);

            return CreatedAtAction("GetGame", new { id = domainGame.GameId }, _mapper.Map<GameReadDTO>(domainGame));
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            if (!_gameService.GameExists(id))
            {
                return NotFound();
            }

            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }

        //private bool GameExists(int id)
        //{
        //    return _context.Game.Any(e => e.GameId == id);
        //}
    }
}
