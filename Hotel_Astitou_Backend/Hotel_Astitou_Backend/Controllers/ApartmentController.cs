using AutoMapper;
using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Domain.Services.Communication;
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
    [Route("apartments")]
    public class ApartmentController : AuthorizeController
    {
        private readonly IApartmentService apartmentService;
        private readonly IMapper mapper;
        public ApartmentController(IApartmentService apartmentService, IMapper mapper)
        {
            this.apartmentService = apartmentService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApartmentResource>), 200)]
        public async Task<IEnumerable<ApartmentResource>> ListApartmentsss()
        {
            var apartments = await apartmentService.ListAsync();

            return mapper.Map<IEnumerable<Apartment>, IEnumerable<ApartmentResource>>(apartments);
        }

        [HttpGet("{id}")]
     
        public async Task<IActionResult> FindById(int id)
        {
            var apartmentsResponse = await apartmentService.FindByIdAsync(id);

            if (!apartmentsResponse.Success)
                return BadRequest(new ErrorResource(apartmentsResponse.Message));
            return Ok(mapper.Map<Apartment, ApartmentResource>(apartmentsResponse.Resource));
        }



        [HttpPost("CreateApartment")]
        public async Task<ApartmentResponse> NewApartment(
            [FromQuery(Name = "adress")] string adress,
            [FromQuery(Name = "type")] string type,
            [FromQuery(Name = "floor")] string floor,
            [FromQuery(Name = "roomNumber")] string roomNumber,
            [FromQuery(Name = "totalArea")] string totalArea,
            [FromQuery(Name = "bedroomArea")] string bedroomArea,
            [FromQuery(Name = "diningArea")] string diningArea,
            [FromQuery(Name = "rentPrice")] string rentPrice)
        {
            NewApartmentResource newApartment = new NewApartmentResource(adress, type, Int32.Parse(floor), Int32.Parse(roomNumber), Int32.Parse(totalArea), Int32.Parse(bedroomArea), Int32.Parse(diningArea), Decimal.Parse(rentPrice));
        var apartment = mapper.Map<NewApartmentResource, Apartment>(newApartment);
            return await apartmentService.SaveAsync(apartment);
        }
        [HttpPut("")]
        public async Task<IActionResult> PutAsync(
            [FromQuery(Name = "id")] string id,
            [FromQuery(Name = "adress")] string adress,
            [FromQuery(Name = "type")] string type,
            [FromQuery(Name = "floor")] string floor,
            [FromQuery(Name = "roomNumber")] string roomNumber,
            [FromQuery(Name = "totalArea")] string totalArea,
            [FromQuery(Name = "bedroomArea")] string bedroomArea,
            [FromQuery(Name = "diningArea")] string diningArea,
            [FromQuery(Name = "rentPrice")] string rentPrice)
        {

            NewApartmentResource newApartment = new NewApartmentResource(adress, type, Int32.Parse(floor), Int32.Parse(roomNumber), Int32.Parse(totalArea), Int32.Parse(bedroomArea), Int32.Parse(diningArea), Decimal.Parse(rentPrice));
            var apartment = mapper.Map<NewApartmentResource, Apartment>(newApartment);
            var result = await apartmentService.UpdateAsync(Int32.Parse(id), apartment);
            
            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var apartmentResource = mapper.Map<Apartment, ApartmentResource>(result.Resource);
            return Ok(apartmentResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await apartmentService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new ErrorResource(result.Message));

            var apartmentResource = mapper.Map<Apartment, ApartmentResource>(result.Resource);
            return Ok(apartmentResource);
        }
    }
}
