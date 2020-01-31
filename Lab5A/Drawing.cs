///Lab5 
///Dec. 2, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. 
/// No other person's work has been used without due acknowledgement.


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5A
{
    /// <summary>
    /// Drawing Class responsible for the modeling of
    /// the elements being drawn on the panel
    /// 
    /// </summary>
    class Drawing
    {

        // Initial x position for the bucket drawing
        public int X = 40;
        // Initial y position for the bucket drawing
        public int Y = 70;
        // Width for the bucket drawing
        public int W = 300;
        // Height for the bucket drawing
        public int H = 230;
        //Colour for the bucket
        public Color LineColor = Color.White;
        //Colour for the "water" 
        public Color BrushColor;
        //Boolean flag to determine whether bucket is full or not
        public bool Full { get; private set; } = false;

        /// <summary>
        /// Constructor for Drawing class
        /// Receives a Color parameter which is used 
        /// as the "water" colour
        /// </summary>
        /// <param name="brushColor">Color for the "water"</param>
        public Drawing(Color brushColor) {
            BrushColor = brushColor;
        }

        /// <summary>
        /// Draw Bucket method 
        /// Draws the intial bucket drawing 
        /// </summary>
        /// <param name="g"></param>
        public void DrawBucket(Graphics g)
        {
            Pen p = new Pen(LineColor);
            g.DrawRectangle(p, X, Y, W, H);
            Pen p2 = new Pen(Color.Black);
            g.DrawRectangle(p2, X, Y, W,Y);
        }

        /// <summary>
        /// DrawWaterFlow draws the water flowing from the faucet
        /// </summary>
        /// <param name="g">The drawing surface</param>
        /// <param name="waterHeight">The number increments of water added to the bucket</param>
        public void DrawWaterFlow(Graphics g, int waterHeight)
        {
            Brush b = new SolidBrush(BrushColor);
            //Draws the water from faucet up to the height of the water in the bucket
            //water height increment * the height of each rectangle of water
            g.FillRectangle(b, 100, 70, 20, H - (waterHeight * 5));
        }

        /// <summary>
        /// Overload method for DrawWaterFlow
        /// Accepts a colour which sets the colour
        /// of the flowing water
        /// </summary>
        /// <param name="g">Drawing surface</param>
        /// <param name="waterColor">Color of the water</param>
        /// <param name="waterHeight">The number increments of water added to the bucket</param>
        public void DrawWaterFlow(Graphics g, Color waterColor, int waterHeight) {
            Brush b = new SolidBrush(waterColor);
            //Draws the water from faucet up to the height of the water in the bucket
            //water height increment * the height of each rectangle of water
            g.FillRectangle(b, 100, 70, 20, H-(waterHeight * 5));
        }

        /// <summary>
        /// Draws the water filling the bucket
        /// </summary>
        /// <param name="g">Drawing surface</param>
        /// <param name="waterHeight">The number increments of water added to the bucket</param>
        public void DrawWaterInBucket(Graphics g, int waterHeight)
        {
            //if less than 30 increments - not full
            if (waterHeight < 30)
            {
                Brush b = new SolidBrush(BrushColor);
                g.FillRectangle(b, X+1, (Y + H) - (waterHeight * 5), W-1, 5);
            }
            //F
            else
                Full = true; 
        }
        /// <summary>
        /// Method to reset the bucket of water to empty
        /// Draws a black rectangle over water
        /// </summary>
        /// <param name="g"></param>
        public void Reset(Graphics g) {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, X+1, Y, W-1, H);
        }

    }
}
