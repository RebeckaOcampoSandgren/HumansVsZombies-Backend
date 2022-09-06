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
using HumansVsZombies_Backend.DTOs.SquadCheckinDTO;
using HumansVsZombies_Backend.Services;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class SquadCheckinsController : ControllerBase
    {
        private readonly HvZDbContext _context;
        private readonly ISquadCheckinService _squadCheckinService;
        private readonly IMapper _mapper;

        public SquadCheckinsController(HvZDbContext context, IMapper mapper, ISquadCheckinService squadCheckinService)
        {
            _context = context;
            _squadCheckinService = squadCheckinService;
            _mapper = mapper;
        }

        // GET: api/SquadCheckins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadCheckinReadDTO>>> GetAllSquadCheckins()
        {
            return _mapper.Map<List<SquadCheckinReadDTO>>(await _squadCheckinService.GetAllSquadCheckinsAsync());

        }

        // GET: api/SquadCheckins/5
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

        // PUT: api/SquadCheckins/5
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

        // POST: api/SquadCheckins
        [HttpPost]
        public async Task<ActionResult<SquadCheckin>> PostSquadCheckin(SquadCheckinCreateDTO squadCheckinDto)
        {
            SquadCheckin domainSquadCheckin = _mapper.Map<SquadCheckin>(squadCheckinDto);
            domainSquadCheckin = await _squadCheckinService.AddSquadCheckinAsync(domainSquadCheckin);

            return CreatedAtAction("GetSquadCheckin", new { id = domainSquadCheckin.SquadCheckinId }, _mapper.Map<SquadCheckinReadDTO>(domainSquadCheckin));
        }

        // DELETE: api/SquadCheckins/5
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
