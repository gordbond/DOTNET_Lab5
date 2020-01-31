///Lab5 
///Dec. 2, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. 
/// No other person's work has been used without due acknowledgement.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5A
{
    /// <summary>
    /// Lab5AForm is the main form for the faucet and bucket app
    /// Handles the controls and view 
    /// </summary>
    public partial class Lab5AForm : Form
    {
        //Drawing object - model for all elements being drawn
        Drawing drawing;
        //Variable which determines the speed at which the water fills the bucket
        int waterHeightIncrement;
        //previous track bar value to determine which if value increasing or decreasing
        int previousTrackBarValue;

        

        /// <summary>
        /// Constructor of Lab5A Form
        /// Creates a new drawing object
        /// sets initial values for waterHeightIncrement and previousTrackBarValue
        /// </summary>
        public Lab5AForm()
        {
            InitializeComponent();
            drawing = new Drawing(Color.Aqua);
            waterHeightIncrement = 0;
            previousTrackBarValue = 0;
            
        }

        /// <summary>
        /// Event handler for when the Flow trackbar is moved
        /// Increasing trackbar value causes water flow to speed up and 
        /// decreasing trackbar value causes water flow to slow down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlowTrackBar_Scroll(object sender, EventArgs e)
        {
            Graphics g = drawingPanel.CreateGraphics();
            if (!drawing.Full)
            {
                if (flowTrackBar.Value > 0)
                {
                    bucketTimer.Enabled = true;
                    //If track bar moved forward
                    if (flowTrackBar.Value > previousTrackBarValue)
                    {
                        bucketTimer.Interval = (1000 - (50 * flowTrackBar.Value));
                        previousTrackBarValue = flowTrackBar.Value;
                    }
                    //If track bar moved backwards
                    else
                    {
                        bucketTimer.Interval = (1000 + (50 * flowTrackBar.Value));
                        previousTrackBarValue = flowTrackBar.Value;
                    }
                    drawing.DrawWaterFlow(g, waterHeightIncrement);
                }
                //If trackbar set to zero (initial position) turn off water flow
                else
                {
                    drawing.DrawWaterFlow(g, Color.Black, waterHeightIncrement);
                    bucketTimer.Enabled = false;
                    bucketTimer.Interval = 1000;
                    previousTrackBarValue = 0;
                }
            }
            //If bucket full - reset bucket upon moving track bar
            else {
                drawing.Reset(g);
                waterHeightIncrement = 0;
                drawing = new Drawing(Color.Aqua);
            }
        }



        /// <summary>
        /// Create the bucket drawing on the panel after 
        /// form is created
        /// </summary>
        /// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Lab5AForm_Load(object sender, PaintEventArgs e)
        //{
        //    Graphics g = drawingPanel.CreateGraphics();
        //    drawing.DrawBucket(g);

        //}

        private void Lab5AForm_Load(object sender, EventArgs e)
        {
            Graphics g = drawingPanel.CreateGraphics();
            drawing.DrawBucket(g);
        }

        /// <summary>
        /// Event Handler for each tick of the timer.
        /// Draws a row of "water" on each tick.
        /// Resets flow track bar to initial position and turns off
        /// water from faucet once bucket is full
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BucketTimer_Tick(object sender, EventArgs e)
        {
            Graphics g = drawingPanel.CreateGraphics();
            //Draw more water
            if (!drawing.Full)
            {
                waterHeightIncrement++;
                drawing.DrawWaterInBucket(g, waterHeightIncrement);
            }
            //reset track bar and turn off water flow
            else {
                flowTrackBar.Value = 0;
                drawing.DrawWaterFlow(g, Color.Black, waterHeightIncrement-1);
            }
        }

        /// <summary>
        /// Event handler for colour picker button
        /// Sets flowing water and water in bucket to colour chosen from
        /// colour picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColourButton_Click(object sender, EventArgs e)
        {
            Graphics g = drawingPanel.CreateGraphics();
            WaterColorDialog.ShowDialog();
            drawing = new Drawing(WaterColorDialog.Color);
            //If flowing changing colour of flowing water from faucet
            if(flowTrackBar.Value > 0)
                drawing.DrawWaterFlow(g, WaterColorDialog.Color, waterHeightIncrement );
        }

        /// <summary>
        /// Event handler for close button
        /// Closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}

