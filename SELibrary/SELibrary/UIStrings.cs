using System;

namespace SELibrary
{
    /// <summary>
    /// Contains strings used by the UI.
    /// </summary>
    static class UIStrings
    {
        public const string SELECT_PATRON = "Please select a patron from the list.";
        public const string SELECT_ITEM = "Please select an item from the list.";
        public const string ITEM_ALREADY_CHECKED_OUT = "The item was already checked out. Please verify that the " +
            "selected item is the intended one. If it is, check it in so it can be checked out again.";
        public const string ADULT_CHECKOUT_LIMIT_EXCEEDED = "An adult patron's checkout limit was exceeded.";
        public const string CHILD_CHECKOUT_LIMIT_EXCEEDED = "A child patron's checkout limit was exceeded.";
        public const string DATABASE_CORRUPTED = "The database could not be loaded because it was corrupted. " +
            "Please use a different database, or reload this one from a backup and try again.";
        public const string FILE_OPEN_FAIL = "The database could not be loaded because the file failed to open. " +
            "Some possible reasons: The file doesn't exist, it is open in a different program, or you don't have " +
            "permission to access it.";
    }
}
