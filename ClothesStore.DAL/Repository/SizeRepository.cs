using ClothesStore.DTO;
using ClothesStore.DTO.MasterDataDto;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace ClothesStore.DAL.Repository
{
    public class SizeRepository
    {
        private readonly string _connectionString = "Server=.;Database=clothesstoremgt;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<SizeDTO> GetAllSizes()
        {
            var list = new List<SizeDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllSizes", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new SizeDTO
                            {
                                SizeID = reader.GetInt32(reader.GetOrdinal("SizeID")),
                                SizeName = reader.GetString(reader.GetOrdinal("SizeName"))
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void CreateSize(SizeDTO size)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateSize", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SizeName", size.SizeName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateSize(SizeDTO size)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateSize", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SizeID", size.SizeID);
                    cmd.Parameters.AddWithValue("@SizeName", size.SizeName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteSize(int sizeId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteSize", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SizeID", sizeId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}