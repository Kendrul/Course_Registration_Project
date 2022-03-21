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
    /// Interaction logic for CategoryBlock.xaml
    /// </summary>
    public partial class CategoryBlock : UserControl
    {
        private Category theCategory;
        private MainWindow theWindow;

        public CategoryBlock()
        {
        }

        public CategoryBlock(Category newCat, MainWindow window)
        {
            InitializeComponent();
            theWindow = window;
            if (newCat != null)
            {
                theCategory = newCat;
                this.catButt.Content = newCat.getName();
            }
        }

        private void catButClick(object sender, RoutedEventArgs e)
        {//should load the courses within a category
            theWindow.catScroll.Visibility = System.Windows.Visibility.Collapsed; //hide category scroller
            theWindow.scrollCourseStack.Children.Clear(); //clear the scroller
            theWindow.courseScroll.Visibility = System.Windows.Visibility.Visible;

            try
            {//create and show the courseBlock
                for (int i = 0; i < theCategory.getCourseList().Length; i++) //TODO more dynamic
                {
                    CourseBlock newBlock = new CourseBlock(theCategory.getCourse(i), theWindow);
                    theWindow.scrollCourseStack.Children.Add(newBlock);
                    newBlock.Visibility = System.Windows.Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Found in Main Window: Course Block Creation");
                Console.WriteLine(ex);
            }
        }//end constructor
    }
}
