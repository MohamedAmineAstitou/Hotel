using AutoMapper;
using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Model;
using Hotel_Astitou_Backend.Ressource;
using MantaxHotel.Domaine.Service.Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/Room")]
    public class RoomController : AuthorizeController
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoomResource>), 200)]
        public async Task<IEnumerable<RoomResource>> ListRoom()
        {
            var room = await roomService.ListAsync();

            return mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(room);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoomResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 404)]
        public async Task<IActionResult> FindById(int id)
        {
            var roomResponse = await roomService.FindByIdAsync(id);

            if (!roomResponse.Success)
                return BadRequest(new ErrorResource(roomResponse.Message));

            return Ok(mapper.Map<Room, RoomResource>(roomResponse.Resource));
        }
        [HttpPost("CreateRoom")]
        public async Task<RoomResponse> NewRoom([FromBody] NewRoomResource newRoomResource)
        {
            var room = mapper.Map<NewRoomResource, Room>(newRoomResource);
            return await roomService.SaveAsync(room);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] NewRoomResource newRoomResource)
        {
            var room = mapper.Map<NewRoomResource, Room>(newRoomResource);
            var result = await roomService.UpdateAsync(id, room);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var roomResource = mapper.Map<Room, RoomResource>(result.Resource);
            return Ok(roomResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await roomService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new ErrorResource(result.Message));

            var roomResource = mapper.Map<Room, RoomResource>(result.Resource);
            return Ok(roomResource);
        }
    }
}
