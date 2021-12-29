using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> ListAsync();

        Task<BookingResponse> FindByIdAsync(int id);

        Task<IEnumerable<Booking>> FindByLodgersIdAsync(int lodgerId);

        Task<BookingResponse> SaveAsync(Booking booking);

        Task<BookingResponse> UpdateAsync(int id, Booking booking);

        Task<BookingResponse> DeleteAsync(int id);
    }
}
