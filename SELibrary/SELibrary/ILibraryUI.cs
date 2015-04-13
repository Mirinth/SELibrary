using System;

namespace SELibrary
{
    /// <summary>
    /// The interface to a UI that the various back-end
    /// classes expect to interact with.
    /// </summary>
    interface ILibraryUI
    {
        /// <summary>
        /// Notifies the UI that the date has been changed.
        /// </summary>
        /// <param name="newDate">The new date.</param>
        void ReportDateChanged(DateTime newDate);

        /// <summary>
        /// Notifies the UI that an item failed to be checked
        /// out because it was already checked out.
        /// </summary>
        /// <param name="item">The item that failed to be checked out.</param>
        void ReportItemAlreadyCheckedOut(Media item);

        /// <summary>
        /// Notifies the UI that an item failed to be checked
        /// out because an adult's checkout count was exceeded.
        /// </summary>
        /// <param name="item">The item that failed to be checked out.</param>
        /// <param name="borrower">The patron who tried to borrow the item.</param>
        void ReportAdultCheckoutsExceeded(Media item, Patron borrower);

        /// <summary>
        /// Notifies the UI that an item failed to be checked
        /// out because a child's checkout count was exceeded.
        /// </summary>
        /// <param name="item">The item that failed to be checked out.</param>
        /// <param name="borrower">The patron who tried to borrow the item.</param>
        void ReportChildCheckoutsExceeded(Media item, Patron borrower);

        /// <summary>
        /// Notifies the UI that a null item was encountered.
        /// </summary>
        void ReportItemWasNull();

        /// <summary>
        /// Notifies the UI that a null item was encountered.
        /// </summary>
        void ReportPatronWasNull();
    }
}