using System.Reflection;

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

        public TimeSpan LapTime { get; private set; }
        public void SetLapTime() => LapTime = Elapsed;

        /// <summary>
        /// The constructor resets the stopwatch
        /// </summary>
        public StopwatchModel() => Reset();

        /// <summary>
        /// Starts and stops the stopwatch, returns true if the stopwatch is running
        /// </summary>
        public bool Running
        {
            // The Running property compares _startTime to DateTime.MinValue to see if the stopwatch is currently running.
            // It sets _startedTime to the current time to start the stopwatch – but only if it’s not running yet.

            get => _startedTime != DateTime.MinValue && !_paused;

            set
            {
                if (value)
                {
                    // When Running is set to true, the model unpauses, setting the _paused, _pausedAt, and _startedTime fields.
                    _paused = false;

                    // If the stopwatch was previously paused, the time that it was paused is added to _totalPausedTime.
                    if (_pausedAt != DateTime.MinValue)
                        _totalPausedTime += DateTime.Now - _pausedAt;

                    if (_startedTime == DateTime.MinValue)
                        _startedTime = DateTime.Now;
                }
                else
                {
                    // When Running is set to false, the model sets _paused to true and _pausedAt to the current time.

                    _paused = true;
                    _pausedAt = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Returns the elapsed time, or zero if the stopwatch is not running
        /// </summary>
        public TimeSpan Elapsed => _paused ? _pausedAt - _startedTime - _totalPausedTime
            : _startedTime != DateTime.MinValue ? DateTime.Now - _startedTime - _totalPausedTime
            : TimeSpan.Zero;
        //The elapsed time now subtracts the started time and the total time the stopwatch was paused from the current time.
        // The Elapsed property returns the elapsed time by subtracting the time the stopwatch started from the current time

        /// <summary>
        /// Resets the stopwatch by setting its started time and unpausing it
        /// </summary>
        public void Reset()
        {
            _startedTime = DateTime.MinValue;
            _pausedAt = DateTime.MinValue;
            _paused = false;
            _totalPausedTime = TimeSpan.Zero;
            LapTime = TimeSpan.Zero;
        }
        // To reset the stopwatch and stop it running, we set its started time to DateTime.MinValue.

    }

}