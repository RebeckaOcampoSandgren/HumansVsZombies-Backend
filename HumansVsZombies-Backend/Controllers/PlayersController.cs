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
using HumansVsZombies_Backend.DTOs.PlayerDTO;
using HumansVsZombies_Backend.Services;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService, IGameService gameService, IMapper mapper)
        {
            _playerService = playerService;
            _gameService = gameService;
            _mapper = mapper;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerReadDTO>>> GetAllPlayers()
        {
            return _mapper.Map<List<PlayerReadDTO>>(await _playerService.GetAllPlayersAsync());
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerReadDTO>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return _mapper.Map<PlayerReadDTO>(player);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(int id, PlayerUpdateDTO dtoPlayer)
        {
            if (id != dtoPlayer.PlayerId)
            {
                return BadRequest();
            }
            if (!_playerService.PlayerExists(id))
            {
                return NotFound();
            }

            Player domainPlayer = _mapper.Map<Player>(dtoPlayer);
            await _playerService.UpdatePlayerAsync(domainPlayer);

            return NoContent();
        }

        // POST: api/Players
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(PlayerCreateDTO playerDto)
        {
            Player domainPlayer = _mapper.Map<Player>(playerDto);
            domainPlayer = await _playerService.AddPlayerAsync(domainPlayer);


            return CreatedAtAction("GetPlayer", new { id = domainPlayer.PlayerId }, _mapper.Map<PlayerReadDTO>(domainPlayer));
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            if (!_playerService.PlayerExists(id))
            {
                return NotFound();
            }

            await _playerService.DeletePlayerAsync(id);
            return NoContent();

        }

        // reporting, updates a player in a game
        [HttpPut("{playerId}/update/game")]
        public async Task<IActionResult> UpdatePlayerInGame(int gameId, int playerId, PlayerUpdateDTO dtoPlayer)
        {
            if (!_playerService.PlayerExists(playerId))
            {
                return NotFound();
            }

            Player domainPlayer = _mapper.Map<Player>(dtoPlayer);
            await _playerService.UpdatePlayerInGameAsync(domainPlayer, gameId, playerId);

            return NoContent();
        }
    }
}
