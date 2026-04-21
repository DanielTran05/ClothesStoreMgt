using ClothesStore.DAL.Context;
using ClothesStore.DAL.Enums;
using ClothesStore.DAL.Models;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Repository
{
    public class UserRepository
    {
        private readonly ClothesStoreContext clothesStoreContext;

        public UserRepository(ClothesStoreContext clothesStoreContext)
        {
            this.clothesStoreContext = clothesStoreContext;
        }

        public User getUserByUsername(String userName)
        {
            return clothesStoreContext.Users.FirstOrDefault(u => u.Username == userName);
        }

        public void MockDataUser()
        {
            var mockUsers = new List<User>
            {
                new User { UserId = Guid.NewGuid(), Username = "admin", FullName = "admin", Email = "admin@store.com", Role = (int)UserRole.Admin },
                new User { UserId = Guid.NewGuid(), Username = "sale", FullName = "sale", Email = "sale@store.com", Role = (int)UserRole.SaleStaff },
                new User { UserId = Guid.NewGuid(), Username = "kho", FullName = "thukho", Email = "warehouse@store.com", Role = (int)UserRole.WarehouseStaff },
                new User { UserId = Guid.NewGuid(), Username = "customer", FullName = "khachthanhvien", Email = "customer@gmail.com", Role = (int)UserRole.Customer },
                new User { UserId = Guid.NewGuid(), Username = "guest", FullName = "khachvanglai", Email = "guest@gmail.com", Role = (int)UserRole.Guess }
            };

            try
            {
                bool hasChanges = false;
                string commonPassHash = PasswordHelper.HashPassword("123456");

                foreach (var user in mockUsers)
                {
                    bool isExist = clothesStoreContext.Users.Any(u => u.Username == user.Username);

                    if (!isExist)
                    {
                        user.PasswordHash = commonPassHash;
                        user.IsActive = true;
                        user.CreatedAt = DateTime.Now;

                        clothesStoreContext.Users.Add(user);
                        hasChanges = true;
                    }
                }

                if (hasChanges)
                {
                    clothesStoreContext.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("--- Seed Mock Users Successfully ---");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Data seeding error: " + ex.Message);
            }
        }
    }
}
