using System.Data.SqlClient;

namespace StudentsWebApplication.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;


        /// <summary>
        /// No instances of this class should be available
        /// </summary>
        private DBHelper() { }  

        public static SqlConnection? GetConnection()
        {
            conn = null;
            try
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.AddJsonFile("appsetings.json");



                // string url = @"Data Source=localhost\sqlexpress;Initial Catalog=StudentsDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

                string url = configurationManager.GetConnectionString("DefaultConnection");
                conn = new SqlConnection(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(  e.StackTrace );
            }

            return conn;
        }

        public static void CloseConnection()
        {
            conn?.Close();
        }

    }
}
