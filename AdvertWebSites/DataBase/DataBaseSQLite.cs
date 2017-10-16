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
            //SQLiteConnection.CreateFile(DBName);
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
            foreach (Category cat in site.Categories)
            {
                string sql =
                    $"insert into Category (Url, SiteUrl, NameRo) values('{cat.Url}', '{site.Url.Value}', '{cat.Name}')";
                try
                {
                    SqlCommand = new SQLiteCommand(sql, DbConnection);
                    SqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void GenerateSubCategory(Category cat)
        {
            
        }

        public static List<Category> SelectCategoryBySite(WebSites site)
        {
            List<Category> res = new List<Category>();
            string sql = $"select *  from Category where siteurl = {site.Url.Value}";
            SqlCommand = new SQLiteCommand(sql, DbConnection);
            SQLiteDataReader reader = SqlCommand.ExecuteReader();
            while (reader.Read())
            {
                res.Add(new Category
                {
                    Name = reader["Name"].ToString(),
                    Url = reader["Url"].ToString()
                });
            }

            return res;
        }

        public static void DeleteAllFromTableWhereState(string tableName, string whereState)
        {
            string sql = $"delete from {tableName} {whereState}";
            try
            {
                SqlCommand = new SQLiteCommand(sql, DbConnection);
                SqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
