using ClothesStore.DAL.Context;
using ClothesStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Repository
{
    public class CustomerRepository
    {
        private readonly ClothesStoreContext _context = new ClothesStoreContext();
        public Order? GetCustomerByPhone(string phone)
        {
            return _context.Orders
                .Where(x => x.ReceiverPhone == phone)
                .OrderByDescending(x => x.OrderDate)
                .FirstOrDefault();
        }
    }
}
