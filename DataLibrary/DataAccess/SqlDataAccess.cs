using Dapper;
using System.Configuration;
using System.Data;
namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public static string GetConnectionString()
        {
            return @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=CarMgmtSystemDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();
            }
        }
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }
        public static int DeleteData(string sql)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql);
            }
        }
        public static int UpdateData(string sql)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql);
            }
        }
    }
}
