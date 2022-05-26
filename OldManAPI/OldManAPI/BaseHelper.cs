using System.Data.SqlClient;

namespace OldManAPI
{
    public class BaseHelper
    {
        private static readonly string connectionString = "Data Source=43.142.30.200,2522;Initial Catalog=OLDMAN;User Id=sa;Password=zaq1ZAQ!;";

        public static readonly string WebPrefix = @"http://43.142.30.200";

        public static SqlConnection GetConnect()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
