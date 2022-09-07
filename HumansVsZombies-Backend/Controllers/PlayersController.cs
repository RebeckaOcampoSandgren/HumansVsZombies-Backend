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
    [Route("api/v1/players")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all players
        /// </summary>
        /// <returns> A list of players </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerReadDTO>>> GetAllPlayers()
        {
            return _mapper.Map<List<PlayerReadDTO>>(await _playerService.GetAllPlayersAsync());
        }

        /// <summary>
        /// Get a specific player by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A player </returns>
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

        /// <summary>
        /// Update a player
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoPlayer"></param>
        /// <returns> Response with no content </returns>
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

        /// <summary>
        /// Update a specific player in a specific game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="playerId"></param>
        /// <param name="dtoPlayer"></param>
        /// <returns> Response with no content </returns>
        [HttpPut("{playerId}/{gameId}")]
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

        /// <summary>
        /// Create a new player
        /// </summary>
        /// <param name="playerDto"></param>
        /// <returns> Created response and the created player </returns>
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(PlayerCreateDTO playerDto)
        {
            Player domainPlayer = _mapper.Map<Player>(playerDto);
            domainPlayer = await _playerService.AddPlayerAsync(domainPlayer);


            return CreatedAtAction("GetPlayer", new { id = domainPlayer.PlayerId }, _mapper.Map<PlayerReadDTO>(domainPlayer));
        }

        /// <summary>
        /// Delete a player
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
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
    }
}
