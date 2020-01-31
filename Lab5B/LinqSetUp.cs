///Lab5 
///Dec. 2, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. 
/// No other person's work has been used without due acknowledgement.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5B
{
    /// <summary>
    /// Manual retrieval of records to be placed in lists of objects for LINQ access
    /// </summary>
    class LinqSetUp
    { 
        //Connection to database
        public SqlConnection Connection { get; }

        /// <summary>
        /// Constructor for LinqSetUp
        /// Receives a SqlConnection as a parameter
        /// </summary>
        /// <param name="connection">connection to database for lab5b</param>
        public LinqSetUp(SqlConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// Load Doctors retrieves all doctor records
        /// </summary>
        /// <returns>List of Doctor records</returns>
        public List<Doctor> LoadDoctors()
        {

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM DOCTOR", Connection);

                List<Doctor> doctors = new List<Doctor>();
                // Create new SqlDataReader object and read data from the command.
                SqlDataReader reader = command.ExecuteReader();
                // while there is another record present
                while (reader.Read())
                {
             
                    string[] output = new string[6];
                    for (int i = 0; i < reader.FieldCount; i++)
                        output[i] += reader[i];

                    byte[] photo = (byte[])reader["Picture"];
                    MemoryStream stream = new MemoryStream(photo);
                    Image image = Image.FromStream(stream);
                    
                    //PROBLEM - The year, season and age were all mixed around:
                    //doctors.Add(new Doctor(int.Parse(output[0]), output[1], int.Parse(output[2]), output[3], int.Parse(output[4]), image));
                    //SOLUTION:
                    doctors.Add(new Doctor(int.Parse(output[0]), output[1], int.Parse(output[3]), output[4], int.Parse(output[2]), image ));
                }
                reader.Close();
                return doctors;
            }
            catch (Exception ex)
            {
                throw new Exception("Database operation failed: " + ex.Message);
            }

        }

        /// <summary>
        /// Load Companions retrieves all companion records
        /// </summary>
        /// <returns>List of companion records</returns>
        public List<Companion> LoadCompanions()
        {

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM COMPANION", Connection);

                List<Companion> companions = new List<Companion>();
                // Create new SqlDataReader object and read data from the command.
                SqlDataReader reader = command.ExecuteReader();
                // while there is another record present
                while (reader.Read())
                {
        
                    string[] output = new string[4];
                    for (int i = 0; i < reader.FieldCount; i++)
                        output[i] += reader[i];

                    companions.Add(new Companion(output[0], output[1], int.Parse(output[2]), output[3]));
                }
                reader.Close();
                return companions;
            }
            catch (Exception ex)
            {
                throw new Exception("Database operation failed: " + ex.Message);
            }

        }

        /// <summary>
        /// LoadEpisodes - Retrieves all Episode records
        /// </summary>
        /// <returns>List of Episode records</returns>
        public List<Episode> LoadEpisodes()
        {

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM EPISODE", Connection);

                List<Episode> episodes = new List<Episode>();
                // Create new SqlDataReader object and read data from the command.
                SqlDataReader reader = command.ExecuteReader();
                // while there is another record present
                while (reader.Read())
                {
                    // write the data on to the screen
                    string[] output = new string[4];
                    for (int i = 0; i < reader.FieldCount; i++)
                        output[i] += reader[i];

                    episodes.Add(new Episode(output[0], int.Parse(output[1]), int.Parse(output[2]), output[3]));
                }
                reader.Close();
                return episodes;
            }
            catch (Exception ex)
            {
                throw new Exception("Database operation failed: " + ex.Message);
            }

        }






    }
}
