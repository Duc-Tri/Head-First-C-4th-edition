using Stopwatch.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfStopwatch
{
    /// <summary>
    /// Interaction logic for StopwatchControl.xaml
    /// </summary>
    public partial class StopwatchControl : UserControl
    {

        DispatcherTimer _timer = new DispatcherTimer();
        StopwatchViewModel _stopwatchViewModel;

        public StopwatchControl()
        {
            InitializeComponent();
            _stopwatchViewModel = Resources["viewModel"] as StopwatchViewModel;
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            // When an object calls its PropertyChange event with PropertyName set to an empty string, it causes a control using it as data context to update all of its bound properties
            _stopwatchViewModel.OnPropertyChanged(string.Empty);
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            _stopwatchViewModel.StartStop();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs args)
        {
            _stopwatchViewModel.Reset();
        }

        private void LapButton_Click(object sender, RoutedEventArgs e)
        {
            _stopwatchViewModel.LapTime();
        }
    }
}
