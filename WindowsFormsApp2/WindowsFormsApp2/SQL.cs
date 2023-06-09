using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    internal class SQL
    {
        private static readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Pokus1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static List<Pracant> Display()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Pracant";
            SqlDataReader reader = cmd.ExecuteReader();
            List<Pracant> pracants = new List<Pracant>();
            while (reader.Read())
            {
                pracants.Add(new Pracant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4)));
            }
            reader.Close();
            conn.Close();
            return pracants;

        }
        public static void Addo(Pracant pracant)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Pracant VALUES (@Jmeno, @Prijemni, @telCislo, @rokNar)";
            cmd.Parameters.AddWithValue("Jmeno", pracant.Jmeno);
            cmd.Parameters.AddWithValue("Prijmeni", pracant.Prijmeni);
            cmd.Parameters.AddWithValue("TelCislo", pracant.TelCislo);
            cmd.Parameters.AddWithValue("RokNar", pracant.Narozeni);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Delete(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"DELETE Pracant WHERE Id={id}";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void Edit(int id,Pracant pracant)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Pracant SET Jmeno=@Jmeno, Prijmeni=@Prijmeni, telCislo=@TelCislo, rokNar=@Narozeni";
            cmd.Parameters.AddWithValue ("id", id);
            cmd.Parameters.AddWithValue("Jmeno", pracant.Jmeno);
            cmd.Parameters.AddWithValue("Prijmeni", pracant.Prijmeni);
            cmd.Parameters.AddWithValue("telCislo", pracant.TelCislo);
            cmd.Parameters.AddWithValue("rokNar", pracant.Narozeni);
            cmd.ExecuteNonQuery ();
            conn.Close();
        }

    }
}
