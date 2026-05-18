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
        public User? GetCustomerByPhone(string phone)
        {
            return _context.Users
                .Where(x => x.PhoneNumber == phone)
                .FirstOrDefault();
        }
    }
}
