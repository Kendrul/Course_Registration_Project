using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleSofter
{
    /// <summary>
    /// Interaction logic for CourseBlock.xaml
    /// </summary>
    public partial class CourseBlock : UserControl
    {
        private Course theCourse;
        private MainWindow theWindow;

        public CourseBlock()
        {
            InitializeComponent();

            //for testing purposes
            //this.cbCourseName.Text = "CPSC 201";
            //this.cbNameLong.Text = "Introduction to Problem Solving using Application Software";
        }

        public CourseBlock(Course newCourse, MainWindow window)
        {
            InitializeComponent();
            theWindow = window;
            if (newCourse != null)
            {
                theCourse = newCourse;
                this.cbCourseName.Text = (theCourse.getCategory() + " " + theCourse.getNumber().ToString());
                this.cbNameLong.Text = theCourse.getName();
            }
        }

        public CourseBlock(String category, int number, String name)
        {
            this.cbCourseName.Text = (category + " " + number.ToString());
            this.cbNameLong.Text = name;
        }

        private void cbClick(object sender, RoutedEventArgs e)
        {
            int check = theCourse.getLectureNum();
            //Console.WriteLine("Checking number of Lectures... " + check);
            theWindow.courseScroll.Visibility = System.Windows.Visibility.Collapsed; //hide course scroller

            if (check > 1)
            {
                //multiple lectures, create and load lecture blocks
                theWindow.scrollCLecStack.Children.Clear(); //clear the scroller
                theWindow.cLecScroll.Visibility = System.Windows.Visibility.Visible;
                createLectureBlocks();
            }//load lecture blocks
            else if (check == 1)
            {
                //go straight to course info
                theWindow.fillInfo(theCourse, theCourse.getLecture(0));
            }//end if-then-else
            else
            {
                //0 or negative lecture sections, ERROR
            }//end if-else-else
        }//end cbClick

        private void createLectureBlocks()
        {
            //Console.WriteLine("Creating Lecture Blocks!!");
            try
            {//create and show the lectureBlocks
                for (int i = 0; i < theCourse.getLectureNum(); i++) //TODO more dynamic
                {
                    LectureBlock newBlock = new LectureBlock(theCourse.getLecture(i), theWindow);
                    theWindow.scrollCLecStack.Children.Add(newBlock);
                    newBlock.Visibility = System.Windows.Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Found in Main Window: Lecture Block Creation");
                Console.WriteLine(ex);
            }
        }//end createLectureBlocks
    }
}
