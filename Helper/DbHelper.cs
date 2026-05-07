using Microsoft.Data.SqlClient;

namespace Helper
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(
                "Data Source=DESKTOP-J4ST655;Initial Catalog=clothesstoremgt;Integrated Security=True;Trust Server Certificate=True;"
            );
        }
    }
}