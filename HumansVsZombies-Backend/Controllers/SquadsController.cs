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
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class SquadsController : ControllerBase
    {
        private readonly HvZDbContext _context;
        private readonly ISquadService _squadService;
        private readonly IMapper _mapper;

        public SquadsController(HvZDbContext context, IMapper mapper, ISquadService squadService)
        {
            _context = context;
            _squadService = squadService;
            _mapper = mapper;
        }

        // GET: api/Squads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadReadDTO>>> GetAllSquads()
        {
            return _mapper.Map<List<SquadReadDTO>>(await _squadService.GetAllSquadsAsync());
        }

        // GET: api/Squads/5
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

        // PUT: api/Squads/5
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

        // POST: api/Squads
        [HttpPost]
        public async Task<ActionResult<Squad>> PostSquad(SquadCreateDTO dtoSquad)
        {
            Squad domainSquad = _mapper.Map<Squad>(dtoSquad);
            domainSquad = await _squadService.AddSquadAsync(domainSquad);

            return CreatedAtAction("GetSquad", new { id = domainSquad.SquadId }, _mapper.Map<SquadReadDTO>(domainSquad));
        }

        // DELETE: api/Squads/5
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

        //reporting, get all squads in a game
        [HttpGet("{gameId}/get/squads")]
        public async Task<IEnumerable<SquadReadDTO>> GetAllSquadsInGame(int gameId)
        {
            return _mapper.Map<List<SquadReadDTO>>(await _squadService.GetAllSquadsInGameAsync(gameId));
        }

        //reporting
        [HttpGet("{gameId}/get/squad")]
        public async Task<ActionResult<SquadReadDTO>> GetOneSquadInGame(int gameId, int squadId)
        {
            var squad = await _squadService.GetOneSquadInGameAsync(gameId, squadId);

            if (squad == null)
            {
                return NotFound();
            }

            return _mapper.Map<SquadReadDTO>(squad);
        }

        //reporting method to get all chats for a specific squad
        [HttpGet("{id}/chats")]
        public async Task<ActionResult<IEnumerable<ChatReadDTO>>> GetAllChatsInSquad(int id)
        {
            return _mapper.Map<List<ChatReadDTO>>(await _squadService.GetAllChatsInSquadAsync(id));
        }

        //reporting method to get all checkin-markers for a specific squad
        [HttpGet("{id}/checkins")]
        public async Task<ActionResult<IEnumerable<SquadCheckinReadDTO>>> GetAllCheckinsInSquad(int id)
        {
            return _mapper.Map<List<SquadCheckinReadDTO>>(await _squadService.GetAllCheckinsInSquadAsync(id));
        }
    }
}
