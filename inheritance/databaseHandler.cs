using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace inheritance
{
    public class databaseHandler
    {
        MySqlConnection connection;
        public  databaseHandler()
        {
            string username = "root";
            string password = "";
            string host = "localhost";
            string dbName = "Trabant";
            string connectionString = $"user ={username};password={password};host={host};database={dbName}";
            connection = new MySqlConnection(connectionString);
        }

        public void readAll()
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM cars";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    int id = read.GetInt32(read.GetOrdinal("id"));
                    string model = read.GetString(read.GetOrdinal("model"));
                    string make = read.GetString(read.GetOrdinal("make"));
                    string color = read.GetString(read.GetOrdinal("color"));
                    int year = read.GetInt32(read.GetOrdinal("year"));
                    int hp = read.GetInt32(read.GetOrdinal("hp"));
                    Car oneCar = new Car();
                    oneCar.id = id;
                    oneCar.hp = hp;
                    oneCar.make = make;
                    oneCar.model = model;
                    oneCar.color = color;
                    oneCar.year = year;
                    Car.cars.Add(oneCar);


                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("siker");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Error:");
            }
        }
    }
}
