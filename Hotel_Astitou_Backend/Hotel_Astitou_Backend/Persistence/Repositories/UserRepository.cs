using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Infrastructure;
using Hotel_Astitou_Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(HotelAstitouContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            context.SaveChanges();
        }

        public Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            return context.Users

                .SingleOrDefaultAsync(x =>
                    x.Username == username &&
                    x.Password == CryptographyTool.CryptSHA512(password)
                );
        }

        public async Task<User> FindByIdAsync(int userId)
        {
            return await context.Users
                 .FirstAsync(x => x.Id == userId);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await context.Users
                .AsNoTracking()
                .ToListAsync();
        }

        public void Remove(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
