using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSofter
{
    public class Lab : Section
    {
        private Lecture linkedLecture;
        //TODO lots of stuff

        public Lab(String[] info, Lecture theLecture)
        {
            courseCode = Convert.ToInt32(info[0]);
            course = theLecture.getCourse();
            sectionType = info[2];
            sectionNumber = Convert.ToInt32(info[3]);
            semesterCode = Convert.ToInt32(info[4]);
            days = info[5];
            //startTime = Convert.ToSingle(info[6]);
            //endTime = Convert.ToSingle(info[7]);
            building = info[8];
            //roomNumber = Convert.ToInt32(info[9]);

            instructor = info[10];
            seatsTotal = Convert.ToInt32(info[11]);
            seatsFilled = 0;
            classList = new Student[seatsTotal];
            addLecture(theLecture);
        }//end constructor

        public void addLecture(Lecture theLecture)
        {
            linkedLecture = theLecture;
        }//end addLecture
    }
}
