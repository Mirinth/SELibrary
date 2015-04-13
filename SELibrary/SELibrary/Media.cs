using System;

namespace SELibrary
{
    /// <summary>
    /// Represents a media item in the library.
    /// </summary>
    [Serializable]
    public class Media
    {
        /// <summary>
        /// The item's unique ID.
        /// </summary>
        public uint ID
        {
            get; private set;
        }

        /// <summary>
        /// Gets the media's rating (e.g. everyone, or adults only).
        /// </summary>
        public MediaRating Rating
        {
            get; private set;
        }

        /// <summary>
        /// Gets the media's type.
        /// </summary>
        public MediaType Type
        {
            get; private set;
        }

        /// <summary>
        /// The title of the work.
        /// </summary>
        public string Title
        {
            get; private set;
        }

        /// <summary>
        /// The author of the work.
        /// </summary>
        public string Author
        {
            get; private set;
        }

        /// <summary>
        /// Gets whether the media is currently loaned out to a patron.
        /// </summary>
        public bool IsBorrowed
        {
            get; private set;
        }

        /// <summary>
        /// Gets the ID of the media's borrower.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the media is not currently checked out.
        /// </exception>
        public uint Borrower
        {
            get; private set;
        }

        /// <summary>
        /// Gets the date the media is due.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the media is not currently checked out.
        /// </exception>
        public DateTime DueDate
        {
            get; private set;
        }

        /// <summary>
        /// Gets whether the media is due at the current time.
        /// Media is never due when the library has it.
        /// </summary>
        public bool IsDue(DateTime curDate)
        {
            if (curDate >= DueDate)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets whether the media is overdue at the current time.
        /// Media is never overdue when the library has it.
        /// </summary>
        public bool IsOverdue(DateTime curDate)
        {
            if (curDate > DueDate)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks the media out to a patron.
        /// </summary>
        /// <param name="toPatron">
        /// The ID of the patron to check the media out to.
        /// </param>
        /// <param name="dueDate">The date the media will be due.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the media is already checked out.
        /// </exception>
        public void CheckOut(uint toPatron, DateTime due)
        {
            IsBorrowed = true;
            Borrower = toPatron;
            DueDate = due;
        }

        /// <summary>
        /// Checks the media in to the library.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the item is already checked in.
        /// </exception>
        public void CheckIn()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a media object.
        /// </summary>
        /// <param name="mType">The type of the media.</param>
        /// <param name="mAuthor">The author of the work.</param>
        /// <param name="mTitle">The title of the work.</param>
        public Media(uint mID, MediaType mType, string mAuthor, string mTitle)
        {
            Type = mType;
            Author = mAuthor;
            Title = mTitle;
            ID = mID;
        }

        /// <summary>
        /// Converts the object to its string representation.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public override string ToString()
        {
            const string TO_STRING_FORMAT = "{0}: {1}, by {2}";
            return string.Format(TO_STRING_FORMAT, ID, Title, Author);
        }
    }

    /// <summary>
    /// Enumerates media types in the library's collection.
    /// </summary>
    public enum MediaType
    {
        Book,
        DVD,
        Video,
    }

    /// <summary>
    /// Enumerates media ratings handled by the library
    /// </summary>
    public enum MediaRating
    {
        Everyone,
        Adult
    }
}