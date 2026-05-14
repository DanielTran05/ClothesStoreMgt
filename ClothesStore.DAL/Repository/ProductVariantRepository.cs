using ClothesStore.DAL.Context;
using ClothesStore.DTO;
using ClothesStore.DTO.ProductDto;
using Helper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
namespace ClothesStore.DAL.Repository
{
    public class ProductVariantRepository
    {
        private readonly string _connectionString = "Server=.;Database=clothesstoremgt;Trusted_Connection=True;TrustServerCertificate=True;";
        private readonly ClothesStoreContext _context = new ClothesStoreContext();


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

        public List<(string ProductName, decimal Price, int VariantID)> GetVariantDetailsForGrid()
        {
            using (var db = new ClothesStoreContext())
            {
                var query = from pv in db.ProductVariants
                            join p in db.Products on pv.ProductId equals p.ProductId
                            select new { p.ProductName, pv.Price, pv.VariantId };

                return query.AsEnumerable()
                            .Select(x => (x.ProductName, x.Price, x.VariantId))
                            .ToList();
            }
        }
        public dynamic GetVariantById(int variantId)
        {
            return _context.ProductVariants
                .Where(v => v.VariantId == variantId)
                .Select(v => new
                {
                    v.VariantId,
                    ProductName = v.Product.ProductName
                })
                .FirstOrDefault();
        }

        public ProductVariantDTO GetVariantBySKU(string sku)
        {
            return _context.ProductVariants
                .Where(v => v.Sku == sku)
                .Select(v => new ProductVariantDTO
                {
                    VariantID = v.VariantId,
                    SKU = v.Sku
                })
                .FirstOrDefault();
        }


    }
}