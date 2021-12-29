using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Persistence.Repositories
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public BookingRepository(HotelAstitouContext context) : base(context)
        {
        }

        public async Task AddAsync(Booking booking)
        {
            await context.Bookings.AddAsync(booking);
            context.SaveChanges();
        }

        public async Task<Booking> FindByIdAsync(int id)
        {
            return await context.Bookings.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Booking>> FindByLodgerIdAsync(int lodgerId)
        {
            return await context.Bookings
                .AsNoTracking()
                .Where(x => x.LodgerId == lodgerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> ListAsync()
        {
            return await context.Bookings
              .AsNoTracking()
              .ToListAsync();
        }

        public void Remove(Booking booking)
        {
            context.Bookings.Remove(booking);
            context.SaveChanges();
        }

        public void Update(Booking booking)
        {
            context.Bookings.Update(booking);
            context.SaveChanges();
        }
    }
}
