using ClothesStore.DAL;
using ClothesStore.DAL.Context;
using ClothesStore.DAL.Repository;
using ClothesStore.DTO.UserDto;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.BUS
{
    public class UserService
    {
        private readonly UserRepository _userRepo;

        public UserService()
        {
            ClothesStoreContext context = new ClothesStoreContext();
            _userRepo = new UserRepository(context);
        }

        public List<ReadUserDTO> GetAllEmployees()
        {
            return _userRepo.GetAllEmployees();
        }


        public void CreateEmployee(CreateUserRequest request)
        {
            if (_userRepo.CheckUsernameExists(request.Username))
            {
                throw new Exception("Tên đăng nhập này đã tồn tại trong hệ thống. Vui lòng chọn một tên khác!");
            }
            string hashedPassword = PasswordHelper.HashPassword(request.Password);
            _userRepo.CreateEmployee(request, hashedPassword);
        }

        public void UpdateEmployee(UpdateUserRequest request)
        {
            _userRepo.UpdateEmployee(request);
        }

        public void ToggleUserStatus(Guid userId, bool isActive)
        {
            _userRepo.ToggleUserStatus(userId, isActive);
        }

        public void ResetUserPassword(ResetPasswordRequest request)
        {
            string newHashedPassword = PasswordHelper.HashPassword(request.NewPassword);
            _userRepo.ResetUserPassword(request.UserID, newHashedPassword);
        }

        public void ResetUserPassword(Guid userId, string newPlainPassword)
        {
            string hashedPassword = Helper.PasswordHelper.HashPassword(newPlainPassword);
            _userRepo.ResetUserPassword(userId, hashedPassword);
        }
    }
}
