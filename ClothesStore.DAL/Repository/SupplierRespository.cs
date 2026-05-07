using Microsoft.Data.SqlClient;
using System.Data;
using ClothesStore.DAL.Models;
using Helper;

namespace ClothesStore.DAL.Repository
{
    public class SupplierRepository
    {
        public DataTable GetAll()
        {
            using var conn = DbHelper.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter("sp_GetSuppliers", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void Add(string name, string phone)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_AddSupplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Phone", phone);

            cmd.ExecuteNonQuery();
        }

        public void Update(int id, string name, string phone)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_UpdateSupplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Phone", phone);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("sp_DeleteSupplier", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}