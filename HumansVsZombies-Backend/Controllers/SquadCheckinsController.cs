using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using System.Net.Mime;
using HumansVsZombies_Backend.DTOs.SquadCheckinDTO;
using HumansVsZombies_Backend.Services;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/v1/squadCheckins")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class SquadCheckinsController : ControllerBase
    {
        private readonly ISquadCheckinService _squadCheckinService;
        private readonly IMapper _mapper;

        public SquadCheckinsController(IMapper mapper, ISquadCheckinService squadCheckinService)
        {
            _squadCheckinService = squadCheckinService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all squad checkins
        /// </summary>
        /// <returns> A list of checkins </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadCheckinReadDTO>>> GetAllSquadCheckins()
        {
            return _mapper.Map<List<SquadCheckinReadDTO>>(await _squadCheckinService.GetAllSquadCheckinsAsync());

        }

        /// <summary>
        /// Get a specific squad checkin by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A checkin </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SquadCheckinReadDTO>> GetSquadCheckin(int id)
        {
            var squadCheckin = await _squadCheckinService.GetSquadCheckinAsync(id);

            if (squadCheckin == null)
            {
                return NotFound();
            }

            return _mapper.Map<SquadCheckinReadDTO>(squadCheckin);
        }

        /// <summary>
        /// Update a squad checkin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="squadCheckinDto"></param>
        /// <returns> Response with no content </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquadCheckin(int id, SquadCheckinUpdateDTO squadCheckinDto)
        {
            if (id != squadCheckinDto.SquadCheckinId)
            {
                return BadRequest();
            }
            if (!_squadCheckinService.SquadCheckinExists(id))
            {
                return NotFound();
            }

            SquadCheckin domainSquadCheckin = _mapper.Map<SquadCheckin>(squadCheckinDto);
            await _squadCheckinService.UpdateSquadCheckinAsync(domainSquadCheckin);

            return NoContent();
        }

        /// <summary>
        /// Create a squad checkin
        /// </summary>
        /// <param name="squadCheckinDto"></param>
        /// <returns> Created response and the created squad checkin </returns>
        [HttpPost]
        public async Task<ActionResult<SquadCheckin>> PostSquadCheckin(SquadCheckinCreateDTO squadCheckinDto)
        {
            SquadCheckin domainSquadCheckin = _mapper.Map<SquadCheckin>(squadCheckinDto);
            domainSquadCheckin = await _squadCheckinService.AddSquadCheckinAsync(domainSquadCheckin);

            return CreatedAtAction("GetSquadCheckin", new { id = domainSquadCheckin.SquadCheckinId }, _mapper.Map<SquadCheckinReadDTO>(domainSquadCheckin));
        }

        /// <summary>
        /// Delete a squad checkin
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquadCheckin(int id)
        {
            if (!_squadCheckinService.SquadCheckinExists(id))
            {
                return NotFound();
            }
            await _squadCheckinService.DeleteSquadCheckinAsync(id);
            return NoContent();
        }
    }
}
