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
    /// Interaction logic for TutLabBlock.xaml
    /// </summary>
    public partial class TutLabBlock : UserControl
    {
        MainWindow theWindow;
        Tutorial theTut;
        Lab theLab;
        Boolean isLab;

        public TutLabBlock()
        {
        }

        public TutLabBlock(Tutorial tut, MainWindow window)
        {//this is for adding a Tutorial
            InitializeComponent();

            if (tut != null)
            {
                theTut = tut;
                theLab = null;
                isLab = false;

                tlbSection.Text = "Tutorial " + tut.getNumber().ToString();

                if (tut.getDays() != "TBA")
                {//if the day-times are set, display
                    tlbTime.Text = tut.getStart() + " - " + tut.getEnd();
                    tlbDays.Text = tut.getDays();
                }
                else
                {//day-times not set
                    tlbTime.Text = "";
                    tlbDays.Text = "TBA";
                }

                if (tut.getBuilding() != "TBA")
                {//building and room are set, display it
                    tlbRoom.Text = tut.getBuilding() + tut.getRoom();
                }
                else
                {//building and room not set
                    tlbRoom.Text = "TBA";
                }

                if (tut.getSeatsFilled() < tut.getSeatsTotal())
                {
                    //change background color to blue
                }//end if-then
            }//end if not-null
        }//end constructor

        public TutLabBlock(Lab lab, MainWindow window)
        {//this is for adding a Lab
            InitializeComponent();

            if (lab != null)
            {
                tlbSection.Text = "Lab " + lab.getNumber().ToString();
                theLab = lab;
                theTut = null;
                isLab = true;

                if (lab.getDays() != "TBA")
                {//if the day-times are set, display
                    tlbTime.Text = lab.getStart() + " - " + lab.getEnd();
                    tlbDays.Text = lab.getDays();
                }
                else
                {//day-times not set
                    tlbTime.Text = "";
                    tlbDays.Text = "TBA";
                }

                if (lab.getBuilding() != "TBA")
                {//building and room are set, display it
                    tlbRoom.Text = lab.getBuilding() + lab.getRoom();
                }
                else
                {//building and room not set
                    tlbRoom.Text = "TBA";
                }

                if (lab.getSeatsFilled() < lab.getSeatsTotal())
                {
                    //change background color to blue
                    var bc = new BrushConverter();
                    tlbGrid.Background = (Brush)bc.ConvertFrom(MainWindow.littleBlue);
                }//end if-then
                else
                {
                    //red!!
                }//end if-else
            }//end if not null
        }//end constructor
    }
}
