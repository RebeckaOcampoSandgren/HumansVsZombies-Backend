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
using HumansVsZombies_Backend.DTOs.SquadDTO;
using HumansVsZombies_Backend.Services;
using AutoMapper;
using HumansVsZombies_Backend.DTOs.ChatDTO;
using HumansVsZombies_Backend.DTOs.SquadCheckinDTO;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/v1/squads")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class SquadsController : ControllerBase
    {
        private readonly ISquadService _squadService;
        private readonly IMapper _mapper;

        public SquadsController(IMapper mapper, ISquadService squadService)
        {
            _squadService = squadService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all squads
        /// </summary>
        /// <returns> A list of squads </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadReadDTO>>> GetAllSquads()
        {
            return _mapper.Map<List<SquadReadDTO>>(await _squadService.GetAllSquadsAsync());
        }

        /// <summary>
        /// Get a specific squad by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A squad </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SquadReadDTO>> GetSquad(int id)
        {
            var squad = await _squadService.GetSquadAsync(id);

            if (squad == null)
            {
                return NotFound();
            }

            return _mapper.Map<SquadReadDTO>(squad);
        }

        /// <summary>
        /// Get all squads in a specific game
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns> A list of squads </returns>
        [HttpGet("{gameId}/squads")]
        public async Task<IEnumerable<SquadReadDTO>> GetAllSquadsInGame(int gameId)
        {
            return _mapper.Map<List<SquadReadDTO>>(await _squadService.GetAllSquadsInGameAsync(gameId));
        }

        /// <summary>
        /// Get a specific squad in a specific game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="squadId"></param>
        /// <returns> A squad </returns>
        [HttpGet("{gameId}/{squadId}")]
        public async Task<ActionResult<SquadReadDTO>> GetOneSquadInGame(int gameId, int squadId)
        {
            var squad = await _squadService.GetOneSquadInGameAsync(gameId, squadId);

            if (squad == null)
            {
                return NotFound();
            }

            return _mapper.Map<SquadReadDTO>(squad);
        }

        /// <summary>
        /// Get all chats for a specific squad
        /// </summary>
        /// <param name="id"></param>
        /// <returns> a list of chats </returns>
        [HttpGet("{id}/chats")]
        public async Task<ActionResult<IEnumerable<ChatReadDTO>>> GetAllChatsInSquad(int id)
        {
            return _mapper.Map<List<ChatReadDTO>>(await _squadService.GetAllChatsInSquadAsync(id));
        }

        /// <summary>
        /// Get all checkin-markers for a specific squad
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A lis of checkins </returns>
        [HttpGet("{id}/checkins")]
        public async Task<ActionResult<IEnumerable<SquadCheckinReadDTO>>> GetAllCheckinsInSquad(int id)
        {
            return _mapper.Map<List<SquadCheckinReadDTO>>(await _squadService.GetAllCheckinsInSquadAsync(id));
        }

        /// <summary>
        /// Updating a squad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="squadDto"></param>
        /// <returns> Response with no content </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquad(int id, SquadUpdateDTO squadDto)
        {
            if (id != squadDto.SquadId)
            {
                return BadRequest();
            }
            if (!_squadService.SquadExists(id))
            {
                return NotFound();
            }

            Squad domainSquad = _mapper.Map<Squad>(squadDto);
            await _squadService.UpdateSquadAsync(domainSquad);

            return NoContent();
        }

        /// <summary>
        /// Create a new squad
        /// </summary>
        /// <param name="dtoSquad"></param>
        /// <returns> Created response and the created squad </returns>
        [HttpPost]
        public async Task<ActionResult<Squad>> PostSquad(SquadCreateDTO dtoSquad)
        {
            Squad domainSquad = _mapper.Map<Squad>(dtoSquad);
            domainSquad = await _squadService.AddSquadAsync(domainSquad);

            return CreatedAtAction("GetSquad", new { id = domainSquad.SquadId }, _mapper.Map<SquadReadDTO>(domainSquad));
        }

        /// <summary>
        /// Delete a squad
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquad(int id)
        {
            if (!_squadService.SquadExists(id))
            {
                return NotFound();
            }
            await _squadService.DeleteSquadAsync(id);
            return NoContent();
        }
    }
}
