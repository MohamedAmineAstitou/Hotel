using AutoMapper;
using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Infrastructure;
using Hotel_Astitou_Backend.Model;
using Hotel_Astitou_Backend.Ressource;
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
    [Route("users")]
    public class UserController : AuthorizeController
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<UserResource>> ListUsers()
        {
            var users = await userService.ListAsync();

            return mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var userResponse = await userService.FindByIdAsync(id);
            Console.WriteLine(id);
            if (!userResponse.Success)
                return BadRequest(userResponse.Message);

            return Ok(mapper.Map<User, UserResource>(userResponse.Resource));
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]

        public async Task<IActionResult> Authenticate([FromQuery(Name = "username")] string username, [FromQuery(Name = "password")] string password)
        {
            Console.WriteLine(1);
            Console.WriteLine(username);
            Console.WriteLine(password);
            var userResponse = await userService.Authenticate(
                username, password
            );


            if (!userResponse.Success)
                return BadRequest(userResponse.Message);

            return Ok(mapper.Map<User, AuthenticatedUserResource>(userResponse.Resource));
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<UserResponse> Register([FromQuery(Name = "username")] string username,
            [FromQuery(Name = "password")] string password,
            [FromQuery(Name = "email")] string email)
        {
            Console.WriteLine(username);
            Console.WriteLine(password);
            Console.WriteLine(email);
            NewUserResource newUser = new NewUserResource(username, CryptographyTool.CryptSHA512( password), email);
            var user = mapper.Map<NewUserResource, User>(newUser);
            return await userService.SaveAsync(user);
        }

        [HttpPut()]
        public async Task<IActionResult> PutAsync([FromQuery(Name = "id")] string id,
            [FromQuery(Name = "username")] string username,
            [FromQuery(Name = "email")] string email,
            [FromQuery(Name = "password")] string password)
        {
            int i = Int32.Parse(id);
            NewUserResource newUser = new NewUserResource(username, password, email);
            var user = mapper.Map<NewUserResource, User>(newUser);
            var result = await userService.UpdateAsync(i, user);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var userResource = mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await userService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new ErrorResource(result.Message));

            var userResource = mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}
