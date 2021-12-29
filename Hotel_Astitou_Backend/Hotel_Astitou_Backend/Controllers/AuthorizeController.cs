using Hotel_Astitou_Backend.Model;
using MantaxHotel.Extension;
using Microsoft.AspNetCore.Mvc;
using Hotel_Astitou_Backend.Domain.Services;

namespace Hotel_Astitou_Backend.Controllers
{
    public class AuthorizeController : Controller
    {
        private User _User;

        private readonly IUserService clientService;


        protected User User =>
            _User ??= ((string)Request.HttpContext.Request?.Headers["Authorization"])
                .Replace("Bearer ", string.Empty)
                .AsToken();
    }
}

