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
using HumansVsZombies_Backend.DTOs.UserDTO;
using HumansVsZombies_Backend.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns> A list of the users </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetAllUsers()
        {
            return _mapper.Map<List<UserReadDTO>>(await _userService.GetAllUsersAsync());
        }

        /// <summary>
        /// Get a specific user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A user </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserReadDTO>(user);
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDto"></param>
        /// <returns> Response with no content </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDTO userDto)
        {
            if (id != userDto.UserId)
            {
                return BadRequest();
            }
            if (!_userService.UserExists(id))
            {
                return NotFound();
            }

            User domainUser = _mapper.Map<User>(userDto);
            await _userService.UpdateUserAsync(domainUser);

            return NoContent();
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="dtoUser"></param>
        /// <returns> Created response and the created user </returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreateDTO dtoUser)
        {
            User domainUser = _mapper.Map<User>(dtoUser);
            domainUser = await _userService.AddUserAsync(domainUser);

            return CreatedAtAction("GetUser", new { id = domainUser.UserId }, _mapper.Map<UserReadDTO>(domainUser));
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!_userService.UserExists(id))
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
