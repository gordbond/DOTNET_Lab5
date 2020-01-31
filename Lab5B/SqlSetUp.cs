///Lab5 
///Dec. 2, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. 
/// No other person's work has been used without due acknowledgement.

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5B
{
    class SqlSetUp
    {
        //Connection to database
        public SqlConnection Connection { get; }
        /// <summary>
        /// Constructor for SqlSetUp
        /// Receives a SqlConnection as a parameter
        /// </summary>
        /// <param name="connection">connection to database for lab5b</param>
        public SqlSetUp(SqlConnection connection) {
            Connection = connection;
        }

        /// <summary>
        /// Method for querying the database and retrieving 
        /// data to fill doctor information panel
        /// Retrieves for specific doctor:
        ///     Actor
        ///     Age
        ///     Series
        ///     Series Year
        ///     Title of first episode
        /// </summary>
        /// <param name="docID">docID is the Primary key for the record</param>
        /// <returns></returns>
        public String[] getDoctorInfo(int docID) {
            
            SqlCommand command = new SqlCommand($"SELECT D.ACTOR, D.AGE, D.SERIES, E.SEASONYEAR, E.TITLE FROM DOCTOR D JOIN EPISODE E ON D.DEBUT = E.STORYID WHERE D.DOCTORID = {docID}", Connection);

            SqlDataReader reader = command.ExecuteReader();
            string[] output = new string[5];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    output[i] += reader[i];
            }

            Console.WriteLine("Database Select Doctor Info Success");
            reader.Close();
            return output;
        }

        /// <summary>
        /// Method for querying the database and retrieving 
        /// data of all companions for a specific doctor
        /// Data retrieved for each companion:
        ///     Name
        ///     Actor 
        ///     Title of Episode
        ///     Series year   
        /// </summary>
        /// <param name="docID"></param>
        /// <returns></returns>
        public List<String[]> getCompanion(int docID) {
            SqlCommand command = new SqlCommand($"SELECT C.NAME, C.ACTOR, E.TITLE, E.SEASONYEAR FROM DOCTOR D JOIN COMPANION C ON D.DOCTORID = C.DOCTORID JOIN EPISODE E ON C.STORYID = E.STORYID WHERE D.DOCTORID = {docID} ORDER BY E.SEASONYEAR ASC", Connection);

            SqlDataReader reader = command.ExecuteReader();
            List<string[]> formattedOutput = new List<string[]>();
            
            while (reader.Read())
            {
                string[] output = new string[4];
                for (int i = 0; i < reader.FieldCount; i++)
                    output[i] += reader[i];
                formattedOutput.Add(output);

            }
            
            Console.WriteLine("Database Select Companion Info Success");
            reader.Close();
            return formattedOutput;
        }

        /// <summary>
        /// Method to retrieve picture for specific doctor
        /// </summary>
        /// <param name="docID">specific doctor to retrieve photo for</param>
        /// <returns></returns>
        public MemoryStream getPicture(int docID)
        {
            SqlCommand command = new SqlCommand($"SELECT PICTURE FROM DOCTOR WHERE DOCTORID = {docID}", Connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["PICTURE"]);
            return ms;
        }



    }
}
