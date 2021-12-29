using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
        }
        public async Task<ApartmentResponse> DeleteAsync(int id)
        {
            try
            {
                var existingApartment = await apartmentRepository.FindByIdAsync(id);
                if (existingApartment == null)
                    return new ApartmentResponse("Apartment not found.");


                apartmentRepository.Remove(existingApartment);
                return new ApartmentResponse(existingApartment);
            }
            catch (Exception ex)
            {
                return new ApartmentResponse($"An error occurred when deleting the apartment: {ex.Message}");
            }
        }

        public async Task<ApartmentResponse> FindByIdAsync(int id)
        {
            var apartment = await apartmentRepository.FindByIdAsync(id);
            return apartment == null ? new ApartmentResponse("Apartment not found") : new ApartmentResponse(apartment);
        }

        public Task<IEnumerable<Apartment>> ListAsync()
        {
            return apartmentRepository.ListAsync();
        }

        public async Task<ApartmentResponse> SaveAsync(Apartment apartments)
        {
            try
            {
                await apartmentRepository.AddAsync(apartments);
                return new ApartmentResponse(apartments);
            }
            catch (Exception e)
            {
                return new ApartmentResponse($"An error occurred when saving the apartments: {e.Message}");
            }
        }

        public async Task<ApartmentResponse> UpdateAsync(int id, Apartment apartments)
        {

            try
            {
                var existingApartment = await apartmentRepository.FindByIdAsync(id);

                if (existingApartment == null)
                    return new ApartmentResponse("apartment not found.");

                existingApartment.BedroomArea = apartments.BedroomArea;
                existingApartment.Adress = apartments.Adress;
                existingApartment.DiningArea = apartments.DiningArea;
                existingApartment.RentPrice = apartments.RentPrice;
                existingApartment.TotalArea = apartments.TotalArea;
                existingApartment.RoomNumber = apartments.RoomNumber;
                existingApartment.Floor = apartments.Floor;
                existingApartment.Type = apartments.Type;

                apartmentRepository.Update(existingApartment);
                return new ApartmentResponse(existingApartment);
            }
            catch (Exception ex)
            {
                return new ApartmentResponse($"An error occurred when updating the apartment: {ex.Message}");
            }
        }
    }
}
