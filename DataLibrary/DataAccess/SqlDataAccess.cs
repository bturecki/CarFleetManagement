using Dapper;
using System.Configuration;
using System.Data;
namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        public static string GetConnectionString()
        {
            return @"Server=tcp:carfleetmanagementdb.database.windows.net,1433;Initial Catalog=CarFleetManagement_db;Persist Security Info=False;User ID=Radek123!;Password=TrudneHaslo123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
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
