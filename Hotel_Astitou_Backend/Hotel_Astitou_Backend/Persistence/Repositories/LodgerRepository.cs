using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Persistence.Repositories
{
    public class LodgerRepository : BaseRepository, ILodgerRepository
    {
        public LodgerRepository(HotelAstitouContext context) : base(context)
        {
        }

        public async Task AddAsync(Lodger lodger)
        {
            await context.Lodgers.AddAsync(lodger);
            context.SaveChanges();
        }

        public async Task<Lodger> FindByIdAsync(int id)
        {
            return await context.Lodgers
                .FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Lodger>> ListAsync()
        {
            return await context.Lodgers
              .AsNoTracking()
              .ToListAsync();
        }

        public void Remove(Lodger lodger)
        {
            context.Lodgers.Remove(lodger);
            context.SaveChanges();
        }

        public void Update(Lodger lodger)
        {
            context.Lodgers.Update(lodger);
            context.SaveChanges();
        }
    }
}
