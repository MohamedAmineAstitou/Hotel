using Hotel_Astitou_Backend.Model;
using MantaxHotel.Domaine.Service.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services
{
    public interface ILodgerService
    {
        Task<IEnumerable<Lodger>> ListAsync();

        Task<LodgerResponse> FindByIdAsync(int id);

        Task<LodgerResponse> SaveAsync(Lodger lodger);

        Task<LodgerResponse> UpdateAsync(int id, Lodger lodger);

        Task<LodgerResponse> DeleteAsync(int id);
    }
}
