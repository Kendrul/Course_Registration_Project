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
    /// Interaction logic for LectureBlock.xaml
    /// </summary>
    public partial class LectureBlock : UserControl
    {
        private Lecture lecture;
        private MainWindow theWindow;

        public LectureBlock()
        {
            InitializeComponent();
        }

        public LectureBlock(Lecture theLecture, MainWindow window)
        {
            InitializeComponent();
            theWindow = window;
            if (theLecture != null)
            {
                lecture = theLecture;
                this.lbCourseName.Text = (theLecture.getCourse().getCategory()) + " " +(theLecture.getCourse().getNumber());
                this.lbNameLong.Text = theLecture.getCourse().getName();
                this.lbLecSection.Text = "Lecture " + theLecture.getNumber();
                this.lbTime.Text = theLecture.getDays() + " " + theLecture.getStart() + " - " + theLecture.getEnd();
                this.lbProf.Text = theLecture.getInstructor();
            }//end if-then
        }//end constructor

        private void lbClick(object sender, RoutedEventArgs e)
        {
            //brings up course info box
            theWindow.cLecScroll.Visibility = System.Windows.Visibility.Collapsed; //hide Lecture scroller
            theWindow.fillInfo(lecture.getCourse(), lecture);
        }
    }
}
