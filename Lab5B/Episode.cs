///Lab5 
///Dec. 2, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. 
/// No other person's work has been used without due acknowledgement.

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5B
{
    /// <summary>
    /// Stores data from a specific record from the Episode table
    /// </summary>
    class Episode
    {
        //StoryID is the PK for the episode table
        public String StoryID { get; }

        //Season number associated with this specific episode
        public int Series { get; }

        //Year the season was produced
        public int SeriesYear { get; }

        //Title of this episode
        public String Title { get; }


        /// <summary>
        /// Constructor for Episode class
        /// </summary>
        /// <param name="storyID"></param>
        /// <param name="series"></param>
        /// <param name="seriesyear"></param>
        /// <param name="title"></param>
        public Episode(String storyID, int series, int seriesyear, String title)
        {
            StoryID = storyID;
            Series = series;
            SeriesYear = seriesyear;
            Title = title;
        }

    }
}
