///Lab5 
///Dec. 2, 2019
/// I, Gord Bond, 000786196 certify that this material is my original work. 
/// No other person's work has been used without due acknowledgement.

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5B
{
    /// <summary>
    /// Contains the data from a record retrieved from the Doctor table 
    /// </summary>
    
    class Doctor
    {
        //Doctor ID - PK
        public int DocID { get; }

        //Actor's Name
       public String Actor { get; }

        //Age of the Doctor when took over the role
        public int Age { get; }

        //Debut episode for this doctor
        public String Debut { get; }

        //Season of debut
        public int Series { get; }

        //Picture of doctor
        public Image PicOfDoctor { get; }

        /// <summary>
        /// Constructor for Doctor class
        /// </summary>
        /// <param name="docID"></param>
        /// <param name="actor"></param>
        /// <param name="age"></param>
        /// <param name="debut"></param>
        /// <param name="series"></param>
        /// <param name="picOfDoctor"></param>
        public Doctor(int docID, String actor, int age, String debut, int series, Image picOfDoctor)
        {
            DocID = docID;
            Actor = actor;
            Age = age;
            Debut = debut;
            Series = series;
            PicOfDoctor = picOfDoctor;
        }

        

        

    }
}
