using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;


// Some more details about how the Beehive Management System works
// • The goal is to get the TOTAL WORKERS line in the status report (which lists the total number of assigned workers) to go as high as possible—and that all depends on which workers you add and when you add them. Workers drain honey: if you’ve got too many of one kind of worker, the honey starts to go down. As you run the program, watch the honey and nectar numbers. After the first few shifts, you’ll get a low honey warning (so add a honey manufacturer); after a few more, you’ll get a low nectar warning (so add a nectar collector)—after that, you need to figure out how to staff the hive. How high can you get TOTAL WORKERS to go before the honey runs out?
namespace BeehiveManagementSystem
{
    // The code-behind for the main window just does a few things. It creates an instance of Queen, and has Click event handlers for the buttons to call her WorkTheNextShift and AssignBee methods and display the status report.
    public partial class MainWindow : Window
    {
        private Queen myQueen;

        public MainWindow()
        {
            InitializeComponent();

            jobSelector.Items.Add(Bee.BEE_EGGCARE);
            jobSelector.Items.Add(Bee.BEE_NECTARCOLLECTOR);
            jobSelector.Items.Add(Bee.BEE_HONEYMANUFACTURER);

            myQueen = new Queen();
            statusReport.Text = myQueen.StatusReport;
        }

        // When you press the button to work the next shift, the button’s Click event handler calls the Queen object’s WorkTheNextShift method, which is inherited from the Bee base class.
        private void Button_WorkTheNextShift(object sender, RoutedEventArgs e)
        {
            myQueen.WorkTheNextShift();
            statusReport.Text = myQueen.StatusReport;
        }

        // When you press the button to assign a job to a bee, the event handler calls the Queen object’s AssignBee method, which takes a string with the job name (you’ll get that name from jobSelector.text).
        private void Button_AssignJobToABee(object sender, RoutedEventArgs e)
        {
            myQueen.AssignBee(jobSelector.Text);
            statusReport.Text = myQueen.StatusReport;
        }
    }
}
