using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using MantaxHotel.Domaine.Service.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Services
{
    public class GuarantorService : IGuarantorService
    {
        private readonly IGuarantorRepository guarantorRepository;

        public GuarantorService(IGuarantorRepository guarantorRepository)
        {
            this.guarantorRepository = guarantorRepository;
        }
        public async Task<GuarantorResponse> DeleteAsync(int id)
        {
            try
            {
                var existingGuarantor = await guarantorRepository.FindByIdAsync(id);
                if (existingGuarantor == null)
                    return new GuarantorResponse("guarantor not found.");

                guarantorRepository.Remove(existingGuarantor);
                return new GuarantorResponse(existingGuarantor);
            }
            catch (Exception ex)
            {
                return new GuarantorResponse($"An error occurred when deleting the guarantor: {ex.Message}");
            }
        }

        public async Task<GuarantorResponse> FindByIdAsync(int id)
        {
            try
            {
                var guarantor = await guarantorRepository.FindByIdAsync(id);
                return guarantor == null ? new GuarantorResponse("guarantor not found") : new GuarantorResponse(guarantor);
            }
            catch (Exception ex)
            {
                return new GuarantorResponse($"An error occurred when deleting the guarantor: {ex.Message}");
            }
        }

        public Task<IEnumerable<Guarantor>> FindByLodgersIdAsync(int lodgerId)
        {
            return guarantorRepository.FindByLodgersIdAsync(lodgerId);
        }

        public Task<IEnumerable<Guarantor>> ListAsync()
        {
            return guarantorRepository.ListAsync();
        }

        public async Task<GuarantorResponse> SaveAsync(Guarantor guarantor)
        {
            try
            {
                await guarantorRepository.AddAsync(guarantor);
                return new GuarantorResponse(guarantor);
            }
            catch (Exception e)
            {
                return new GuarantorResponse($"An error occurred when saving the guarantor: {e.Message}");
            }
        }

        public async Task<GuarantorResponse> UpdateAsync(int id, Guarantor guarantor)
        {
            var existingGuarantor = await guarantorRepository.FindByIdAsync(id);

            if (existingGuarantor == null)
                return new GuarantorResponse("guarantor not found.");

            existingGuarantor.Gender = guarantor.Gender;
            existingGuarantor.Name = guarantor.Name;
            existingGuarantor.Firstname = guarantor.Firstname;
            existingGuarantor.Adress = guarantor.Adress;
            existingGuarantor.City = guarantor.City;
            existingGuarantor.Country = guarantor.Country;
            existingGuarantor.Email = guarantor.Email;
            existingGuarantor.PostalCode = guarantor.PostalCode;
            existingGuarantor.PhoneNumber = guarantor.PhoneNumber;
            existingGuarantor.LodgerId = guarantor.LodgerId;


            try
            {
                guarantorRepository.Update(existingGuarantor);
                return new GuarantorResponse(existingGuarantor);
            }
            catch (Exception ex)
            {
                return new GuarantorResponse($"An error occurred when updating the guarantor: {ex.Message}");

            }
        }
    }
}
