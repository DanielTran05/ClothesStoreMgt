using Microsoft.Data.SqlClient;
using System;
using System.Data;
using Helper;

namespace ClothesStore.DAL.Repository
{
    public class CustomerServiceRepository
    {
        public DataTable GetAll()
        {
            using var conn = DbHelper.GetConnection();

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "sp_GetCustomerService",
                    conn);

            da.SelectCommand.CommandType =
                CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            da.Fill(dt);

            return dt;
        }

        public void Add(
    Guid customerId,
    string reason)
        {
            using var conn = DbHelper.GetConnection();

            conn.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_AddCustomerService",
                    conn);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@CustomerID",
                customerId);

            cmd.Parameters.AddWithValue(
                "@Reason",
                reason);

            cmd.ExecuteNonQuery();
        }

        public void Handle(
            int customerServiceId,
            Guid employeeId)
        {
            using var conn = DbHelper.GetConnection();

            conn.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_HandleCustomerService",
                    conn);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@CustomerServiceID",
                customerServiceId);

            cmd.Parameters.AddWithValue(
                "@EmployeeID",
                employeeId);

            cmd.ExecuteNonQuery();
        }

        public void Reject(
    int customerServiceId,
    Guid employeeId)
        {
            using var conn = DbHelper.GetConnection();

            conn.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "sp_RejectCustomerService",
                    conn);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@CustomerServiceID",
                customerServiceId);

            cmd.Parameters.AddWithValue(
                "@EmployeeID",
                employeeId);

            cmd.ExecuteNonQuery();
        }
    }
}