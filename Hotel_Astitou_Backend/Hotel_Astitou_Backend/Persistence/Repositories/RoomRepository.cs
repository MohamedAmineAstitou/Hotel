using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Persistence.Repositories
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(HotelAstitouContext context) : base(context)
        {
        }

        public async Task AddAsync(Room room)
        {
            await context.Rooms.AddAsync(room);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> FindByApartmentsIdAsync(int apartmentId)
        {
           return await context.Rooms
                .AsNoTracking()
                .Include(x => x.Apartement)
                .Where(x => x.ApartementId == apartmentId)
                .ToListAsync();
        }

        public async Task<Room> FindByIdAsync(int id)
        {
            return await context.Rooms
                .Include(x => x.Apartement)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await context.Rooms
                .AsNoTracking()
                .Include(x => x.Apartement)
                .Include(x => x.Apartement)
                .ToListAsync();
        }

        public void Remove(Room room)
        {
            context.Rooms.Remove(room);
            context.SaveChanges();
        }

        public void Update(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
        }
    }
}
