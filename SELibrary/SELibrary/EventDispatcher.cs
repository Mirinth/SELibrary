using System;

namespace SELibrary
{
    /// <summary>
    /// Generates and allows subscription to various
    /// events in the program.
    /// </summary>
    static class EventDispatcher
    {
        /// <summary>
        /// The event raised when the date changes.
        /// </summary>
        public static event Action<DateTime> OnDateChanged;

        /// <summary>
        /// The event raised when the BusinessRules encounteres
        /// an error while trying to service a request.
        /// </summary>
        public static event Action<ErrorCode> OnErrorEncountered;

        /// <summary>
        /// Notifies listeners that the date has been changed.
        /// </summary>
        /// <param name="newDate">The new date.</param>
        public static void DateChanged(DateTime newDate)
        {
            OnDateChanged(newDate);
        }

        /// <summary>
        /// Notifies listeners that an error occurred.
        /// </summary>
        /// <param name="ec">The error that occurred.</param>
        public static void ReportError(ErrorCode ec)
        {
            OnErrorEncountered(ec);
        }

        /// <summary>
        /// Initializes the EventDispatcher object.
        /// </summary>
        static EventDispatcher()
        {
            // Events need to be initialized, but you can't have an
            // Action<T> that doesn't point to a method, so point them
            // to a method that does nothing since nobody has registered
            // for any events at this point in the execution.
            OnDateChanged = new Action<DateTime>((x) => { return; });
            OnErrorEncountered = new Action<ErrorCode>((x) => { return; });
        }
    }
}