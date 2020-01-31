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
    /// Stores data from a specific record in the Companion table
    /// </summary>
    /// 

    class Companion
    {

        //Name of the companion character 
        public String Name { get; }

        //Name of the actor portraying the companion
        public String CompanionActor { get; }

        //List of IDs for Doctors associated with this companion
        public int DocID { get; }

        //List of Story IDs associated with this companion
        public String StoryID { get; }


        /// <summary>
        /// Constructor for Companion class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="actor"></param>
        /// <param name="docIDs"></param>
        /// <param name="storyIDs"></param>
        public Companion(String name, String actor, int docIDs, String storyIDs)
        {
            Name = name;
            CompanionActor = actor;
            DocID = docIDs;
            StoryID = storyIDs;
        }


    }
}
