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
    [Route("api/v1/missions")]
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

        /// <summary>
        /// Get all missions
        /// </summary>
        /// <returns> A list of missions </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionReadDTO>>> GetAllMissions()
        {
            return _mapper.Map<List<MissionReadDTO>>(await _missionService.GetAllMissionsAsync());
        }

        /// <summary>
        /// Get a specific mission by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A mission </returns>
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

        /// <summary>
        /// Get all missions in a specific game
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns> A list of missions </returns>
        [HttpGet("{gameId}/missions")]
        public async Task<IEnumerable<MissionReadDTO>> GetAllMissionsInGame(int gameId)
        {
            return _mapper.Map<List<MissionReadDTO>>(await _missionService.GetAllMissionsInGameAsync(gameId));
        }

        /// <summary>
        /// Get a specific mission in a specific game
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="missionId"></param>
        /// <returns> A mission </returns>
        [HttpGet("{gameId}/{missionId}")]
        public async Task<ActionResult<MissionReadDTO>> GetOneMissionInGame(int gameId, int missionId)
        {
            var mission = await _missionService.GetOneMissionInGameAsync(gameId, missionId);

            if (mission == null)
            {
                return NotFound();
            }

            return _mapper.Map<MissionReadDTO>(mission);
        }

        /// <summary>
        /// Update a mission
        /// </summary>
        /// <param name="id"></param>
        /// <param name="missionDto"></param>
        /// <returns> Response with no content </returns>
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

        /// <summary>
        /// Create a new mission
        /// </summary>
        /// <param name="missionDto"></param>
        /// <returns> Created response and the created mission </returns>
        [HttpPost]
        public async Task<ActionResult<Mission>> PostMission(MissionCreateDTO missionDto)
        {
            Mission domainMission = _mapper.Map<Mission>(missionDto);
            domainMission = await _missionService.AddMissionAsync(domainMission);

            return CreatedAtAction("GetMission", new { id = domainMission.MissionId }, _mapper.Map<MissionReadDTO>(domainMission));

        }

        /// <summary>
        /// Delete a mission
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
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
    }
}
