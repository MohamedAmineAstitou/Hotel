using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();

        Task<UserResponse> FindByIdAsync(int id);

        Task<UserResponse> SaveAsync(User user);

        Task<UserResponse> UpdateAsync(int id, User user);

        Task<UserResponse> DeleteAsync(int id);

        Task<UserResponse> Authenticate(string username, string password);
    }
}
