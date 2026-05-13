using ClothesStore.DAL.Context;
using ClothesStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.DAL.Repository
{
    public class ShippingRepository
    {
        private readonly ClothesStoreContext _context = new ClothesStoreContext();

        public List<ShippingProvider> GetActiveShippers()
        {
            return _context.ShippingProviders
                           .Where(s => s.IsActive == true)
                           .ToList();
        }
    }
}
