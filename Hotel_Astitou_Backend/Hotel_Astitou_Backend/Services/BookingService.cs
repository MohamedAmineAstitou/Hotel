using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public async Task<BookingResponse> DeleteAsync(int id)
        {
            try
            {
                var existingBooking = await bookingRepository.FindByIdAsync(id);
                if (existingBooking == null)
                    return new BookingResponse("booking not found.");


                bookingRepository.Remove(existingBooking);
                return new BookingResponse(existingBooking);
            }
            catch (Exception ex)
            {
                return new BookingResponse($"An error occurred when deleting the booking: {ex.Message}");
            }
        }

        public async Task<BookingResponse> FindByIdAsync(int id)
        {
            try
            {
                var reservation = await bookingRepository.FindByIdAsync(id);
                return reservation == null ? new BookingResponse("booking not found") : new BookingResponse(reservation);
            }
            catch (Exception ex)
            {
                return new BookingResponse($"An error occurred when deleting the booking: {ex.Message}");
            }
        }


        public Task<IEnumerable<Booking>> FindByLodgersIdAsync(int lodgerId)
        {
            return bookingRepository.FindByLodgerIdAsync(lodgerId);
        }

        public Task<IEnumerable<Booking>> ListAsync()
        {
            return bookingRepository.ListAsync();
        }

        public async Task<BookingResponse> SaveAsync(Booking booking)
        {
            try
            {
                await bookingRepository.AddAsync(booking);
                return new BookingResponse(booking);
            }
            catch (Exception e)
            {
                return new BookingResponse($"An error occurred when saving the booking: {e.Message}");
            }
        }

        public async Task<BookingResponse> UpdateAsync(int id, Booking booking)
        {
            try
            {
                var existingBooking = await bookingRepository.FindByIdAsync(id);

                if (existingBooking == null)
                    return new BookingResponse("Booking not found.");
                existingBooking.ApartmentId = booking.Id;
                existingBooking.LodgerId = booking.LodgerId;
                existingBooking.DateOfArrival = booking.DateOfArrival;
                existingBooking.DateOfDeparture = booking.DateOfDeparture;

                bookingRepository.Update(existingBooking);
                return new BookingResponse(existingBooking);
            }
            catch (Exception ex)
            {
                return new BookingResponse($"An error occurred when updating the booking: {ex.Message}");
            }
        }
    }
}
