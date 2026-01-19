using System.Configuration;
using System.Data.SqlClient;

namespace Sim1Test
{
    public static class Database
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Qulator"].ConnectionString;
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
