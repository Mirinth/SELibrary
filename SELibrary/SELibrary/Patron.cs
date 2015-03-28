using System;

namespace SELibrary
{
    /// <summary>
    /// Represents a patron of the library.
    /// </summary>
    public class Patron
    {
        /// <summary>
        /// Gets the patron's ID.
        /// </summary>
        public uint ID
        {
            get; private set;
        }

        /// <summary>
        /// Gets the patron's name.
        /// </summary>
        public string Name
        {
            get; private set;
        }

        /// <summary>
        /// Gets the patron's birthday.
        /// </summary>
        public DateTime Birthday
        {
            get; private set;
        }

        /// <summary>
        /// Gets the number of items currently checked out
        /// to the patron.
        /// </summary>
        public uint CheckoutCount
        {
            get; private set;
        }

        /// <summary>
        /// Initializes a new patron.
        /// </summary>
        /// <param name="patronName">The patron's name.</param>
        /// <param name="patronBirthday">The patron's birthday.</param>
        public Patron(uint patronID, string patronName, DateTime patronBirthday)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks out an item to the patron.
        /// </summary>
        public void CheckInItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks in an item from the patron.
        /// </summary>
        public void CheckOutItem()
        {
            throw new NotImplementedException();
        }
    }
}