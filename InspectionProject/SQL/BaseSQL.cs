using System.Configuration;

namespace InspectionProject.SQL
{
    public class BaseSQL
    {
        readonly string server = ConfigurationManager.AppSettings["sql_server"];
        readonly string userID = ConfigurationManager.AppSettings["sql_username"];
        readonly string password = ConfigurationManager.AppSettings["sql_password"];

        /// <summary>
        /// Generates connection string to SQL 'database'
        /// </summary>
        /// <param name="database">Name of database to connect to</param>
        /// <returns></returns>
        public string ConnStr(string database)
        {
            string connStr = string.Format("Server={0};Database={1};Uid={2};Pwd={3};",
                                          server, database, userID, password);

            return connStr;
        }
    }
}