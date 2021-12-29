using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Persistence.Repositories
{
    public class ApartmentRepository : BaseRepository, IApartmentRepository
    {
        public ApartmentRepository(HotelAstitouContext context) : base(context)
        {
        }

        public async Task AddAsync(Apartment apartment)
        {
            await context.Apartments.AddAsync(apartment);
            await context.SaveChangesAsync();
        }

        public async Task<Apartment> FindByIdAsync(int id)
        {
            return await context.Apartments.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Apartment>> ListAsync()
        {
            return await context.Apartments
                .AsNoTracking()
                .Include(x => x.Rooms)
                .ToListAsync();
        }

        public void Remove(Apartment apartment)
        {
            context.Apartments.Remove(apartment);
            context.SaveChanges();
        }

        public void Update(Apartment apartment)
        {
            context.Apartments.Update(apartment);
            context.SaveChanges();
        }
    }
}
