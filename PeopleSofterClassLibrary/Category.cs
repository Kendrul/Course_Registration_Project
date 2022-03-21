using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSofter
{
    public class Category
    {//course Categories
        private int numOfCourse;
        private Course[] courseList;
        private String categoryName; //ex: CPSC
        private String categoryNameLong; //ex: Computer Science
        private String faculty; //ex: Faculty of Science

        public Category(String[] info)
        {
            categoryName = info[0];
            categoryNameLong = info[1];
            faculty = info[2];
            numOfCourse = 0;
            courseList = new Course[numOfCourse];
        }//end constructor

        //TODO lots of stuff
        public String getName()
        {
            return categoryName;
        }//end getName

        public String getNameLong()
        {
            return categoryNameLong;
        }//end getNameLong

        public Course getCourse(int i)
        {
            return courseList[i];
        }//get course index

        public Course[] getCourseList()
        {
            return courseList;
        }//end get course list

        public void addCourse(Course newCourse)
        {//adds a new course to the list
            Course[] tmpList = new Course[numOfCourse + 1];

            for (int i = 0; i < numOfCourse; i++)
            {
                tmpList[i] = courseList[i];
            }//end for loop
            tmpList[numOfCourse] = newCourse;
            numOfCourse++;
            courseList = tmpList;
        }//end addCourse
    }
}
