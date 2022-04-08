using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Reflection;
namespace UtahTraffix.Models
{
    public class EFCrashRepository : ICrashRepository
    { 
        private CrashDbContext _context { get; set; }

        public EFCrashRepository(CrashDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Crash> Crashes => _context.Crashes;

        public MySqlConnection conn = new MySqlConnection("server=database-1.cpgqljcynzru.us-east-1.rds.amazonaws.com;port=3306;database=traffix;user=root;password=glAdmin1919");

        public Crash getCrash (int id)
        {
            return Crashes.Single(x => x.CRASH_ID == id);
        }


        public void SaveCrash(Crash c)
        {
            _context.SaveChanges();
        }
        public void CreateCrash(Crash c)
        {
            _context.Add(c);
            _context.SaveChanges();
        }
        public void DeleteCrash(Crash c)
        {
            _context.Remove(c);
            _context.SaveChanges();
        }

        public List<Crash> GetCrashesSimple(int page, int crashesPerPage)
        {
            List<Crash> data = new List<Crash>();

            try
            {
                conn.Open();
            }
            catch
            {
                Console.WriteLine("Problem connecting to database file.");
            }

            MySqlCommand cmd = conn.CreateCommand();

            int offset = ((page - 1) * crashesPerPage);

            cmd.CommandText = "SELECT * FROM Crashes LIMIT @pageSize OFFSET @pageOffset";
            cmd.Parameters.AddWithValue("@pageSize", crashesPerPage);
            cmd.Parameters.AddWithValue("@pageOffset", offset);

            MySqlDataReader sqlDR = cmd.ExecuteReader();

            Crash obj = default(Crash);

            while (sqlDR.Read())
            {
                obj = Activator.CreateInstance<Crash>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(sqlDR[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, sqlDR[prop.Name], null);
                    }
                }
                data.Add(obj);
            }

            conn.Close();

            return data;
        }

        public List<Crash> GetCrashesFiltered(int page, int crashesPerPage, string searchString, string filterColumn) //This needs to be edited... I deleted a lot of stuff out of this function
        {

            List<Crash> data = new List<Crash>();

            try
            {
                conn.Open();
            }
            catch
            {
                Console.WriteLine("Problem connecting to database file.");
            }

            MySqlCommand cmd = conn.CreateCommand();

            int offset = ((page - 1) * crashesPerPage);

            string searchNew = "'%" + searchString + "%'";

            cmd.CommandText = "SELECT * FROM Crashes WHERE " + filterColumn + " LIKE " + searchNew + " LIMIT @pageSize OFFSET @pageOffset";
            //cmd.Parameters.AddWithValue("@filterCol", filterColumn);
            //cmd.Parameters.AddWithValue("@searchStr", searchNew);
            cmd.Parameters.AddWithValue("@pageSize", crashesPerPage);
            cmd.Parameters.AddWithValue("@pageOffset", offset);

            MySqlDataReader sqlDR = cmd.ExecuteReader();

            Crash obj = default(Crash);

            while (sqlDR.Read())
            {
                obj = Activator.CreateInstance<Crash>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(sqlDR[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, sqlDR[prop.Name], null);
                    }
                }
                data.Add(obj);
            }

            conn.Close();

            return data;
        }
    }
}