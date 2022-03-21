using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSofter
{
    public class Lecture : Section
    {
        private Lab[] linkedLabs;
        private Tutorial[] linkedTutorials;

        public Lecture(String[] info, Course theCourse)
        {
        courseCode = Convert.ToInt32(info[0]);
        course = theCourse;
        sectionType = info[2];
        sectionNumber = Convert.ToInt32(info[3]);
        semesterCode = Convert.ToInt32(info[4]);
        days = info[5];
        startTime = Convert.ToSingle(info[6]);
        endTime = Convert.ToSingle(info[7]);
        building = info[8];
        roomNumber = Convert.ToInt32(info[9]);

        instructor = info[10];
        seatsTotal = Convert.ToInt32(info[11]);
        seatsFilled = 0;
        classList = new Student[seatsTotal];
        linkedLabs = new Lab[Convert.ToInt32(info[13])];
        linkedTutorials = new Tutorial[Convert.ToInt32(info[14])];
        }//end constructor

        public Lab getLab(int index)
        {
            return linkedLabs[index];
        }//end getLab

        public Tutorial getTutorial(int index)
        {
            return linkedTutorials[index];
        }//end getTutorials

        public int getTutorialNumber()
        {
            return linkedTutorials.Length;
        }//end getTutorialNumber

        public int getLabNumber()
        {
            return linkedLabs.Length;
        }//end getLabNumber

        public void addLab(Lab newLab)
        {//link a lab section to this lecture
            newLab.addLecture(this);
            for (int i = 0; i < linkedLabs.Length; i++)
            {
                if (linkedLabs[i] == null)
                {
                    linkedLabs[i] = newLab;
                    return; //success, exit loop
                }//end if then
            }//end while loop

            //this code is only reached if no spot is found
            Lab[] tempLabList = new Lab[linkedLabs.Length + 1];
            for(int i =0; i < linkedLabs.Length; i++)
            {
                tempLabList[i] = linkedLabs[i];
            }//end for loop

            tempLabList[tempLabList.Length-1] = newLab;
            linkedLabs = tempLabList;
        }//end addLab

        public void addTutorial(Tutorial newTut)
        {//add a new tutorial section to this lecture
            newTut.addLecture(this);
            for (int i = 0; i < linkedTutorials.Length; i++)
            {
                if (linkedTutorials[i] == null)
                {
                    linkedTutorials[i] = newTut;
                    return; //success, exit loop
                }//end if then
            }//end while loop

            //this code is only reached if no spot is found
            Tutorial[] tempTutList = new Tutorial[linkedTutorials.Length + 1];
            for (int i = 0; i < linkedTutorials.Length; i++)
            {
                tempTutList[i] = linkedTutorials[i];
            }//end for loop

            tempTutList[tempTutList.Length - 1] = newTut;
            linkedTutorials= tempTutList;
        }//end addTut

        //TODO lots of stuff
        //public override Boolean enroll(Student student)
        //{
        //    if (seatsFilled < seatsTotal)
        //    {
        //        classList[seatsFilled] = student;
        //        seatsFilled++;
        //        return true;
        //    }

        //    return false;
        //}//end enroll

        public override Boolean drop(Student student)
        {//find student, remove from list

            for (int i = 0; i < seatsTotal; i++)
            {
                if (classList[i] == student)
                {
                    dropFound(i);
                    return true;
                }//end if-then
            }//end for loop

            //student not found
            return false;
        }

        protected override void dropFound(int place)
        {//for use by removeSection
            
            //remove from labs
            if (linkedLabs != null)
            {
                //linkedLabs.drop(classList[place]); TODO fix this
            }//end if-then

            //remove from tutorials
            if (linkedTutorials != null)
            {
                //linkedTutorials.drop(classList[place]); TODO fix this
            }//end if-then

            //remove from Lecture
            classList[place] = null;
            seatsFilled--;
        }//end drop part2

        public override Boolean withdraw(Student student)
        {//find student, remove from list

            drop(student);
            String cName = (sectionType + " " + sectionNumber.ToString());
            student.finalGrade(cName,"W");
            return false;
        }//end withdraw

    }
}
