using System.Data;
using ClothesStore.DAL.Repository;

namespace ClothesStore.BUS
{
    public class ProductService
    {
        private ProductRepository repo = new ProductRepository();

        public DataTable SearchProductForStaff(string keyword)
        {
            return repo.SearchStaff(keyword);
        }
    }
}