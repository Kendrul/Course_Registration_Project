using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSofter
{
    public class Course
    { //contains info on the course, and any sections offered
        //attributes
        private int code;
        private String category;
        private int number;
        private String name;
        private String description;
        private String notes;

        //requirement stuff
        //most of these could go back arrays
        private String coReq;
        private String preReq;
        private String antiReq;
        private Boolean consentReq;
        private String programReq;
        private String specialReq;

        //offered sections
        private Lecture[] lectureSections;
        private Tutorial[] tutorialSections;
        private Lab[] labSections;

        //constructors TODO
        public Course()
        {
        }//end constructor

        public Course(String[] info)
        {
            code = Convert.ToInt32(info[0]);
            category = info[1];
            number = Convert.ToInt32(info[2]);
            name = info[3];
            lectureSections = new Lecture[Convert.ToInt32(info[4])];
            //not used
            //labSections = new Lab[Convert.ToInt32(info[5])];
            //tutorialSections = new Tutorial[Convert.ToInt32(info[6])];

            coReq = info[7];
            antiReq = info[8];
            preReq = info[9];

            //this part needs to be reviewed
            //coReq = new String[Convert.ToInt32(info[7])];
            //antiReq = new String[Convert.ToInt32(info[8])];
            //preReq = new String[Convert.ToInt32(info[9])];

            if (info[10] == "yes")
            {
                consentReq = true;
            }
            else
            {
                consentReq = false;
            }

            //specialReq = new String[Convert.ToInt32(info[11])];
            specialReq = info[11];
            notes = info[12];
            description = info[13];

        }//end constructor w/ input array

        //getters TODO
        public int getCode()
        {
            return code;
        }

        public String getCategory()
        {
            return category;
        }//end get category

        public int getNumber()
        {
            return number;
        }//end get number

        public String getName()
        {
            return name;
        }//end get Name

        public String getDesc()
        {
            return description;
        }

        public String getNotes()
        {
            return notes;
        }//end getNotes

        public int getLectureNum()
        {
            return lectureSections.Length;
        }//end lecNum

        public int getTutorialNum()
        {
            return tutorialSections.Length;
        }//end lecNum

        public int getLabNum()
        {
            return labSections.Length;
        }//end lecNum

        public Lecture getLecture(int index)
        {
            return lectureSections[index];
        }//end getLecture

        //setters TODO

        //other methods? TODO implement the following methods
        public void addLec(Lecture newLec)
        {
            for (int i = 0; i < lectureSections.Length; i++)
            {
                if (lectureSections[i] == null)
                {
                    lectureSections[i] = newLec;
                    return; //success, exit method
                }//end if-then
            }//end for loop

            //this code only executes if the lecture list is full
            Lecture[] tmpList = new Lecture[lectureSections.Length + 1];
            for (int i = 0; i < lectureSections.Length; i++)
            {
                tmpList[i] = lectureSections[i];
            }//end for loop
            tmpList[lectureSections.Length] = newLec;
            lectureSections = tmpList;
        }//end addLec

        public void addTut(Tutorial newTut)
        {
        }//addTut

        public void addLab(Lab newLab)
        {
        }//add Lab

    }
}
