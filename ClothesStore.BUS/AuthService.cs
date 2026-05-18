using ClothesStore.DAL.Models;
using ClothesStore.DAL.Repository;
using ClothesStore.DTO.UserDto;
using Helper;
using System;

namespace ClothesStore.BUS
{
    public class AuthService
    {
        private readonly UserRepository userRepository;

        public AuthService()
        {
            userRepository = new UserRepository(new DAL.Context.ClothesStoreContext());
        }
        public User getUserByUsername(string username)
        {
            return userRepository.getUserByUsername(username);
        }

        public User logIn(UserLoginRequest userLoginRequest)
        {
            var user = userRepository.getUserByUsername(userLoginRequest.Username);

            if (user == null) return null;
            bool isValid = PasswordHelper.verifyPassword(userLoginRequest.Password, user.PasswordHash);
            return isValid ? user : null;
        }
    }
}