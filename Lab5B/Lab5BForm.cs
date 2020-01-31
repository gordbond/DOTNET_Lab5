///Lab5 
///Dec. 2, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. 
/// No other person's work has been used without due acknowledgement.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab5B
{
    public partial class Lab5BForm : Form
    {
        //Connection for SQL
        public SqlConnection Connection { get; }
        //String to connect to Lab5 database
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=COMP10204_Lab5;
        Integrated Security=True";
        //List of Doctor objects from database
        List<Doctor> Doctors = new List<Doctor>();
        //List of Companion objects from database
        List<Companion> Companions = new List<Companion>();
        //List of Episode objects from database
        List<Episode> Episodes = new List<Episode>();


        /// <summary>
        /// Constructor for Lab5B Form
        /// Creates connection with database for lab5
        /// Reports connection status
        /// populates doctorIDComboBox
        /// Sets intitial doctorIDComboBox index
        /// Sets lists for use by LINQ
        /// </summary>
        public Lab5BForm()
        {
            InitializeComponent();
            //Creating a connection to the database
            //reports the status in label at the bottom of form
            try
            {
                Connection = new SqlConnection();
                Connection.ConnectionString = connectionString;
                Connection.Open();
                statusLabel.Text = "Connected to Database Successfully";
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Database Connection failed - check Connection String : " +
                ex.Message;
            }

            //-----------------------------------COMBO BOX POPULATE------------------------------//

            //Populate Doctor Id Combo Box
            doctorIDComboBox.Items.Clear();
            try
            {
                SqlCommand command = new SqlCommand("SELECT DOCTORID FROM DOCTOR", Connection);


                // Create new SqlDataReader object and read data from the command.
                SqlDataReader reader = command.ExecuteReader();
                
                // while there is another record present
                while (reader.Read())
                {
                    // write the data on to the screen
                    string output = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                        output += reader[i];
                    doctorIDComboBox.Items.Add(output);
                }
                statusLabel.Text = "Database Select Success";
                reader.Close();
            }
            catch (Exception ex)
            {
                statusLabel.Text = "Database operation failed: " + ex.Message;
            }
            //Initial index is the first doctor
            doctorIDComboBox.SelectedIndex = 0;

            //-----------------------------------FILL LISTS FOR LINQ------------------------------//

            //Fill Doctor, Companion and Episode Lists for LINQ use
            LinqSetUp linqQuery = new LinqSetUp(Connection);
            foreach (Doctor d in linqQuery.LoadDoctors())
                Doctors.Add(d);
            foreach (Companion c in linqQuery.LoadCompanions())
                Companions.Add(c);
            foreach (Episode e in linqQuery.LoadEpisodes())
                Episodes.Add(e);
        }



        /// <summary>
        /// Event handler for when Doctor ID combo box changes index
        /// Calls select doctor - fills all form text boxes and list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void DoctorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectDoctor();    
        }

        /// <summary>
        /// Event handler for Exit strip menu item
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Select Doctor method fills all form text boxes and list box
        /// Specifically:
        ///     Checks if user wants to use SQL or LINQ (radio buttons)
        ///     Calls either SqlSetUp or LinqSetUp
        ///     Sets text boxes and list box with data retrieved from SqlSetUp or LinqSetUp
        /// </summary>
        private void SelectDoctor() {
            SqlSetUp sqlQuery = new SqlSetUp(Connection);
            int currentDocID = int.Parse(doctorIDComboBox.SelectedItem.ToString());
            if (sqlRadioButton.Checked)
            {
                //Get Doctor info
                String[] DoctorInfo = sqlQuery.getDoctorInfo(currentDocID);
                playedByTextBox.Text = DoctorInfo[0];
                ageTextBox.Text = DoctorInfo[1];
                seriesTextBox.Text = DoctorInfo[2];
                yearTextBox.Text = DoctorInfo[3];
                firstEpTextBox.Text = DoctorInfo[4];
                //Get Companion info
                List<String[]> CompanionInfo = sqlQuery.getCompanion(currentDocID);
                companionListBox.Items.Clear();
                foreach (String[] companion in CompanionInfo)
                {
                    companionListBox.Items.Add($"{companion[0]} ({companion[1]})");
                    companionListBox.Items.Add($"'{companion[2]}' ({companion[3]})");
                    companionListBox.Items.Add('\n');
                }
                //Get Picture
                MemoryStream ms = sqlQuery.getPicture(currentDocID);
                doctorPictureBox.Image = new Bitmap(ms);
            }
            else
            {
                var doctorInfo =
                from doctor in Doctors
                join episode in Episodes on doctor.Debut equals episode.StoryID

                where doctor.DocID == currentDocID
                select new { doctor.Actor, doctor.Age, doctor.Series, doctor.PicOfDoctor, episode.SeriesYear, episode.Title };

                foreach (var item in doctorInfo)
                {
                    playedByTextBox.Text = item.Actor;
                    ageTextBox.Text = $"{item.Age}";
                    doctorPictureBox.Image = item.PicOfDoctor;
                    seriesTextBox.Text = $"{item.Series}";
                    firstEpTextBox.Text = $"{item.Title}";
                    yearTextBox.Text = $"{item.SeriesYear}";
                }

                var companionInfo =
                from doctor in Doctors
                join companion in Companions on doctor.DocID equals companion.DocID
                join episode in Episodes on companion.StoryID equals episode.StoryID
                where doctor.DocID == currentDocID
                orderby episode.SeriesYear ascending
                select new { episode.SeriesYear, episode.Title, companion.Name, companion.CompanionActor };


                companionListBox.Items.Clear();
                foreach (var item in companionInfo)
                {
                    companionListBox.Items.Add($"{item.Name} ({item.CompanionActor})");
                    companionListBox.Items.Add($"'{item.Title}' ({item.SeriesYear})");
                    companionListBox.Items.Add('\n');
                    
                }
            }

        }
       
    }
}
