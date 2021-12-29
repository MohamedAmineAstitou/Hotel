using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domaine.Repositories
{
    public interface IGuarantorRepository
    {
        Task<IEnumerable<Guarantor>> ListAsync();

        Task AddAsync(Guarantor guarantor);

        Task<Guarantor> FindByIdAsync(int id);

        Task<IEnumerable<Guarantor>> FindByLodgersIdAsync(int lodgerId);

        void Update(Guarantor guarantor);

        void Remove(Guarantor guarantor);
    }
}
