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
        /// Prompts the user for a file path to load the database from.
        /// </summary>
        /// <returns>
        /// The file path chosen by the user, or null if the
        /// user cancelled the operation.
        /// </returns>
        string PromptForFilePath();

        /// <summary>
        /// Closes the program.
        /// </summary>
        void Close();

        /// <summary>
        /// Clears any errors currently on display in the UI.
        /// </summary>
        void ClearErrors();

        /// <summary>
        /// Notifies the UI that the date has been changed.
        /// </summary>
        /// <param name="newDate">The new date.</param>
        void ReportDateChanged(DateTime newDate);

        /// <summary>
        /// Notifies the UI that an item was already checked in.
        /// </summary>
        void ReportItemAlreadyCheckedIn(Media item);

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

        /// <summary>
        /// Notifies the UI that the database file was corrupted.
        /// </summary>
        void ReportCorruptedDatabase();

        /// <summary>
        /// Notifies the UI that a file failed to open.
        /// </summary>
        void ReportFileOpenFail();

        /// <summary>
        /// Notifies the UI that the database changed.
        /// </summary>
        void ReportDatabaseChanged();

        /// <summary>
        /// Notifies the UI that a patron attempted to check out an
        /// item that the patron doesn't have permission to check out.
        /// </summary>
        void ReportRatingRestrictionViolation();
    }
}