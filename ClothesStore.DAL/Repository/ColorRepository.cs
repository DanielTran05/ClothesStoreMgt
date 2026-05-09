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
    public class ColorRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-CIC0GCH;Database=clothesstoremgt;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<ColorDTO> GetAllColors()
        {
            var list = new List<ColorDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllColors", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ColorDTO
                            {
                                ColorID = reader.GetInt32(reader.GetOrdinal("ColorID")),
                                ColorName = reader.GetString(reader.GetOrdinal("ColorName"))
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void CreateColor(ColorDTO color)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateColor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ColorName", color.ColorName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateColor(ColorDTO color)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateColor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ColorID", color.ColorID);
                    cmd.Parameters.AddWithValue("@ColorName", color.ColorName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteColor(int colorId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteColor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ColorID", colorId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}