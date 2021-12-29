using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domaine.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAsync();

        Task AddAsync(Room room);

        Task<Room> FindByIdAsync(int id);

        Task<IEnumerable<Room>> FindByApartmentsIdAsync(int apartmentId);

        void Update(Room room);

        void Remove(Room room);
    }
}
