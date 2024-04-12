namespace Stopwatch.Model
{
    // The model knows the stopwatch is reset when its time is equal DateTime.MinValue, a special value with the smallest valid time.
    // If _startedTime is equal to that time, then the stopwatch isn’t running.
    // If not, that’s when the stopwatch was started.
    // It can calculate the elapsed time by subtracting _startedTime from the current date and time. 
    public class StopwatchModel
    {
        private DateTime _startedTime;

        private bool _paused;

        private DateTime _pausedAt;

        private TimeSpan _totalPausedTime;

        /// <summary>
        /// The constructor resets the stopwatch
        /// </summary>
        public StopwatchModel() => Reset();

        /// <summary>
        /// Returns true if the stopwatch is running
        /// </summary>
        public bool Running
        {
            // The Running property compares _startTime to DateTime.MinValue to see if the stopwatch is currently running.
            // It sets _startedTime to the current time to start the stopwatch – but only if it’s not running yet.

            get => _startedTime != DateTime.MinValue;

            set
            {
                if (value && !Running) _startedTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Returns the elapsed time, or zero if the stopwatch is not running
        /// </summary>
        public TimeSpan Elapsed => Running ? DateTime.Now - _startedTime : TimeSpan.Zero;
        // The Elapsed property returns the elapsed time by subtracting the time the stopwatch started from the current time

        /// <summary>
        /// Resets the stopwatch by setting its started time to DateTime.MinValue
        /// </summary>
        public void Reset() => _startedTime = DateTime.MinValue;
        // To reset the stopwatch and stop it running, we set its started time to DateTime.MinValue.

    }

}