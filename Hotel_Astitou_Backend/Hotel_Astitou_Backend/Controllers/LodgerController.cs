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
    [Route("lodgers")]
    public class LodgerController : AuthorizeController
    {
        private readonly ILodgerService lodgerService;
        private readonly IMapper mapper;
        public LodgerController(ILodgerService lodgerService, IMapper mapper)
        {
            this.lodgerService = lodgerService;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LodgerResource>), 200)]
        public async Task<IEnumerable<LodgerResource>> ListLodger()
        {
            var lodger = await lodgerService.ListAsync();

            return mapper.Map<IEnumerable<Lodger>, IEnumerable<LodgerResource>>(lodger);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LodgerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 404)]
        public async Task<IActionResult> FindById(int id)
        {
            var lodgerResponse = await lodgerService.FindByIdAsync(id);

            if (!lodgerResponse.Success)
                return BadRequest(new ErrorResource(lodgerResponse.Message));

            return Ok(mapper.Map<Lodger, LodgerResource>(lodgerResponse.Resource));
        }
        [HttpPost("CreateLodger")]
        public async Task<LodgerResponse> NewLodger(
            [FromQuery(Name = "name")] string name,
            [FromQuery(Name = "firstname")] string firstname,
            [FromQuery(Name = "gender")] string gender,
            [FromQuery(Name = "civility")] string civility,
            [FromQuery(Name = "adress")] string adress,
            [FromQuery(Name = "city")] string city,
            [FromQuery(Name = "country")] string country,
            [FromQuery(Name = "email")] string email,
            [FromQuery(Name = "postalCode")] string postalCode,
            [FromQuery(Name = "phoneNumber")] string phoneNumber,
            [FromQuery(Name = "birthday")] string birthday,
            [FromQuery(Name = "birthplace")] string birthplace,
            [FromQuery(Name = "nationalRegister")] string nationalRegister)
        {
            Console.WriteLine(name);
            Console.WriteLine(firstname);
            Console.WriteLine(gender);
            Console.WriteLine(civility);
            Console.WriteLine(adress);
            Console.WriteLine(city);
            Console.WriteLine(country);
            Console.WriteLine(email);

            Console.WriteLine(postalCode);
            Console.WriteLine(phoneNumber);
            Console.WriteLine(birthday);
            Console.WriteLine(birthplace);
            Console.WriteLine(nationalRegister);
          
                        NewLodgerResource newLodger = new NewLodgerResource(name, firstname, gender, civility, adress, city, country, email, Int32.Parse(postalCode), Int32.Parse(phoneNumber), DateTime.Parse(birthday), birthplace, nationalRegister);
            var lodger = mapper.Map<NewLodgerResource, Lodger>(newLodger);
            return await lodgerService.SaveAsync(lodger);

        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(
            [FromQuery(Name = "id")] string id,
            [FromQuery(Name = "name")] string name,
            [FromQuery(Name = "firstname")] string firstname,
            [FromQuery(Name = "gender")] string gender,
            [FromQuery(Name = "civility")] string civility,
            [FromQuery(Name = "adress")] string adress,
            [FromQuery(Name = "city")] string city,
            [FromQuery(Name = "country")] string country,
            [FromQuery(Name = "email")] string email,
            [FromQuery(Name = "postalCode")] string postalCode,
            [FromQuery(Name = "phoneNumber")] string phoneNumber,
            [FromQuery(Name = "birthday")] string birthday,
            [FromQuery(Name = "birthplace")] string birthplace,
            [FromQuery(Name = "nationalRegister")] string nationalRegister)
        {
            Console.WriteLine(id);
            Console.WriteLine(name);
            Console.WriteLine(firstname);
            Console.WriteLine(gender);
            Console.WriteLine(civility);
            Console.WriteLine(adress);
            Console.WriteLine(city);
            Console.WriteLine(country);
            Console.WriteLine(email);

            Console.WriteLine(postalCode);
            Console.WriteLine(phoneNumber);
            Console.WriteLine(birthday);
            Console.WriteLine(birthplace);
            Console.WriteLine(nationalRegister);
            NewLodgerResource newLodger = new NewLodgerResource(name, firstname, gender, civility, adress, city, country, email, Int32.Parse(postalCode), Int32.Parse(phoneNumber), DateTime.Parse(birthday), birthplace, nationalRegister);
            
            var lodger = mapper.Map<NewLodgerResource, Lodger>(newLodger);
            var result = await lodgerService.UpdateAsync(Int32.Parse(id), lodger);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var lodgerResource = mapper.Map<Lodger, LodgerResource>(result.Resource);
            return Ok(lodgerResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await lodgerService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new ErrorResource(result.Message));

            var lodgerResource = mapper.Map<Lodger, LodgerResource>(result.Resource);
            return Ok(lodgerResource);
        }
    }
}
