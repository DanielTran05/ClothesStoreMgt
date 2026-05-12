using ClothesStore.DAL.Repository;
using Helper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ClothesStore.BUS
{
    public class CustomerService
    {
        private CustomerServiceRepository repo =
            new CustomerServiceRepository();

        public DataTable GetAll()
            => repo.GetAll();

        public void Add(
            Guid customerId,
            string reason)
            => repo.Add(
                customerId,
                reason);

        public void Handle(
            int customerServiceId,
            Guid employeeId)
            => repo.Handle(
                customerServiceId,
                employeeId);

        public void Reject(
            int customerServiceId,
            Guid employeeId)
            => repo.Reject(
                customerServiceId,
                employeeId);

        public void Solve(
            int customerServiceId,
            string response,
            Guid employeeId)
        {
            using (SqlConnection conn =
                DbHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmd =
                    new SqlCommand(
                        "sp_SolveCustomerService",
                        conn);

                cmd.CommandType =
                    CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue(
                    "@CustomerServiceID",
                    customerServiceId);

                cmd.Parameters.AddWithValue(
                    "@EmployeeResponse",
                    response);

                cmd.Parameters.AddWithValue(
                    "@EmployeeID",
                    employeeId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}