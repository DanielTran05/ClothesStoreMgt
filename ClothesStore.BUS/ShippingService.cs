using ClothesStore.DAL.Models;
using ClothesStore.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClothesStore.BUS
{
    public class ShippingService
    {
        private readonly ShippingRepository _shippingRepo = new ShippingRepository();

        public List<ShippingProvider> GetShippers()
        {
            return _shippingRepo.GetActiveShippers();
        }
    }
}
