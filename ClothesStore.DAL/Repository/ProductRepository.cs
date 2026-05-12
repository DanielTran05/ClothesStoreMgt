
﻿using Microsoft.Data.SqlClient;
using System.Data;
using Helper;
﻿using ClothesStore.DTO;
using ClothesStore.DTO.ProductDto;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
namespace ClothesStore.DAL.Repository
{
    public class ProductRepository
    {
        private readonly string _connectionString = "Server=.;Database=clothesstoremgt;Trusted_Connection=True;TrustServerCertificate=True;";
        public DataTable SearchStaff(string keyword)
        {
            using var conn = DbHelper.GetConnection();

            SqlDataAdapter da = new SqlDataAdapter("sp_SearchProductStaff", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Keyword", keyword);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var list = new List<ProductDTO>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductDTO
                            {
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                                CategoryID = reader.GetInt32(reader.GetOrdinal("CategoryID")),
                                CategoryName = reader.IsDBNull(reader.GetOrdinal("CategoryName")) ? null : reader.GetString(reader.GetOrdinal("CategoryName"))
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void CreateProduct(ProductDTO product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(ProductDTO product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}