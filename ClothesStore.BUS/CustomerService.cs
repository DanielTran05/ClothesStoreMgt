using ClothesStore.DAL.Models;
using ClothesStore.DAL.Repository;
using System;
using System.Data;

namespace ClothesStore.BUS
{
    public class CustomerService
    {
        private CustomerServiceRepository repo =
            new CustomerServiceRepository();
        private CustomerRepository _repo = new CustomerRepository();
        public Order? GetCustomerByPhone(string phone)
        {
            return _repo.GetCustomerByPhone(phone);
        }

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
    }
}