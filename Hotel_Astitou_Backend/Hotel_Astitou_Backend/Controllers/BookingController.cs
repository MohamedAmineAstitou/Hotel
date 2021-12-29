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
    [Route("bookings")]
    public class BookingController : AuthorizeController
    {


        private readonly IBookingService bookingService;
        private readonly IMapper mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingResource>), 200)]
        public async Task<IEnumerable<BookingResource>> ListBooking()
        {
            var booking = await bookingService.ListAsync();

            return mapper.Map<IEnumerable<Booking>, IEnumerable<BookingResource>>(booking);
        }

        [HttpGet("{id}")]
     
        public async Task<IActionResult> FindById(int id)
        {
            var bookingResponse = await bookingService.FindByIdAsync(id);

            if (!bookingResponse.Success)
                return BadRequest(new ErrorResource(bookingResponse.Message));

            return Ok(mapper.Map<Booking, BookingResource>(bookingResponse.Resource));
        }
        [HttpPost("CreateBooking")]
        public async Task<BookingResponse> NewBooking([FromQuery(Name = "dateOfArrival")] string dateOfArrival,
            [FromQuery(Name = "dateOfDeparture")] string dateOfDeparture,
            [FromQuery(Name = "idApartment")] string idApartment,
            [FromQuery(Name = "lodgerId")] string lodgerId)
        {
            Console.WriteLine(dateOfArrival);
            Console.WriteLine(dateOfDeparture);
            Console.WriteLine(idApartment);
            Console.WriteLine("logdger"+lodgerId);

            NewBookingResource newBooking = new NewBookingResource(DateTime.Parse(dateOfArrival), DateTime.Parse(dateOfDeparture), Int32.Parse(lodgerId), Int32.Parse(idApartment));
            var booking = mapper.Map<NewBookingResource, Booking>(newBooking);
            return await bookingService.SaveAsync(booking);

        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(
            [FromQuery(Name = "id")] string id,
            [FromQuery(Name = "dateOfArrival")] string dateOfArrival,
            [FromQuery(Name = "dateOfDeparture")] string dateOfDeparture,
            [FromQuery(Name = "idApartment")] string idApartment,
            [FromQuery(Name = "lodgerId")] string lodgerId)
        {
            NewBookingResource newBooking = new NewBookingResource(DateTime.Parse(dateOfArrival), DateTime.Parse(dateOfDeparture), Int32.Parse(lodgerId), Int32.Parse(idApartment));
            var booking = mapper.Map<NewBookingResource, Booking>(newBooking);
            var result = await bookingService.UpdateAsync(Int32.Parse(id), booking);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var bookingResource = mapper.Map<Booking, BookingResource>(result.Resource);
            return Ok(bookingResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await bookingService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new ErrorResource(result.Message));

            var bookingResource = mapper.Map<Booking, BookingResource>(result.Resource);
            return Ok(bookingResource);
        }
    }
}