using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace PeopleSofter
{
    public class DataLoader
    {//for loading the data files to create the course/student etc objects

        //static data for now, to be made dynamic later
        private const int num_of_course = 2;
        private const int num_of_section = 10;
        private const int num_of_category = 5;

        private const String catFile = "DataFiles\\CategoryLog.txt";
        private const String courseFile = "DataFiles\\CourseLog.txt"; //the file that contains the course/section info
        private const String sectionFile = "DataFiles\\SectionLog.txt"; //this file contains the section info
        private const String programFile = ""; //file that contains the program info
        private const String studentFile = ""; //file that contains the student info
        private StreamReader sr;

        public Course[] courseList;
        public Category[] categoryList;
        public ArrayList programList;
        public ArrayList studentList;


        public DataLoader()
        {
            //testLoad();
            categoryList = new Category[num_of_category];
            loadCategory();
            loadCourse();
            loadSection();
            loadProgram();
            loadStudent();
        }

        private void loadCategory()
        {
            try
            {   //init some variables
                sr = new StreamReader(catFile);
                string line;
                string[] values;
                Category newCat;
                int i = 0;

                sr.ReadLine(); //discard first line

                //read in the data
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    values = line.Split('\t');
                    newCat = new Category(values);
                    categoryList[i] = newCat;
                    i++;
                }//end while loop   

                sr.Close();
            }//end of try
            catch (Exception e)
            {
                Console.WriteLine(e);
                //TODO change this
                if (sr != null)
                {
                    sr.Close();
                }
            }//end of catch block exception
        }//end loadCategory

        //private void testLoad()
        //{//for testing purposes
        //    courseList = new Course[1];
        //    Console.Write("Beginning testLoad..... ");
        //    String line = "1001203,CPSC,203,Introduction to Problem Solving using Application Software,1,1,2,,,,,,,";
        //    String[] values = line.Split(',');

            
        //    if (values.Length == 14)
        //    {
        //        Course newCourse = new Course(values);
        //        courseList[0] = newCourse;
        //        Console.WriteLine("Done.");
        //    }
        //    else Console.WriteLine("Failed.");
        //}

        public void loadCourse()
        {//loads the courses from a file
            try
            {   //init some variables
                sr = new StreamReader(courseFile);
                string line;
                string[] values;
                courseList = new Course[num_of_course]; //TODO more dynamic
                Course newCourse;
                int i = 0;

                sr.ReadLine(); //discard first line

                //read in the data
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    values = line.Split('\t');
                    newCourse = new Course(values); //create the course object
                    courseList[i]= newCourse; //add to the list
                    findCategory(values[1]).addCourse(newCourse); //pass category code
                    i++;
                }//end while loop   

                sr.Close();
            }//end of try
            catch (Exception e)
            {
                Console.WriteLine(e);
                //TODO change this
                if (sr != null)
                {
                    sr.Close();
                }
            }//end of catch block exception
        }//end loadCourse

        private Category findCategory(string cat)
        {//finds and returns the category object
            for (int i = 0; i < categoryList.Length; i++)
            {
                if (categoryList[i].getName() == cat)
                {
                    return categoryList[i];
                }//end 
            }//end for loop

            return null; //TODO should really throw exception
        }//end findCategory

        public void loadSection()
        {//loads lecture/lab/tutorial sections from a file
            Lecture newSection = null;
            int i = 0;
            Course course = null;
            
            try
            {   //init some variables
                sr = new StreamReader(sectionFile);
                string line;
                string[] values;
                
                Tutorial newTut;
                Lab newLab;             
                int j = 0;
                sr.ReadLine(); //discard first line

                ////read in the data
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    values = line.Split('\t');
                    int section_type_spot = 2;

                    if (values[section_type_spot] == "Lecture")
                    {
                        Console.WriteLine("Adding a Lecture: " + values[1] + " " + values[3]);
                        course = findCourse(Convert.ToInt32(values[0]));
                        newSection = new Lecture(values,course);

                        //add the lecture section to the list
                        course.addLec(newSection);
                    }//end if-then
                    else if (values[section_type_spot] == "Lab") 
                    {
                        Console.WriteLine("Adding a Lab " + values[1] + " " + values[3]);
                            newLab = new Lab(values,newSection);
                            newSection.addLab(newLab);   
                    }//end else-if-then
                    else if (values[section_type_spot] == "Tutorial")
                    {
                        Console.WriteLine("Adding a Tutorial " + values[1] + " " + values[3]);
                        newTut = new Tutorial(values,newSection);
                        newSection.addTutorial(newTut);
                    }//end else-else-if-then
                    else
                    {
                        //ERROR
                    }//end else-else-if-else
                    i++;
                }//end while loop   

                sr.Close();
            }//end of try
            catch (EndOfStreamException ese)
            {
                if (newSection != null)
                {
                    course.addLec(newSection);
                }//end if-then                    

                if (sr != null)
                {
                    sr.Close();
                }  
             }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //TODO change this
                if (sr != null)
                {
                    sr.Close();
                }
            }//end of catch block exception
        }//end loadSection

        private Course findCourse(int code)
        {
            for (int i = 0; i < courseList.Length; i++)
            {
                if (courseList[i].getCode() == code)
                {
                    return courseList[i]; //success
                }//end if-then
            }
            return null; //TODO should really cause an error
        }//end findCourse

        public void loadProgram()
        {
        }

        public void loadStudent()
        {
        }

    }
}
