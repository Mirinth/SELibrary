using System;

namespace SELibrary
{
    /// <summary>
    /// Enumerates media types in the library's collection.
    /// </summary>
    enum MediaType
    {
        Book,
        DVD,
        Video,
    }

    /// <summary>
    /// Enumerates media ratings handled by the library
    /// </summary>
    enum MediaRating
    {
        Everyone,
        Adult
    }

    /// <summary>
    /// Represents a media item in the library.
    /// </summary>
    class Media
    {
        /// <summary>
        /// Gets the media's type.
        /// </summary>
        public MediaType Type
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
        /// Gets whether the media is due at the current time.
        /// Media is never due when the library has it.
        /// </summary>
        public bool IsDue
        {
            get; private set;
        }

        /// <summary>
        /// Gets whether the media is overdue at the current time.
        /// Media is never overdue when the library has it.
        /// </summary>
        public bool IsOverdue
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
        public DateTime Due
        {
            get; private set;
        }

        public Media(MediaType mType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks the media out to a patron.
        /// </summary>
        /// <param name="toPatron">
        /// The ID of the patron to check the media out to.</param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the media is already checked out.
        /// </exception>
        public void CheckOut(uint toPatron)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks the media in to the library.
        /// </summary>
        public void CheckIn()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks whether a patron can check out this media item.
        /// </summary>
        /// <param name="pType">
        /// The most restricted rating the patron can check out.
        /// </param>
        /// <returns>
        /// Whether a patron that can check out the given rating can check out this media.
        /// </returns>
        public bool IsRestricted(MediaRating rating)
        {
            throw new NotImplementedException();
        }
    }
}