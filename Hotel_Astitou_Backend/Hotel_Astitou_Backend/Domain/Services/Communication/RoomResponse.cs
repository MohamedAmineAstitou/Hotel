using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MantaxHotel.Domaine.Service.Communication
{
    public class RoomResponse : BaseResponse<Room>
    {
        public RoomResponse(Room room) : base(room)
        {
        }

        public RoomResponse(string message) : base(message)
        {
        }
    }
}