namespace Stopwatch.View
{
    using System;
    using System.Net.Quic;
    using System.Threading;
    using ViewModel;

    public class StopwatchView
    {
        private StopwatchViewModel _viewModel = new StopwatchViewModel();
        private bool _quit = false;

        /// <summary>
        /// Clears the console and displays the stopwatch
        /// </summary>
        public StopwatchView()
        {
            ClearScreenAndAddHelpMessage();

            // The view uses a System.Threading.Timer.
            // It’s a different kind of timer than the one you used in Chapter 1. That timer raised an event every time it ticked. 
            // The timer you’ll use now is different—it uses a callback.
            // Its constructor takes a TimerCallback delegate with a reference to the method that it will call each time it ticks. 
            // After the constructor starts the timer, it uses a loop to wait until the user quits. 
            // Thread.Sleep keeps the app from using CPU cycles while it’s waiting for the next timer tick.

            TimerCallback timerCallback = UpdateTimeCallback;
            var _timer = new Timer(timerCallback, null, 0, 10);
            while (!_quit)
                Thread.Sleep(100);

            Console.CursorVisible = true;
        }

        /// <summary>
        /// Clears the screen, adds the help message to fourth row, and makes the cursor invisible
        /// </summary>
        private void ClearScreenAndAddHelpMessage()
        {
            Console.Clear();
            Console.CursorTop = 3; // This moves the cursor to the fourth row (rows start at 0)
            Console.WriteLine("Space to start, R to reset, any other key to quit");
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Callback to update the time dispay that the time calls each time it ticks
        /// </summary>
        private void UpdateTimeCallback(object? state)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Spacebar)
                {
                    _viewModel.StartStop();
                }
                else if (cki.Key == ConsoleKey.R)
                {
                    _viewModel.Reset();
                }
                else
                {
                    Quit();
                }
            }
        }

        private void Quit()
        {
            Console.CursorVisible = true;
            Console.CursorTop = 6;

            // and quit !
        }

        /// <summary>
        /// Writes the current time to the second row and 23rd column of the screen
        /// </summary>
        public void WriteCurrentTime()
        {
            Console.CursorTop = 1; // This moves the cursor to the second row (rows start at 0)
            Console.CursorLeft = 23; // This moves the cursor to the 23rd column (starting at 0)

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            var time = "${_viewModel.Hours:_viewModel.Minutes:_viewModel.Seconds._viewModel.Tenths}";

            Console.Write(time);
        }

    }

}