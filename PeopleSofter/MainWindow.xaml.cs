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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        
        //color constants
        const string bigBlue = "#FF0339FF";
        const string bigRed = "#FFFF0000";
        const string bigGrey = "";
        const string smallGrey = "#FFCDCDCD"; //current selection
        const string littleRed = "#FFFE5858"; //Not available
        public 
            const string littleBlue = "#FFA7C0DC"; //Available
        public DataLoader dl;
        
        
        public MainWindow()
        {
            InitializeComponent();
            hideStuffInit();
            dl = new DataLoader(); //load data into the program
            //testLoadCourseBlock();
            //testLoadSectionBlock();
            //testLoadCategoryBlock();
        }

        private void testLoadCourseBlock()
        {
            cLecScroll.Visibility = System.Windows.Visibility.Collapsed;
            catScroll.Visibility = System.Windows.Visibility.Collapsed;
            courseScroll.Visibility = System.Windows.Visibility.Visible;

                if (dl.courseList != null)
                {
                    try
                    {
                        for (int i = 0; i < 3; i++) //TODO more dynamic
                        {
                        CourseBlock testBlock = new CourseBlock(dl.courseList[i],this);
                        this.scrollCourseStack.Children.Add(testBlock);
                        testBlock.Visibility = System.Windows.Visibility.Visible;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error Found in Main Window: Test Block Creation");
                        Console.WriteLine(e);
                    }
                }//end if-then
        }//end testLoadCourseBlock

        private void testLoadSectionBlock()
        {
            cLecScroll.Visibility = System.Windows.Visibility.Visible;
            catScroll.Visibility = System.Windows.Visibility.Collapsed;
            courseScroll.Visibility = System.Windows.Visibility.Collapsed;

            if (dl.courseList[0].getLectureNum() != 0)
            {
                try
                {
                    for (int i = 0; i < 2; i++) //TODO more dynamic
                    {
                        LectureBlock testBlock = new LectureBlock(dl.courseList[0].getLecture(i), this);
                        this.scrollCLecStack.Children.Add(testBlock);
                        testBlock.Visibility = System.Windows.Visibility.Visible;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Found in Main Window: Test Block Creation");
                    Console.WriteLine(e);
                }
            }//end if-then
        }//end testLoadSectionBlock

        private void testLoadCategoryBlock()
        {
            cLecScroll.Visibility = System.Windows.Visibility.Collapsed;
            catScroll.Visibility = System.Windows.Visibility.Visible;
            courseScroll.Visibility = System.Windows.Visibility.Collapsed;

            if (dl.categoryList != null)
            {
                try
                {
                    for (int i = 0; i < 6; i++) //TODO more dynamic
                    {
                        CategoryBlock testBlock = new CategoryBlock(dl.categoryList[i],this);
                        this.scrollCatStack.Children.Add(testBlock);
                        testBlock.Visibility = System.Windows.Visibility.Visible;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Found in Main Window: Test Block Creation");
                    Console.WriteLine(e);
                }
            }//end if-then
        }//end testLoadSectionBlock

        private void hideStuffInit()
        {
            //hide the "pop-ups"
            dropUp.Visibility = System.Windows.Visibility.Collapsed;
            withUp.Visibility = System.Windows.Visibility.Collapsed;
            swapUp.Visibility = System.Windows.Visibility.Collapsed;
            editUp.Visibility = System.Windows.Visibility.Collapsed;
            hideInfo();
            cLecScroll.Visibility = System.Windows.Visibility.Collapsed;
            catScroll.Visibility = System.Windows.Visibility.Collapsed;
            courseScroll.Visibility = System.Windows.Visibility.Collapsed;
            //catSlider.Visibility = System.Windows.Visibility.Hidden;    
            searchPanelGrid.Visibility = System.Windows.Visibility.Collapsed;
            //labBorder.Visibility = System.Windows.Visibility.Collapsed;
            //infoLabLabel.Visibility = System.Windows.Visibility.Collapsed;
            //tutBorder.Visibility = System.Windows.Visibility.Collapsed;
            //infoTutLabel.Visibility = System.Windows.Visibility.Collapsed;
        }//end hideStuff

        private void openFuture(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void hideInfo()
        {
            CourseInfoBox.Visibility = System.Windows.Visibility.Collapsed;
        }//end hideInfo

        private void hideRightInfo()
        {//hides background stuff
            courseButtonsStack.Visibility = System.Windows.Visibility.Collapsed;
            labBorder.Visibility = System.Windows.Visibility.Collapsed;
            tutBorder.Visibility = System.Windows.Visibility.Collapsed;
            infoNoteBox.Visibility = System.Windows.Visibility.Collapsed;
            infoTutLabel.Visibility = System.Windows.Visibility.Collapsed;
            infoLabLabel.Visibility = System.Windows.Visibility.Collapsed;
        }//end hideRightInfo

        private void showRightInfo()
        {//shows background stuff of the right side of the info box
            courseButtonsStack.Visibility = System.Windows.Visibility.Visible;
            labBorder.Visibility = System.Windows.Visibility.Visible;
            tutBorder.Visibility = System.Windows.Visibility.Visible;
            infoNoteBox.Visibility = System.Windows.Visibility.Visible;
            infoTutLabel.Visibility = System.Windows.Visibility.Visible;
            infoLabLabel.Visibility = System.Windows.Visibility.Visible;
        }//end showRightInfo

        private void dropClick(object sender, RoutedEventArgs e)
        { //hides background stuff and opens the drop course "pop-up
            hideRightInfo();
            dropUp.Visibility = System.Windows.Visibility.Visible;
        }

        private void dropCancelClick(object sender, RoutedEventArgs e)
        {//shows background stuff and hides the drop course "pop-up
            showRightInfo();
            dropUp.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void withdrawClick(object sender, RoutedEventArgs e)
        {
            //hides background stuff and opens the drop course "pop-up
            hideRightInfo();
            withUp.Visibility = System.Windows.Visibility.Visible;
        }

        private void withCancelClick(object sender, RoutedEventArgs e)
        {
            //shows background stuff and hides the drop course "pop-up
            showRightInfo();
            withUp.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void swapCancelClick(object sender, RoutedEventArgs e)
        {//shows background stuff and hides the swap course "pop-up
            showRightInfo();
            swapUp.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void swapClick(object sender, RoutedEventArgs e)
        {//hides background stuff and opens the swap course "pop-up
            hideRightInfo();
            swapUp.Visibility = System.Windows.Visibility.Visible;

        }

        private void editClick(object sender, RoutedEventArgs e)
        {//hides background stuff and opens the edit course "pop-up
            hideRightInfo();
            editUp.Visibility = System.Windows.Visibility.Visible;
        }

        private void editCancelClick(object sender, RoutedEventArgs e)
        {
            //shows background stuff and hides the edit course "pop-up
            showRightInfo();
            editUp.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void enrollClick(object sender, RoutedEventArgs e)
        {
            //do stuff
        }

        private void clickByCat(object sender, RoutedEventArgs e)
        {//the 'Search by Category' button is clicked
            hideStuffInit();
            catScroll.Visibility = System.Windows.Visibility.Visible;
            
            //Console.WriteLine("Courses by Category Clicked!!");

            if ((scrollCatStack.Children.Count != dl.categoryList.Length) && (dl.categoryList != null))
            {//if this is true, then category scroller is missing some categories
                //clear the stack
                scrollCatStack.Children.Clear();

                    try
                    {//create and show the categoryBlocks
                        for (int i = 0; i < dl.categoryList.Length; i++) //TODO more dynamic
                        {
                            CategoryBlock newBlock = new CategoryBlock(dl.categoryList[i], this);
                            this.scrollCatStack.Children.Add(newBlock);
                            newBlock.Visibility = System.Windows.Visibility.Visible;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error Found in Main Window: Test Block Creation");
                        Console.WriteLine(ex);
                    }
               }//end if-then
            }//end clickByCat

        public void fillInfo(Course theCourse, Lecture theLecture)
        {//this method fills out the display fields for Course Info
            CourseInfoBox.Visibility = System.Windows.Visibility.Visible;
            //fill info
            float code = theCourse.getNumber() + (theLecture.getNumber()/100);
            infoName.Text = (theCourse.getCategory() + " " + code);
            infoSDesc.Text = theCourse.getName();
            infoDay.Text = theLecture.getDays();
            infoTime.Text = theLecture.getStart() + " - " + theLecture.getEnd();
            infoInstruct.Text = theLecture.getInstructor();
            infoBR.Text = theLecture.getBuilding() + " " + theLecture.getRoom();
            infoReq.Text = ""; //TODO figure out how to display requirements
            infoDescBox.Content = theCourse.getDesc();
            infoNoteBox.Content = theCourse.getNotes();
            //add Lab Sections
            if (theLecture.getLabNumber() > 0)
            {
                infoLabStack.Children.Clear();
                labBorder.Visibility = System.Windows.Visibility.Visible;
                infoLabLabel.Visibility = System.Windows.Visibility.Visible;

                for (int i = 0; i < theLecture.getLabNumber(); i++)
                {
                    TutLabBlock newBlock = new TutLabBlock(theLecture.getLab(i), this);
                    this.infoLabStack.Children.Add(newBlock);
                    newBlock.Visibility = System.Windows.Visibility.Visible;
                }//end for loop
            }//end if-then
            else
            {
                labBorder.Visibility = System.Windows.Visibility.Collapsed;
                infoLabLabel.Visibility = System.Windows.Visibility.Collapsed;
            }//end if-else
            //add Tutorial Sections
            if (theLecture.getTutorialNumber() > 0)
            {
                infoTutStack.Children.Clear();
                tutBorder.Visibility = System.Windows.Visibility.Visible;
                infoTutLabel.Visibility = System.Windows.Visibility.Visible;

                for (int i = 0; i < theLecture.getTutorialNumber(); i++)
                {
                    TutLabBlock newBlock = new TutLabBlock(theLecture.getTutorial(i), this);
                    this.infoTutStack.Children.Add(newBlock);
                    newBlock.Visibility = System.Windows.Visibility.Visible;
                }//end for loop
            }//end if-then
            else
            {
                tutBorder.Visibility = System.Windows.Visibility.Collapsed;
                infoTutLabel.Visibility = System.Windows.Visibility.Collapsed;
            }//end if-else
            //display on schedule TODO
        }//end fillInfo

    }//end Main Window Class
}//end namespace
