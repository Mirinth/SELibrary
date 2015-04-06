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
        public static event Action<DateTime> DateChanged = delegate { };

        /// <summary>
        /// Notifies listeners that the date has been changed.
        /// </summary>
        /// <param name="newDate">The new date.</param>
        public static void RaiseDateChanged(DateTime newDate)
        {
            DateChanged(newDate);
        }

        /// <summary>
        /// The event raised when an item failed to be checked out
        /// because it was already checked out.
        /// </summary>
        public static event Action<Media> ItemAlreadyCheckedOut = delegate { };

        /// <summary>
        /// Notifies listeners that an item failed to be checked
        /// out because it was already checked out.
        /// </summary>
        /// <param name="item">The item that failed to be checked out.</param>
        public static void RaiseItemAlreadyCheckedOut(Media item)
        {
            ItemAlreadyCheckedOut(item);
        }

        /// <summary>
        /// The event raised when an item failed to be checked out
        /// because an adult patron's checkout count was exceeded.
        /// </summary>
        public static Action<Media, Patron> AdultCheckoutsExceeded = delegate { };

        /// <summary>
        /// Notifies listeners that an item failed to be checked
        /// out because an adult's checkout count was exceeded.
        /// </summary>
        /// <param name="item">The item that failed to be checked out.</param>
        /// <param name="borrower">The patron who tried to borrow the item.</param>
        public static void RaiseAdultCheckoutsExceeded(Media item, Patron borrower)
        {
            AdultCheckoutsExceeded(item, borrower);
        }

        /// <summary>
        /// The event raised when an item failed to be checked out
        /// because a child patron's checkout count was exceeded.
        /// </summary>
        public static Action<Media, Patron> ChildCheckoutsExceeded = delegate { };

        /// <summary>
        /// Notifies listeners that an item failed to be checked
        /// out because a child's checkout count was exceeded.
        /// </summary>
        /// <param name="item">The item that failed to be checked out.</param>
        /// <param name="borrower">The patron who tried to borrow the item.</param>
        public static void RaiseChildCheckoutsExceeded(Media item, Patron borrower)
        {
            ChildCheckoutsExceeded(item, borrower);
        }
    }
}