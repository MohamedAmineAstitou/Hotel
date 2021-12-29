using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domaine.Repositories
{
    public interface IApartmentRepository
    {
        Task<IEnumerable<Apartment>> ListAsync();

        Task AddAsync(Apartment apartment);

        Task<Apartment> FindByIdAsync(int id);

        void Update(Apartment apartment);

        void Remove(Apartment apartment);
    }
}
