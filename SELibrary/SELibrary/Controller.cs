using System;
using System.Collections.Generic;

namespace SELibrary
{
    /// <summary>
    /// Enumerates the various error conditions the BusinessRules
    /// object can encounter while servicing requests.
    /// </summary>
    enum ErrorCode
    {
        /// <summary>
        /// Attempted to check out an item that was already checked out.
        /// </summary>
        ItemCheckedOut,

        /// <summary>
        /// An adult tried to check out more items than allowed.
        /// </summary>
        AdultCheckoutsExceeded,

        /// <summary>
        /// A child tried to check out more items than allowed.
        /// </summary>
        ChildCheckoutsExceeded,
    }

    /// <summary>
    /// Handles requests from the UI and reports error conditions
    /// back to the UI. Requests should only throw exceptions if
    /// the program cannot continue. ErrorEncountered event is
    /// raised instead when errors occur.
    /// </summary>
    static class Controller
    {
        private const int ADULT_CHECKOUT_CAP = 6;
        private const int CHILD_CHECKOUT_CAP = 3;
        private static Database libraryDatabase;
        private static bool initialized;

        /// <summary>
        /// The event raised when the date changes.
        /// </summary>
        public static event Action<DateTime> DateChanged;

        /// <summary>
        /// The event raised when the BusinessRules encounteres
        /// an error while trying to service a request.
        /// </summary>
        public static event Action<ErrorCode> ErrorEncountered;

        /// <summary>
        /// Gets the current date, according to the BusinessRules
        /// </summary>
        public static DateTime CurrentDate { get; private set; }

        /// <summary>
        /// The Controller's static constructor. Partially
        /// initializes the Controller object. Call Init to
        /// complete initialization.
        /// </summary>
        static Controller()
        {
            initialized = false;
        }

        /// <summary>
        /// Initializes the BusinessRules object.
        /// </summary>
        public static void Init(string databaseFile)
        {
            bool error = false;
            Action<ErrorCode> errorCatcher = (ec) => error = true;
            ErrorEncountered += errorCatcher;

            libraryDatabase = FileIO.LoadDatabase(databaseFile);
            ErrorEncountered -= errorCatcher;

            // If the database failed to open, this method will probably
            // be called again with a new database file. The below code
            // may assume it only gets called once. Failure means the
            // Controller can't be used anyway, so return early without
            // initializing.
            if (error)
            {
                return;
            }

            CurrentDate = new DateTime(2015, 1, 1);

            // Events need to be initialized, but you can't have an
            // Action<T> that doesn't point to a method, so point them
            // to a method that does nothing since the BusinessRules
            // doesn't really care when the events occur right now.
            DateChanged = new Action<DateTime>((x) => { return; });
            ErrorEncountered = new Action<ErrorCode>((x) => { return; });

            initialized = true;
        }

        /// <summary>
        /// Reports an error encountered while processing a request.
        /// </summary>
        /// <param name="em">An ErrorCode describing the error.</param>
        public static void ReportError(ErrorCode ec)
        {
            ErrorEncountered(ec);
        }

        /// <summary>
        /// Checks out the given item to the given patron.
        /// </summary>
        /// <param name="item">The item to check out.</param>
        /// <param name="toPatron">The patron to loan it to.</param>
        public static void CheckOut(Media item, Patron toPatron)
        {
            EnsureInitialized();

            bool error = false;

            if (item.IsBorrowed)
            {
                ErrorEncountered(ErrorCode.ItemCheckedOut);
                error = true;
            }

            if (IsAdult(toPatron) && toPatron.CheckoutCount >= ADULT_CHECKOUT_CAP)
            {
                ErrorEncountered(ErrorCode.AdultCheckoutsExceeded);
                error = true;
            }
            else if (toPatron.CheckoutCount >= CHILD_CHECKOUT_CAP)
            {
                ErrorEncountered(ErrorCode.ChildCheckoutsExceeded);
                error = true;
            }

            // All preconditions have been checked and either met or
            // reported, so this is the best place to stop if there
            // is a detectable error.
            if (error)
            {
                return;
            }

            DateTime dueDate = CalculateDueDate(item);

            item.CheckOut(toPatron.ID, dueDate);
            toPatron.CheckOutItem();
        }

        /// <summary>
        /// Checks in the given item.
        /// </summary>
        /// <param name="item">The item to check in.</param>
        public static void CheckIn(Media item)
        {
            EnsureInitialized();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all patrons.
        /// </summary>
        /// <returns>A list of all patrons.</returns>
        public static List<Patron> ListPatrons()
        {
            EnsureInitialized();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all media.
        /// </summary>
        /// <returns>A list of all media.</returns>
        public static List<Media> ListMedia()
        {
            EnsureInitialized();

            return libraryDatabase.AllMedia();
        }

        /// <summary>
        /// Gets a list of all overdue media.
        /// </summary>
        /// <returns>A list of all overdue media.</returns>
        public static List<Media> ListOverdueMedia()
        {
            EnsureInitialized();

            return libraryDatabase.OverdueMedia();
        }

        /// <summary>
        /// Gets a list of all media items checked out to a patron.
        /// </summary>
        /// <param name="byPatron">The patron of interest.</param>
        /// <returns>A list of all media items checked out to the patron.</returns>
        public static List<Media> ListMediaByPatron(Patron byPatron)
        {
            EnsureInitialized();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Simulates the passage of time
        /// </summary>
        public static void PassTime()
        {
            EnsureInitialized();

            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns whether a given patron is an adult.
        /// </summary>
        /// <param name="toCheck">The patron to check.</param>
        /// <returns>True if the patron is an adult, else false.</returns>
        public static bool IsAdult(Patron toCheck)
        {
            const int CHILD_YEARS = 18;
            const int DAYS_PER_YEAR = 365;

            TimeSpan childSpan = new TimeSpan(CHILD_YEARS * DAYS_PER_YEAR, 0, 0, 0);
            TimeSpan age = CurrentDate.Subtract(toCheck.Birthday);

            if (age < childSpan)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Calculates the due date of an item to be checked out.
        /// </summary>
        /// <param name="item">The item to calculate th due date for.</param>
        /// <returns>The date the item will be due, if it is checked out today.</returns>
        public static DateTime CalculateDueDate(Media item)
        {
            const int ADULT_BOOK_DAYS = 14;
            const int CHILD_BOOK_DAYS = 7;
            const int DVD_DAYS = 2;
            const int VIDEO_DAYS = 3;
            int days;

            if (item.Type == MediaType.Video)
            {
                days = VIDEO_DAYS;
            }
            else if (item.Type == MediaType.DVD)
            {
                days = DVD_DAYS;
            }
            else if (item.Type == MediaType.Book)
            {
                if (item.Rating == MediaRating.Adult)
                {
                    days = ADULT_BOOK_DAYS;
                }
                else if (item.Rating == MediaRating.Everyone)
                {
                    days = CHILD_BOOK_DAYS;
                }
                else
                {
                    // A new type of rating was added without accounting
                    // for it here.
                    throw new NotImplementedException();
                }
            }
            else
            {
                // A new MediaType was added without accounting
                // for it here.
                throw new NotImplementedException();
            }

            TimeSpan checkoutDuration = new TimeSpan(days, 0, 0, 0);
            DateTime dueDate = CurrentDate.Add(checkoutDuration);
            return dueDate;
        }

        /// <summary>
        /// Ensures the object was correctly initialized by a
        /// call to Init.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the object wasn't correctly initialized.
        /// </exception>
        public static void EnsureInitialized()
        {
            if (!initialized)
            {
                throw new InvalidOperationException();
            }
        }
    }
}