using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domaine.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> ListAsync();

        Task AddAsync(Booking booking);

        Task<Booking> FindByIdAsync(int id);

        Task<IEnumerable<Booking>> FindByLodgerIdAsync(int lodgerId);

        void Update(Booking booking);

        void Remove(Booking booking);
    }
}
