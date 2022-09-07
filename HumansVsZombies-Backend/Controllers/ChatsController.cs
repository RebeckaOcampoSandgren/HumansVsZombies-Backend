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
using HumansVsZombies_Backend.DTOs.ChatDTO;
using HumansVsZombies_Backend.Services;
using AutoMapper;

namespace HumansVsZombies_Backend.Controllers
{
    [Route("api/v1/chats")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatsController(IChatService chatService, IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all chats
        /// </summary>
        /// <returns> A list of chats </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatReadDTO>>> GetAllChats()
        {
            return _mapper.Map<List<ChatReadDTO>>(await _chatService.GetAllChatsAsync());
        }

        /// <summary>
        /// Get a specific chat
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A chat </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ChatReadDTO>> GetChat(int id)
        {
            var chat = await _chatService.GetChatAsync(id);

            if (chat == null)
            {
                return NotFound();
            }

            return _mapper.Map<ChatReadDTO>(chat);
        }

        /// <summary>
        /// Update a chat
        /// </summary>
        /// <param name="id"></param>
        /// <param name="chatDto"></param>
        /// <returns> Response with no content </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChat(int id, ChatUpdateDTO chatDto)
        {
            if (id != chatDto.ChatId)
            {
                return BadRequest();
            }
            if (!_chatService.ChatExists(id))
            {
                return NotFound();
            }

            Chat domainChat = _mapper.Map<Chat>(chatDto);
            await _chatService.UpdateChatAsync(domainChat);

            return NoContent();
        }

        /// <summary>
        /// Create a new chat
        /// </summary>
        /// <param name="chatDto"></param>
        /// <returns> Created response and the created chat </returns>
        [HttpPost]
        public async Task<ActionResult<Chat>> PostChat(ChatCreateDTO chatDto)
        {
            Chat domainChat = _mapper.Map<Chat>(chatDto);
            domainChat = await _chatService.AddChatAsync(domainChat);

            return CreatedAtAction("GetChat", new { id = domainChat.ChatId }, _mapper.Map<ChatReadDTO>(domainChat));
        }

        /// <summary>
        /// Delete a chat
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Response with no content </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            if (!_chatService.ChatExists(id))
            {
                return NotFound();
            }

            await _chatService.DeleteChatAsync(id);
            return NoContent();
        }
    }
}
