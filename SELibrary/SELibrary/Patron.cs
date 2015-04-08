using System;

namespace SELibrary
{
    /// <summary>
    /// Represents a patron of the library.
    /// </summary>
    public class Patron
    {
        const uint MAX_ADULT_MEDIA = 6;
        const uint MAX_CHILD_MEDIA = 3;

        private uint patronId;
        private string patronName;
        private DateTime dataofBirth;
        private uint checkOutCount;
        private PatronType patronType;

        /// <summary>
        /// Gets the patron's ID.
        /// </summary>
        public uint ID
        {
            get { return patronId; }
        }

        /// <summary>
        /// Gets the patron's name.
        /// </summary>
        public string Name
        {
            get { return patronName; }
        }

        /// <summary>
        /// Gets the patron's birthday.
        /// </summary>
        public DateTime Birthday
        {
            get { return dataofBirth; }
        }

        /// <summary>
        /// Gets the number of items currently checked out
        /// to the patron.
        /// </summary>
        public uint CheckoutCount
        {
            get { return checkOutCount; }
        }

        /// <summary>
        /// Initializes a new patron.
        /// </summary>
        /// <param name="_patronName">The patron's name.</param>
        /// <param name="_patronBirthday">The patron's birthday.</param>
        /// <param name="_ptype">The patron type</param> 
        public Patron(uint _patronID, string _patronName, DateTime _patronBirthday, PatronType _ptype)
        {
            patronId = _patronID;
            patronName = _patronName;
            dataofBirth = _patronBirthday;
            checkOutCount = 0;
            patronType = _ptype;
        }

        /// <summary>
        /// Checks out an item to the patron.
        /// </summary>
        /// <returns>bool if failed or successful</returns>
        public bool CheckInItem()
        {
            if (checkOutCount > 0)
            {
                checkOutCount--;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Checks in an item from the patron.
        /// </summary>
        /// <returns>bool if failed or successful</returns>
        public bool CheckOutItem()
        {
            if (patronType == PatronType.Child && checkOutCount < MAX_ADULT_MEDIA)
            {
                checkOutCount++;
                return true;
            }
            else if (patronType == PatronType.Adult && checkOutCount < MAX_CHILD_MEDIA)
            {
                checkOutCount++;
                return true;
            }
            else
                return false;
        }
    }

    /// <summary>
    /// </summary>
    public enum PatronType
    {
        Child,
        Adult
    }
}