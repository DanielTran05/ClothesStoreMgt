using Microsoft.Data.SqlClient;
using System.Data;
using Helper;

namespace ClothesStore.DAL.Repository
{
    public class ProductRepository
    {
        public DataTable SearchStaff(string keyword)
        {
            using var conn = DbHelper.GetConnection();

            SqlDataAdapter da = new SqlDataAdapter("sp_SearchProductStaff", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Keyword", keyword);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}