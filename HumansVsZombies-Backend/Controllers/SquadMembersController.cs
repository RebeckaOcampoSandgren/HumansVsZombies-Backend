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
using HumansVsZombies_Backend.DTOs.SquadMemberDTO;
using HumansVsZombies_Backend.Services;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/v1/squadMembers")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class SquadMembersController : ControllerBase
    {
        private readonly ISquadMemberService _squadMemberService;
        private readonly IMapper _mapper;

        public SquadMembersController(IMapper mapper, ISquadMemberService squadMemberService)
        {
            _squadMemberService = squadMemberService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all squad members
        /// </summary>
        /// <returns> A list of squad members </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SquadMemberReadDTO>>> GetAllSquadMembers()
        {
            return _mapper.Map<List<SquadMemberReadDTO>>(await _squadMemberService.GetAllSquadMembersAsync());

        }

        /// <summary>
        /// Get a specific squad member by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A squad member </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<SquadMemberReadDTO>> GetSquadMember(int id)
        {
            var squadMember = await _squadMemberService.GetSquadMemberAsync(id);

            if (squadMember == null)
            {
                return NotFound();
            }

            return _mapper.Map<SquadMemberReadDTO>(squadMember);
        }

        /// <summary>
        /// Update a squad member
        /// </summary>
        /// <param name="id"></param>
        /// <param name="squadMemberDto"></param>
        /// <returns> Response with no content </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSquadMember(int id, SquadMemberUpdateDTO squadMemberDto)
        {
            if (id != squadMemberDto.SquadMemberId)
            {
                return BadRequest();
            }
            if (!_squadMemberService.SquadMemberExists(id))
            {
                return NotFound();
            }

            SquadMember domainSquadMember = _mapper.Map<SquadMember>(squadMemberDto);
            await _squadMemberService.UpdateSquadMemberAsync(domainSquadMember);

            return NoContent();
        }

        /// <summary>
        /// Create a new squad member
        /// </summary>
        /// <param name="squadMemberDto"></param>
        /// <returns> Created response and the created squad member </returns>
        [HttpPost]
        public async Task<ActionResult<SquadMember>> PostSquadMember(SquadMemberCreateDTO squadMemberDto)
        {
            SquadMember domainSquadMember = _mapper.Map<SquadMember>(squadMemberDto);
            domainSquadMember = await _squadMemberService.AddSquadMemberAsync(domainSquadMember);

            return CreatedAtAction("GetSquadMember", new { id = domainSquadMember.SquadMemberId }, _mapper.Map<SquadMemberReadDTO>(domainSquadMember));
        }

        /// <summary>
        /// Delete a squad member
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquadMember(int id)
        {
            if (!_squadMemberService.SquadMemberExists(id))
            {
                return NotFound();
            }
            await _squadMemberService.DeleteSquadMemberAsync(id);
            return NoContent();
        }
    }
}
