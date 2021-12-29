using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domaine.Repositories
{
    public interface ILodgerRepository
    {
        Task<IEnumerable<Lodger>> ListAsync();

        Task AddAsync(Lodger lodger);

        Task<Lodger> FindByIdAsync(int id);

        void Update(Lodger lodger);

        void Remove(Lodger lodger);
    }
}
