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
using HumansVsZombies_Backend.Services;
using AutoMapper;
using HumansVsZombies_Backend.DTOs.KillDTO;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/v1/kills")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class KillsController : ControllerBase
    {
        private readonly IKillService _killService;
        private readonly IMapper _mapper;

        public KillsController(IKillService killService, IMapper mapper)
        {
            _killService = killService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all kills
        /// </summary>
        /// <returns> A list of players </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KillReadDTO>>> GetAllKills()
        {
            return _mapper.Map<List<KillReadDTO>>(await _killService.GetAllKillsAsync());
        }

        /// <summary>
        /// Get a specific Kill by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A kill </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<KillReadDTO>> GetKill(int id)
        {
            var kill = await _killService.GetKillAsync(id);

            if (kill == null)
            {
                return NotFound();
            }

            return _mapper.Map<KillReadDTO>(kill);
        }

        /// <summary>
        /// Update a kill
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dtoKill"></param>
        /// <returns> Response with no content </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKill(int id, KillUpdateDTO dtoKill)
        {
            if (id != dtoKill.KillId)
            {
                return BadRequest();
            }
            if (!_killService.KillExists(id))
            {
                return NotFound();
            }


            Kill domainKill = _mapper.Map<Kill>(dtoKill);
            await _killService.UpdateKillAsync(domainKill);

            return NoContent();
        }

        /// <summary>
        /// Create a new kill
        /// </summary>
        /// <param name="killDto"></param>
        /// <returns> Created response and the created kill </returns>
        [HttpPost]
        public async Task<ActionResult<Kill>> PostKill(KillCreateDTO killDto)
        {
            Kill domainKill = _mapper.Map<Kill>(killDto);
            domainKill = await _killService.AddKillAsync(domainKill);


            return CreatedAtAction("GetKill", new { id = domainKill.KillId }, _mapper.Map<KillReadDTO>(domainKill));
        }

        /// <summary>
        /// Delete a kill
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKill(int id)
        {
            if (!_killService.KillExists(id))
            {
                return NotFound();
            }

            await _killService.DeleteKillAsync(id);
            return NoContent();
        }
    }
}
