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
        /// Initializes the BusinessRules object.
        /// </summary>
        static Controller()
        {
            CurrentDate = new DateTime(2015, 1, 1);

            // Events need to be initialized, but you can't have an
            // Action<T> that doesn't point to a method, so point them
            // to a method that does nothing since the BusinessRules
            // doesn't really care when the events occur right now.
            DateChanged = new Action<DateTime>((x) => { return; });
            ErrorEncountered = new Action<ErrorCode>((x) => { return; });
        }

        /// <summary>
        /// Reports an error encountered while processing a request.
        /// </summary>
        /// <param name="em">An ErrorCode describing the error.</param>
        public static void ReportError(ErrorCode ec)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks out the given item to the given patron.
        /// </summary>
        /// <param name="item">The item to check out.</param>
        /// <param name="toPatron">The patron to loan it to.</param>
        public static void CheckOut(Media item, Patron toPatron)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks in the given item.
        /// </summary>
        /// <param name="item">The item to check in.</param>
        public static void CheckIn(Media item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all patrons.
        /// </summary>
        /// <returns>A list of all patrons.</returns>
        public static List<Patron> ListPatrons()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all media.
        /// </summary>
        /// <returns>A list of all media.</returns>
        public static List<Media> ListMedia()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all overdue media.
        /// </summary>
        /// <returns>A list of all overdue media.</returns>
        public static List<Media> ListOverdueMedia()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all media items checked out to a patron.
        /// </summary>
        /// <param name="byPatron">The patron of interest.</param>
        /// <returns>A list of all media items checked out to the patron.</returns>
        public static List<Media> ListMediaByPatron(Patron byPatron)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Simulates the passage of time
        /// </summary>
        public static void PassTime()
        {
            throw new NotImplementedException();
        }
    }
}