using System.Windows;
using System.Windows.Controls;

namespace WpfStopwatch
{
    using Stopwatch.ViewModel;
    using System.Windows.Threading;
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
            _stopwatchViewModel.OnPropertyChanged(String.Empty);
        }
        public void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            _stopwatchViewModel.StartStop();
        }
        public void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            _stopwatchViewModel.Reset();
        }
        public void LapButton_Click(object sender, RoutedEventArgs e)
        {
            _stopwatchViewModel.LapTime();
        }
    }
}
