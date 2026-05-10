using ClothesStore.DTO;
using ClothesStore.DTO.ProductDto;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Helper;
namespace ClothesStore.DAL.Repository
{
    public class ProductVariantRepository
    {

        public List<ProductVariantDTO> GetVariantsByProductID(int productId)
        {
            var list = new List<ProductVariantDTO>();
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetVariantsByProductID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ProductVariantDTO
                            {
                                VariantID = reader.GetInt32(reader.GetOrdinal("VariantID")),
                                ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                                ColorID = reader.GetInt32(reader.GetOrdinal("ColorID")),
                                ColorName = reader.IsDBNull(reader.GetOrdinal("ColorName")) ? null : reader.GetString(reader.GetOrdinal("ColorName")),
                                SizeID = reader.GetInt32(reader.GetOrdinal("SizeID")),
                                SizeName = reader.IsDBNull(reader.GetOrdinal("SizeName")) ? null : reader.GetString(reader.GetOrdinal("SizeName")),
                                SKU = reader.IsDBNull(reader.GetOrdinal("SKU")) ? null : reader.GetString(reader.GetOrdinal("SKU")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                AmountInStock = reader.IsDBNull(reader.GetOrdinal("AmountInStock")) ? 0 : reader.GetInt32(reader.GetOrdinal("AmountInStock")),
                                Img = reader.IsDBNull(reader.GetOrdinal("Img")) ? null : reader.GetString(reader.GetOrdinal("Img"))
                            });
                        }
                    }
                }
            }
            return list;
        }

        public void CreateVariant(ProductVariantDTO variant)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_CreateVariant", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", variant.ProductID);
                    cmd.Parameters.AddWithValue("@ColorID", variant.ColorID);
                    cmd.Parameters.AddWithValue("@SizeID", variant.SizeID);
                    cmd.Parameters.AddWithValue("@SKU", variant.SKU ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", variant.Price);
                    //cmd.Parameters.AddWithValue("@AmountInStock", variant.AmountInStock);
                    cmd.Parameters.AddWithValue("@Img", variant.Img ?? (object)DBNull.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateVariant(ProductVariantDTO variant)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_UpdateVariant", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VariantID", variant.VariantID);
                    cmd.Parameters.AddWithValue("@ColorID", variant.ColorID);
                    cmd.Parameters.AddWithValue("@SizeID", variant.SizeID);
                    cmd.Parameters.AddWithValue("@SKU", variant.SKU ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Price", variant.Price);
                    //cmd.Parameters.AddWithValue("@AmountInStock", variant.AmountInStock);
                    cmd.Parameters.AddWithValue("@Img", variant.Img ?? (object)DBNull.Value);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteVariant(int variantId)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_DeleteVariant", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VariantID", variantId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}