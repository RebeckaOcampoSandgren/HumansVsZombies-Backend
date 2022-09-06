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
using HumansVsZombies_Backend.Services;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MissionsController : ControllerBase
    {
        private readonly IMissionService _missionService;
        private readonly IMapper _mapper;

        public MissionsController(IMissionService missionService, IMapper mapper)
        {
            _missionService = missionService;
            _mapper = mapper;
        }

        // GET: api/Missions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionReadDTO>>> GetAllMissions()
        {
            return _mapper.Map<List<MissionReadDTO>>(await _missionService.GetAllMissionsAsync());
        }

        // GET: api/Missions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionReadDTO>> GetMission(int id)
        {
            var mission = await _missionService.GetMissionAsync(id);

            if (mission == null)
            {
                return NotFound();
            }

            return _mapper.Map<MissionReadDTO>(mission);
        }

        // PUT: api/Missions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(int id, MissionUpdateDTO missionDto)
        {
            if (id != missionDto.MissionId)
            {
                return BadRequest();
            }
            if (!_missionService.MissionExists(id))
            {
                return NotFound();
            }

            Mission domainMission = _mapper.Map<Mission>(missionDto);
            await _missionService.UpdateMissionAsync(domainMission);

            return NoContent();
        }

        // POST: api/Missions
        [HttpPost]
        public async Task<ActionResult<Mission>> PostMission(MissionCreateDTO missionDto)
        {
            Mission domainMission = _mapper.Map<Mission>(missionDto);
            domainMission = await _missionService.AddMissionAsync(domainMission);

            return CreatedAtAction("GetMission", new { id = domainMission.MissionId }, _mapper.Map<MissionReadDTO>(domainMission));

        }

        // DELETE: api/Missions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(int id)
        {
            if (!_missionService.MissionExists(id))
            {
                return NotFound();
            }

            await _missionService.DeleteMissionAsync(id);
            return NoContent();
        }

        //reporting, get all missions in a game
        [HttpGet("{gameId}/get/missions")]
        public async Task<IEnumerable<MissionReadDTO>> GetAllMissionsInGame(int gameId)
        {
            return _mapper.Map<List<MissionReadDTO>>(await _missionService.GetAllMissionsInGameAsync(gameId));
        }

        //reporting
        [HttpGet("{gameId}/get/mission")]
        public async Task<ActionResult<MissionReadDTO>> GetOneMissionInGame(int gameId, int missionId)
        {
            var mission = await _missionService.GetOneMissionInGameAsync(gameId, missionId);

            if (mission == null)
            {
                return NotFound();
            }

            return _mapper.Map<MissionReadDTO>(mission);
        }
    }
}
