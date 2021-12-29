using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> ListAsync();

        Task<ApartmentResponse> FindByIdAsync(int id);

        Task<ApartmentResponse> SaveAsync(Apartment apartments);

        Task<ApartmentResponse> UpdateAsync(int id, Apartment apartments);

        Task<ApartmentResponse> DeleteAsync(int id);
    }
}
