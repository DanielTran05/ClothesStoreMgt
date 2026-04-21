using ClothesStore.DAL.Models;
using ClothesStore.DAL.Repository;
using ClothesStore.DTO.UserDto;
using Helper;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.BUS
{
    public class AuthService
    {
        private readonly UserRepository userRepository;

        public AuthService()
        {
            userRepository = new UserRepository(new DAL.Context.ClothesStoreContext());
        }

        public User logIn(UserLoginRequest userLoginRequest)
        {
            var user = userRepository.getUserByUsername(userLoginRequest.Username);

            if (user == null || user.IsActive == false) return null;

            bool isValid = PasswordHelper.verifyPassword(userLoginRequest.Password, user.PasswordHash);

            return isValid ? user : null;
        }
    }
}
