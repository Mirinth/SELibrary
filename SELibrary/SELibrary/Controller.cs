﻿using System;
using System.Collections.Generic;
using System.IO;

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
        private ILibraryUI _ui;
        private FileStream _databaseFile;

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
        public Controller(ILibraryUI ui)
        {
            CurrentDate = DateTime.Today;
            libraryDatabase = new Database(new List<Media>(), new List<Patron>());
            _ui = ui;
            _databaseFile = null;

            _ui.ReportDateChanged(CurrentDate);
        }

        /// <summary>
        /// Loads the database at from disk and uses it.
        /// Loads a demo database with patrons and media.
        /// </summary>
        public void LoadDemoDatabase()
        {
            _ui.ClearErrors();

            List<Media> startMedia = new List<Media>();
            List<Patron> startPatron = new List<Patron>();
            //Add 20 Media
            /*startMedia.Add(new Media(1, MediaType.Book, "Suzanne Collins", "The Hunger Games"));
            startMedia.Add(new Media(2, MediaType.Book, "J.K. Rowling", "Harry Potter and the Order of the Pheonix"));
            startMedia.Add(new Media(3, MediaType.Book, "Harper Lee", "To Kill a Mockingbird"));
            startMedia.Add(new Media(4, MediaType.Book, "Stephenie Meyer", "Twilight"));
            startMedia.Add(new Media(5, MediaType.Book, "Jane Austen", "Pride and Prejudice"));
            startMedia.Add(new Media(6, MediaType.Book, "C.S. Lewis", "Pride and Prejudice"));
            startMedia.Add(new Media(7, MediaType.Book, "Margaret Mitchell", "Gone with the Wind"));
            startMedia.Add(new Media(8, MediaType.Book, "George Orwell", "Animal Farm"));
            startMedia.Add(new Media(9, MediaType.Book, "Shel Silberstein", "The Giving Tree"));
            startMedia.Add(new Media(10, MediaType.Book, "Douglas Adams", "The Hitchhiker's Guide to the Galaxy"));
            startMedia.Add(new Media(11, MediaType.Book, "Emily Bronte", "Wuthering Heights"));
            startMedia.Add(new Media(12, MediaType.Book, "Markus Zusak", "The Book Thief"));
            startMedia.Add(new Media(13, MediaType.DVD, "Cast Away", "Tom Hanks"));
            startMedia.Add(new Media(14, MediaType.DVD, "Richard N. Gladstein", "The Bourne Identity"));
            startMedia.Add(new Media(15, MediaType.DVD, "George Lucas", "Star Wars"));
            startMedia.Add(new Media(16, MediaType.DVD, "Brian Grazer", "Apollo 13"));
            startMedia.Add(new Media(17, MediaType.DVD, "Charles Gordon", "Die Hard"));
            startMedia.Add(new Media(18, MediaType.DVD, "Harry Saltzman", "James Bond"));
            startMedia.Add(new Media(19, MediaType.Video, "Frank Marshall", "Back to the Future"));
            startMedia.Add(new Media(20, MediaType.Video, "Branko Lustig", "Gladiator"));

            //Add 20 People
            startPatron.Add(new Patron(1, "Alex Smith", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(2, "Kim Johnson", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(3, "Harper Williams", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(4, "Kennedy Brown", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(5, "Paris Jones", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(6, "Skyler Miller", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(7, "Ryan Davis", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(8, "Remy Garcia", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(9, "Kelly Rodriguez", new DateTime(), PatronType.Child));
            startPatron.Add(new Patron(10, "Dakota Wilson", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(11, "Cassidy Anderson", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(12, "River Taylor", new DateTime(), PatronType.Child));
            startPatron.Add(new Patron(13, "Codi Hernandez", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(14, "Jayden Moore", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(15, "Darcy Jackson", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(16, "Terry Lewis", new DateTime(), PatronType.Child));
            startPatron.Add(new Patron(17, "Courtney Clark", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(18, "Leslie Young", new DateTime(), PatronType.Adult));
            startPatron.Add(new Patron(19, "Rory Hall", new DateTime(), PatronType.Child));
            startPatron.Add(new Patron(20, "Brett King", new DateTime(), PatronType.Adult));

            libraryDatabase = new Database(startMedia, startPatron);

            FileIO.SaveDatabase(FileIO.Open("Library_Database.bin"), libraryDatabase);

           libraryDatabase = FileIO.LoadDatabase(FileIO.Open("../../../../Data/Library_Database.bin"));*/
            _ui.ReportDatabaseChanged();
        }

        /// <summary>
        /// Loads the database at filePath and uses it.
        /// If an error occurs, it is reported to the UI and
        /// the previous database is retained.
        /// </summary>
        /// <returns>Whether the database loaded successfully.</returns>
        public void LoadDatabase()
        {
            bool loaded = false;
            Database db = null;

            if (_databaseFile != null)
            {
                FileIO.Close(_databaseFile);
            }

            while (loaded == false)
            {
                string filePath = _ui.PromptForFilePath();

                if (filePath == null)
                {
                    _ui.Close();
                    return;
                }

                _databaseFile = FileIO.Open(filePath);

                if (_databaseFile == null)
                {
                    _ui.ReportFileOpenFail();
                    continue; // try again
                }

                db = FileIO.LoadDatabase(_databaseFile);

                if (db == null)
                {
                    _ui.ReportCorruptedDatabase();
                    FileIO.Close(_databaseFile);
                    continue; // try again
                }

                loaded = true;
            }

            libraryDatabase = db;
            _ui.ReportDatabaseChanged();
        }

        /// <summary>
        /// Saves the database to disk.
        /// If an error occurs, it is reported to the UI.
        /// </summary>
        public void SaveDatabase()
        {
            _ui.ClearErrors();

            _databaseFile.SetLength(0);
            
            FileIO.SaveDatabase(_databaseFile, libraryDatabase);
        }

        /// <summary>
        /// Checks out the given item to the given patron.
        /// </summary>
        /// <param name="item">The item to check out.</param>
        /// <param name="borrower">The patron to loan it to.</param>
        public void CheckOut(Media item, Patron borrower)
        {
            _ui.ClearErrors();

            bool error = false;

            if (item == null)
            {
                _ui.ReportItemWasNull();
                error = true;
            }
            else if (item.IsBorrowed)
            {
                _ui.ReportItemAlreadyCheckedOut(item);
                error = true;
            }

            if (borrower == null)
            {
                _ui.ReportPatronWasNull();
                error = true;
            }
            else if (IsAdult(borrower) && borrower.CheckoutCount >= ADULT_CHECKOUT_CAP)
            {
                _ui.ReportAdultCheckoutsExceeded(item, borrower);
                error = true;
            }
            else if (!IsAdult(borrower) && 
                borrower.CheckoutCount >= CHILD_CHECKOUT_CAP)
            {
                _ui.ReportChildCheckoutsExceeded(item, borrower);
                error = true;
            }
            else if (!IsAdult(borrower) &&
                item.Rating != MediaRating.Everyone)
            {
                _ui.ReportRatingRestrictionViolation();
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
            _ui.ClearErrors();

            // method returns if true
            if (item == null)
            {
                _ui.ReportItemWasNull();

                // All the other errors can only occur once the patron
                // who checked out the item is known, but that patron
                // can't be identified given a null media, so there's
                // no point in continuing if there's already an error.
                return;
            }
            else if (!item.IsBorrowed)
            {
                _ui.ReportItemAlreadyCheckedIn(item);
                return;
            }

            Patron borrower = libraryDatabase.PatronByID(item.Borrower);

            if (borrower == null)
            {
                // The database is probably corrupted.
                throw new InvalidOperationException();
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
            return libraryDatabase.OverdueMedia(CurrentDate) ?? new List<Media>();
        }

        /// <summary>
        /// Gets a list of all media items checked out to a patron.
        /// </summary>
        /// <param name="byPatron">The patron of interest.</param>
        /// <returns>A list of all media items checked out to the patron.</returns>
        public List<Media> ListMediaByPatron(Patron byPatron)
        {
            if (byPatron == null)
            {
                // Don't trust the UI to give a valid patron.
                // Because it won't.
                return new List<Media>();
            }

            return libraryDatabase.MediaByBorrower(byPatron) ?? new List<Media>();
        }

        /// <summary>
        /// Simulates the passage of time
        /// </summary>
        public void PassTime()
        {
            const int TIME_INCREMENT = 1;

            CurrentDate = CurrentDate.AddDays(TIME_INCREMENT);
            _ui.ReportDateChanged(CurrentDate);
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