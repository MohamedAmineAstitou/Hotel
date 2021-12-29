using Hotel_Astitou_Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Domaine.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();

        Task AddAsync(User user);

        Task<User> FindByIdAsync(int user);

        void Update(User user);

        void Remove(User user);

        Task<User> Authenticate(string username, string password);
    }
}
