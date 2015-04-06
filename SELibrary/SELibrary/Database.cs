using System;
using System.Collections.Generic;

namespace SELibrary
{
    /// <summary>
    /// Stores information about the library's media and patrons.
    /// </summary>
    class Database
    {
        private List<Media> items;
        private List<Patron> patrons;

        /// <summary>
        /// Initiializes the database.
        /// </summary>
        /// <param name="mediaItems">A list of media items in the library.</param>
        /// <param name="patrons">A list of patrons of the library.</param>
        public Database(List<Media> mediaList, List<Patron> patronList)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all media items in the library.
        /// </summary>
        /// <returns>A list of all media in the library.</returns>
        public List<Media> AllMedia()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all media items checked out to
        /// a given patron.
        /// </summary>
        /// <param name="borrower">
        /// The patron to find the items checked out to.
        /// </param>
        /// <returns>A list of all media loaned to the given patron.</returns>
        public List<Media> MediaByBorrower(Patron borrower)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of all media items that are overdue.
        /// </summary>
        /// <returns>A list of all overdue media.</returns>
        public List<Media> OverdueMedia()
        {
            throw new NotImplementedException();
        }
    }
}