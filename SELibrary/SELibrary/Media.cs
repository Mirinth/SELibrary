using System;

namespace SELibrary
{
    /// <summary>
    /// Represents a media item in the library.
    /// </summary>
    public class Media
    {
        private uint mediaId;
        private MediaRating mediaRating;
        private MediaType mediaType;
        private string title;
        private string author;
        private bool isBorrowed;
        private uint borrowerId;
        private DateTime dueDate;
        private bool isDue;
        private bool isOverDue;

        /// <summary>
        /// The item's unique ID.
        /// </summary>
        public uint ID
        {
            get { return mediaId; }
        }

        /// <summary>
        /// Gets the media's rating (e.g. everyone, or adults only).
        /// </summary>
        public MediaRating Rating
        {
            get { return mediaRating; }
        }

        /// <summary>
        /// Gets the media's type.
        /// </summary>
        public MediaType Type
        {
            get { return mediaType; }
        }

        /// <summary>
        /// The title of the work.
        /// </summary>
        public string Title
        {
            get { return title; }
        }

        /// <summary>
        /// The author of the work.
        /// </summary>
        public string Author
        {
            get { return author; }
        }

        /// <summary>
        /// Gets whether the media is currently loaned out to a patron.
        /// </summary>
        public bool IsBorrowed
        {
            get { return isBorrowed; }
            set { isBorrowed = value; }
        }

        /// <summary>
        /// Gets the ID of the media's borrower.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the media is not currently checked out.
        /// </exception>
        public uint Borrower
        {
            get { return borrowerId; }
            set { borrowerId = value; }
        }

        /// <summary>
        /// Gets the date the media is due.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the media is not currently checked out.
        /// </exception>
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        /// <summary>
        /// Gets whether the media is due at the current time.
        /// Media is never due when the library has it.
        /// </summary>
        public bool SetIsDue(DateTime curDate)
        {
            if (curDate.Day == DueDate.Day)
                return true;
            else
                return false;
        }

        public bool IsDue
        {
            get { return isDue; }
        }

        /// <summary>
        /// Gets whether the media is overdue at the current time.
        /// Media is never overdue when the library has it.
        /// </summary>
        public bool SetIsOverdue(DateTime curDate)
        {
            if (curDate.Day < DueDate.Day)
                return true;
            else
                return false;
        }

        public bool IsOverdue
        {
            get { return isOverDue; }
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
        public void CheckOut(uint toPatron, DateTime dueDate)
        {
            throw new NotImplementedException();
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
            mediaType = mType;
            author = mAuthor;
            title = mTitle;
            mediaId = mID;
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