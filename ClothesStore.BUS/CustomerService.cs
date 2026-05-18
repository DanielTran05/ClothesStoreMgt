using ClothesStore.DAL.Models;
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
        private CustomerRepository _repo = new CustomerRepository();

        public DataTable GetAll()
            => repo.GetAll();

        public void Add(Guid customerId, string reason)
            => repo.Add(customerId, reason);

        public void Handle(int id, Guid employeeId)
            => repo.Handle(id, employeeId);

        public void Reject(int id, Guid employeeId)
            => repo.Reject(id, employeeId);
        public void Reset(int id)
            => repo.Reset(id);

        public void Solve(int id, string response, Guid employeeId)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "sp_SolveCustomerService",
                    conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerServiceID", id);
                cmd.Parameters.AddWithValue("@EmployeeResponse", response);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                cmd.ExecuteNonQuery();
            }
        }
        public User? GetCustomerByPhone(string phone)
        {
            return _repo.GetCustomerByPhone(phone);
        }
    }
}