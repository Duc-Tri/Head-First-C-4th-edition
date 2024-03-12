using System;
using System.Windows;
using System.Windows.Threading;

// Some more details about how the Beehive Management System works
// • The goal is to get the TOTAL WORKERS line in the status report (which lists the total number of assigned workers) to go as high as possible—and that all depends on which workers you add and when you add them. Workers drain honey: if you’ve got too many of one kind of worker, the honey starts to go down. As you run the program, watch the honey and nectar numbers. After the first few shifts, you’ll get a low honey warning (so add a honey manufacturer); after a few more, you’ll get a low nectar warning (so add a nectar collector)—after that, you need to figure out how to staff the hive. How high can you get TOTAL WORKERS to go before the honey runs out?
namespace BeehiveManagementSystem
{
    // The code-behind for the main window just does a few things. It creates an instance of Queen, and has Click event handlers for the buttons to call her WorkTheNextShift and AssignBee methods and display the status report.
    public partial class MainWindow : Window
    {
        private readonly Queen queen;
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            btnAssignJob.IsEnabled = false;

            jobSelector.Items.Add(Bee.BEE_EGGCARE);
            jobSelector.Items.Add(Bee.BEE_NECTARCOLLECTOR);
            jobSelector.Items.Add(Bee.BEE_HONEYMANUFACTURER);

            // Now that the WPF app uses data binding we don’t need to use the Text property to update the status report TextBox, so go ahead and comment out or delete this line.
            queen = Resources["queen"] as Queen;  //new Queen();
            //statusReport.Text = queen.StatusReport; // NEW databinding

            timer.Tick += TimerTick;
            timer.Interval = TimeSpan.FromSeconds(1.5f);
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            btnAssignJob.IsEnabled = (queen.UnassignedWorkers >= 1f);
            Button_WorkTheNextShift(this, new RoutedEventArgs());
        }


        // When you press the button to work the next shift, the button’s Click event handler calls the Queen object’s WorkTheNextShift method, which is inherited from the Bee base class.
        private void Button_WorkTheNextShift(object sender, RoutedEventArgs e)
        {
            queen.WorkTheNextShift();
            //statusReport.Text = queen.StatusReport; // NEW databinding
            btnAssignJob.IsEnabled = (queen.UnassignedWorkers >= 1f);
        }

        // When you press the button to assign a job to a bee, the event handler calls the Queen object’s AssignBee method, which takes a string with the job name (you’ll get that name from jobSelector.text).
        private void Button_AssignJobToABee(object sender, RoutedEventArgs e)
        {
            queen.AssignBee(jobSelector.Text);
            //statusReport.Text = queen.StatusReport; // NEW databinding
            btnAssignJob.IsEnabled = (queen.UnassignedWorkers >= 1f);
        }

    }

}
