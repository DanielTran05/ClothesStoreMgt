using ClothesStore.DAL.Repository;
using System.Data;

namespace ClothesStore.BUS
{
    public class SupplierService
    {
        private SupplierRepository repo = new SupplierRepository();

        public DataTable GetAll() => repo.GetAll();

        public void Add(string name, string phone)
            => repo.Add(name, phone);

        public void Update(int id, string name, string phone)
            => repo.Update(id, name, phone);

        public void Delete(int id)
            => repo.Delete(id);
    }
}