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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public async Task<RoomResponse> DeleteAsync(int id)
        {
            try
            {
                var existingRoom = await roomRepository.FindByIdAsync(id);
                if (existingRoom == null)
                    return new RoomResponse("room not found.");

                roomRepository.Remove(existingRoom);
                return new RoomResponse(existingRoom);
            }
            catch (Exception ex)
            {
                return new RoomResponse($"An error occurred when deleting the room: {ex.Message}");
            }
        }

        public Task<IEnumerable<Room>> FindByApartmentsIdAsync(int apartmentsId)
        {

            return roomRepository.FindByApartmentsIdAsync(apartmentsId);

        }

        public async Task<RoomResponse> FindByIdAsync(int id)
        {
            try
            {
                var room = await roomRepository.FindByIdAsync(id);
                return room == null ? new RoomResponse("room not found") : new RoomResponse(room);
            }
            catch (Exception e)
            {
                return new RoomResponse($"An error occurred when saving the room: {e.Message}");
            }
        }

        public Task<IEnumerable<Room>> ListAsync()
        {
            return roomRepository.ListAsync();
        }

        public async Task<RoomResponse> SaveAsync(Room room)
        {
            try
            {
                await roomRepository.AddAsync(room);
                return new RoomResponse(room);
            }
            catch (Exception e)
            {
                return new RoomResponse($"An error occurred when saving the room: {e.Message}");
            }
        }

        public async Task<RoomResponse> UpdateAsync(int id, Room room)
        {
            try
            {
                var existingRoom = await roomRepository.FindByIdAsync(id);

                if (existingRoom == null)
                    return new RoomResponse("Reservation not found.");
                existingRoom.Surface = room.Surface;
                existingRoom.Idapartment = room.Idapartment;
                existingRoom.ApartementId = room.ApartementId;


                roomRepository.Update(existingRoom);
                return new RoomResponse(existingRoom);
            }
            catch (Exception ex)
            {
                return new RoomResponse($"An error occurred when updating the Reservation: {ex.Message}");
            }
        }
    }
}
