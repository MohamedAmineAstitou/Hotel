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
    public class LodgerService : ILodgerService
    {
        private readonly ILodgerRepository lodgerRepository;

        public LodgerService(ILodgerRepository lodgerRepository)
        {
            this.lodgerRepository = lodgerRepository;
        }
        public async Task<LodgerResponse> DeleteAsync(int id)
        {
            try
            {
                var existingLodger = await lodgerRepository.FindByIdAsync(id);
                if (existingLodger == null)
                    return new LodgerResponse("Lodger not found.");


                lodgerRepository.Remove(existingLodger);
                return new LodgerResponse(existingLodger);
            }
            catch (Exception ex)
            {
                return new LodgerResponse($"An error occurred when deleting the lodger: {ex.Message}");
            }
        }

        public async Task<LodgerResponse> FindByIdAsync(int id)
        {
            try
            {
                var lodger = await lodgerRepository.FindByIdAsync(id);
                return lodger == null ? new LodgerResponse("lodger not found") : new LodgerResponse(lodger);
            }
            catch (Exception ex)
            {
                return new LodgerResponse($"An error occurred when deleting the lodger: {ex.Message}");
            }
        }

        public Task<IEnumerable<Lodger>> ListAsync()
        {
            return lodgerRepository.ListAsync();
        }

        public async Task<LodgerResponse> SaveAsync(Lodger lodger)
        {
            try
            {
                await lodgerRepository.AddAsync(lodger);
                return new LodgerResponse(lodger);
            }
            catch (Exception e)
            {
                return new LodgerResponse($"An error occurred when saving the lodger: {e.Message}");
            }
        }

        public async Task<LodgerResponse> UpdateAsync(int id, Lodger lodger)
        {
            try
            {
                var existingLodger = await lodgerRepository.FindByIdAsync(id);

                if (existingLodger == null)
                    return new LodgerResponse("lodger not found.");
                existingLodger.Name = lodger.Name;
                existingLodger.Firstname = lodger.Firstname;
                existingLodger.Gender = lodger.Gender;
                existingLodger.Civility = lodger.Civility;
                existingLodger.Adress = lodger.Adress;
                existingLodger.City = lodger.City;
                existingLodger.Country = lodger.Country;
                existingLodger.Email = lodger.Email;
                existingLodger.PostalCode = lodger.PostalCode;
                existingLodger.PhoneNumber = lodger.PhoneNumber;
                existingLodger.Birthday = lodger.Birthday;
                existingLodger.Birthplace = lodger.Birthplace;
                existingLodger.NationalRegister = lodger.NationalRegister;


                lodgerRepository.Update(existingLodger);
                return new LodgerResponse(existingLodger);
            }
            catch (Exception ex)
            {
                return new LodgerResponse($"An error occurred when updating the lodger: {ex.Message}");
            }
        }
    }
}
