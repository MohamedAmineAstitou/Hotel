using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User room) : base(room)
        {
        }

        public UserResponse(string message) : base(message)
        {
        }
    }
}
