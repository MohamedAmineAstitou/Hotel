using Hotel_Astitou_Backend.Model;
using MantaxHotel.Domaine.Service.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> ListAsync();

        Task<RoomResponse> FindByIdAsync(int id);

        Task<RoomResponse> SaveAsync(Room room);

        Task<RoomResponse> UpdateAsync(int id, Room room);

        Task<RoomResponse> DeleteAsync(int id);
        Task<IEnumerable<Room>> FindByApartmentsIdAsync(int apartmentsId);
    }
}
