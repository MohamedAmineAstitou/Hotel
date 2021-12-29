using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Persistence.Repositories
{
    public class GuarantorRepository : BaseRepository, IGuarantorRepository
    {
        public GuarantorRepository(HotelAstitouContext context) : base(context)
        {
        }

        public async Task AddAsync(Guarantor guarantor)
        {
            await context.Guarantors.AddAsync(guarantor);
            context.SaveChanges();
        }

        public async Task<Guarantor> FindByIdAsync(int id)
        {
            return await context.Guarantors
                 .FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Guarantor>> FindByLodgersIdAsync(int lodgerId)
        {
            return await context.Guarantors
               .AsNoTracking()
               .Where(x => x.Id == lodgerId)
               .ToListAsync();
        }

        public async Task<IEnumerable<Guarantor>> ListAsync()
        {
            return await context.Guarantors
                 .AsNoTracking()
                .ToListAsync();
        }

        public void Remove(Guarantor guarantor)
        {
            context.Guarantors.Remove(guarantor);
            context.SaveChanges();
        }

        public void Update(Guarantor guarantor)
        {
            context.Guarantors.Update(guarantor);
            context.SaveChanges();
        }
    }
}
