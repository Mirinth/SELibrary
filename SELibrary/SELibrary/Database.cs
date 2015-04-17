using System;
using System.Collections.Generic;

namespace SELibrary
{
    /// <summary>
    /// Stores information about the library's media and patrons.
    /// </summary>
    [Serializable]
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
            items = mediaList;
            patrons = patronList;
        }

        /// <summary>
        /// Gets a list of all media items in the library.
        /// </summary>
        /// <returns>A list of all media in the library.</returns>
        public List<Media> AllMedia
        {
            get
            {
                return items;
            }
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
            List<Media> returnList = new List<Media>();
            foreach(Media item in items)
            {
                if(item.IsBorrowed && item.Borrower == borrower.ID)
                {
                    returnList.Add(item);
                }
            }
            return returnList;
        }

        /// <summary>
        /// Gets a list of all media items that are overdue.
        /// </summary>
        /// <param name="currentDate">The current date.</param>
        /// <returns>A list of all overdue media.</returns>
        public List<Media> OverdueMedia(DateTime currentDate)
        {
            List<Media> returnList = new List<Media>();
            foreach (Media item in items)
            {
                if (item.IsOverdue(currentDate))
                {
                    returnList.Add(item);
                }
            }
            return returnList;
        }

        /// <summary>
        /// Gets a list of all patrons in the library.
        /// </summary>
        /// <returns>A list of all patrons in the library.</returns>
        public List<Patron> AllPatrons
        {
            get
            {
                return patrons;
            }
        }

        /// <summary>
        /// Gets a patron by its ID.
        /// </summary>
        /// <param name="id">The patron's ID.</param>
        /// <returns>The patron with the given ID.</returns>
        public Patron PatronByID(uint id)
        {
            foreach (Patron person in patrons)
            {
                if (person.ID == id)
                {
                    return person;
                }
            }
            return null;
        }

        /// <summary>
        /// Add A book To DataBase
        /// </summary>
        /// <param name="toAdd"></param>
        public void AddPatron(Patron toAdd)
        {
            patrons.Add(toAdd);
        }

        /// <summary>
        /// Add Media To DataBase
        /// </summary>
        /// <param name="toAdd"></param>
        public void AddMedia(Media toAdd)
        {
            items.Add(toAdd);
        }
    }
}