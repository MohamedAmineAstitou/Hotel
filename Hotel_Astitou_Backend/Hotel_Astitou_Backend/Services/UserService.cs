using Hotel_Astitou_Backend.Domain.Services;
using Hotel_Astitou_Backend.Domain.Services.Communication;
using Hotel_Astitou_Backend.Domaine.Repositories;
using Hotel_Astitou_Backend.Infrastructure;
using Hotel_Astitou_Backend.Model;
using MantaxHotel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<UserResponse> Authenticate(string username, string password)
        {
            var authenticateUser = await userRepository.Authenticate(username, password);
            if (authenticateUser == null)
                return new UserResponse("username or/and password is incorrect");

            authenticateUser.Token = JWTProvider.GenerateJWT(authenticateUser);
            return new UserResponse(authenticateUser);
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            try
            {
                var existingUser = await userRepository.FindByIdAsync(id);
                if (existingUser == null)
                    return new UserResponse("User not found.");


                userRepository.Remove(existingUser);
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when deleting the User: {ex.Message}");
            }
        }

        public async Task<UserResponse> FindByIdAsync(int id)
        {
            try
            {
                var user = await userRepository.FindByIdAsync(id);
                return user == null ? new UserResponse("user not found") : new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }

        public Task<IEnumerable<User>> ListAsync()
        {
            return userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await userRepository.AddAsync(user);
                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            try
            {
                var existingUser = await userRepository.FindByIdAsync(id);

                if (existingUser == null)
                    return new UserResponse("user not found.");
                existingUser.Username = user.Username;
                existingUser.Password = CryptographyTool.CryptSHA512(user.Password);
                existingUser.Email = user.Email;


                userRepository.Update(existingUser);
                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error occurred when updating the user: {ex.Message}");
            }
        }
    }
}
