using ClothesStore.DAL.Context;
using ClothesStore.DAL.Enums;
using ClothesStore.DAL.Models;
using ClothesStore.DTO.UserDto;
using Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
            return clothesStoreContext.Users.AsNoTracking().FirstOrDefault(u => u.Username == userName);
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

        public List<ReadUserDTO> GetAllEmployees()
        {
            List<ReadUserDTO> list = new List<ReadUserDTO>();
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure; 
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            list.Add(new ReadUserDTO
                            {
                                UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString(reader.GetOrdinal("FullName")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                                Role = reader.GetInt32(reader.GetOrdinal("Role")),
                                IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.IsDBNull(reader.GetOrdinal("CreatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<ReadUserDTO> GetAllCustomers()
        {
            List<ReadUserDTO> list = new List<ReadUserDTO>();
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllCustomers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ReadUserDTO
                            {
                                UserID = reader.GetGuid(reader.GetOrdinal("UserID")),
                                Username = reader.GetString(reader.GetOrdinal("Username")),
                                FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString(reader.GetOrdinal("FullName")),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                                Role = reader.GetInt32(reader.GetOrdinal("Role")),
                                IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? (bool?)null : reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.IsDBNull(reader.GetOrdinal("CreatedAt")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void CreateEmployee(CreateUserRequest request, string hashedPassword)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", request.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword); 
                    cmd.Parameters.AddWithValue("@FullName", request.FullName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", request.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", request.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", request.Role);
                    cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                    conn.Open();
                    cmd.ExecuteNonQuery(); 
                }
            }
        }

        public void UpdateEmployee(UpdateUserRequest request)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserID", request.UserID);
                    cmd.Parameters.AddWithValue("@FullName", request.FullName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", request.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", request.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", request.Role);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ToggleUserStatus(Guid userId, bool isActive)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ToggleUserStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ResetUserPassword(Guid userId, string newHashedPassword)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ResetUserPassword", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@PasswordHash", newHashedPassword);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CheckUsernameExists(string username)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckUsernameExists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; 
                }
            }
        }
    }
}
