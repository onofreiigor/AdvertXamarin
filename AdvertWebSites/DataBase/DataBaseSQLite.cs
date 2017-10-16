using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertWebSites
{
    public class DataBaseSqLite
    {
        private static string DBName = "AdvertDataBase.sqlite";
        public static SQLiteConnection DbConnection { get; set; }
        private static SQLiteCommand SqlCommand { get; set; }

        public static bool InitConnectionSqLite()
        {
            SQLiteConnection.CreateFile(DBName);
            DbConnection = new SQLiteConnection($"Data Source={DBName};Version=3;");
            try
            {
                if (DbConnection.State != ConnectionState.Open)
                    DbConnection.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void GenerateCategory(WebSites site)
        {

        }

        public static void SelectCategoryBySite(WebSites site)
        {
            string sql = $"select *  from AdvertSites where name = {site.Name}";
            SqlCommand = new SQLiteCommand(sql, DbConnection);
            SQLiteDataReader reader = SqlCommand.ExecuteReader();
            if (reader.Read())
            {
                foreach (Category cat in site.Categories)
                {
                    sql = $"insert into Category where ";
                }
            }
            else
            {
                foreach (Category cat in site.Categories)
                {
                    
                }
            }
        }
    }
}
