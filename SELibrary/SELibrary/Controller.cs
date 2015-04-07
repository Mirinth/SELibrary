using System;
using System.Collections.Generic;

namespace SELibrary
{
    /// <summary>
    /// Handles requests from the UI and reports error conditions
    /// back to the UI. Requests should only throw exceptions if
    /// the program cannot continue (or the constructor fails to
    /// initialize).
    /// EventDispatcher.OnErrorEncountered event is raised instead
    /// when errors occur.
    /// </summary>
    class Controller
    {
        private const int ADULT_CHECKOUT_CAP = 6;
        private const int CHILD_CHECKOUT_CAP = 3;
        private Database libraryDatabase;
        private bool initialized;

        /// <summary>
        /// Gets the current date, according to the BusinessRules
        /// </summary>
        public DateTime CurrentDate { get; private set; }

        /// <summary>
        /// Initializes the BusinessRules object.
        /// </summary>
        /// <exception cref="TypeInitializationException">
        /// Thrown when the database fails to load.
        /// </exception>
        public Controller(string databaseFile)
        {
            libraryDatabase = FileIO.LoadDatabase(databaseFile);

            CurrentDate = new DateTime(2015, 1, 1);

            initialized = true;
        }

        /// <summary>
        /// Checks out the given item to the given patron.
        /// </summary>
        /// <param name="item">The item to check out.</param>
        /// <param name="borrower">The patron to loan it to.</param>
        public void CheckOut(Media item, Patron borrower)
        {
            bool error = false;

            if (item == null)
            {
                EventDispatcher.RaiseItemWasNull();
                error = true;
            }
            else if (item.IsBorrowed)
            {
                EventDispatcher.RaiseItemAlreadyCheckedOut(item);
                error = true;
            }

            if (borrower == null)
            {
                EventDispatcher.RaisePatronWasNull();
                error = true;
            }
            else if (IsAdult(borrower) && borrower.CheckoutCount >= ADULT_CHECKOUT_CAP)
            {
                EventDispatcher.RaiseAdultCheckoutsExceeded(item, borrower);
                error = true;
            }
            else if (borrower.CheckoutCount >= CHILD_CHECKOUT_CAP)
            {
                EventDispatcher.RaiseChildCheckoutsExceeded(item, borrower);
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

            item.CheckOut(borrower.ID, dueDate);
            borrower.CheckOutItem();
        }

        /// <summary>
        /// Checks in the given item.
        /// </summary>
        /// <param name="item">The item to check in.</param>
        public void CheckIn(Media item)
        {
            bool error = false;

            // method returns if true
            if (item == null)
            {
                EventDispatcher.RaiseItemWasNull();

                // All the other errors can only occur once the patron
                // who checked out the item is known, but that patron
                // can't be identified given a null media, so there's
                // no point in continuing if there's already an error.
                return;
            }
            else if (item.IsBorrowed)
            {
                EventDispatcher.RaiseItemAlreadyCheckedOut(item);
                error = true;
            }

            Patron borrower = libraryDatabase[item.Borrower];

            if (borrower == null)
            {
                EventDispatcher.RaisePatronWasNull();
                error = true;
            }

            // All preconditions have been checked and either met or
            // reported, so this is the best place to stop if there
            // is a detectable error.
            if (error)
            {
                return;
            }

            item.CheckIn();
            borrower.CheckInItem();
        }

        /// <summary>
        /// Gets a list of all patrons.
        /// </summary>
        /// <returns>A list of all patrons.</returns>
        public List<Patron> ListPatrons()
        {
            return libraryDatabase.AllPatrons ?? new List<Patron>();
        }

        /// <summary>
        /// Gets a list of all media.
        /// </summary>
        /// <returns>A list of all media.</returns>
        public List<Media> ListMedia()
        {
            return libraryDatabase.AllMedia ?? new List<Media>();
        }

        /// <summary>
        /// Gets a list of all overdue media.
        /// </summary>
        /// <returns>A list of all overdue media.</returns>
        public List<Media> ListOverdueMedia()
        {
            return libraryDatabase.OverdueMedia() ?? new List<Media>();
        }

        /// <summary>
        /// Gets a list of all media items checked out to a patron.
        /// </summary>
        /// <param name="byPatron">The patron of interest.</param>
        /// <returns>A list of all media items checked out to the patron.</returns>
        public List<Media> ListMediaByPatron(Patron byPatron)
        {
            return libraryDatabase.MediaByBorrower(byPatron) ?? new List<Media>();
        }

        /// <summary>
        /// Simulates the passage of time
        /// </summary>
        public void PassTime()
        {
            const int TIME_INCREMENT = 1;

            CurrentDate.AddDays(TIME_INCREMENT);
            EventDispatcher.RaiseDateChanged(CurrentDate);
        }

        /// <summary>
        /// Returns whether a given patron is an adult.
        /// </summary>
        /// <param name="toCheck">The patron to check.</param>
        /// <returns>True if the patron is an adult, else false.</returns>
        private bool IsAdult(Patron toCheck)
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
        /// <param name="item">The item to calculate the due date for.</param>
        /// <returns>The date the item will be due, if it is checked out today.</returns>
        private DateTime CalculateDueDate(Media item)
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
    }
}