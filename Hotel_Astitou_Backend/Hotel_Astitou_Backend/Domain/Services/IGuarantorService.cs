using Hotel_Astitou_Backend.Model;
using MantaxHotel.Domaine.Service.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services
{
    public interface IGuarantorService
    {
        Task<IEnumerable<Guarantor>> ListAsync();


        Task<GuarantorResponse> FindByIdAsync(int id);

        Task<IEnumerable<Guarantor>> FindByLodgersIdAsync(int lodgerId);

        Task<GuarantorResponse> SaveAsync(Guarantor guarantor);

        Task<GuarantorResponse> UpdateAsync(int id, Guarantor guarantor);

        Task<GuarantorResponse> DeleteAsync(int id);
    }
}
