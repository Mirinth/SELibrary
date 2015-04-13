using System;

namespace SELibrary
{
    static class UIStrings
    {
        public const string SELECT_PATRON = "Please select a patron from the list.";
        public const string SELECT_ITEM = "Please select an item from the list.";
        public const string ITEM_ALREADY_CHECKED_OUT = "The item was already checked out. Please verify that the " +
            "selected item is the intended one. If it is, check it in so it can be checked out again.";
        public const string ADULT_CHECKOUT_LIMIT_EXCEEDED = "An adult patron's checkout limit was exceeded.";
        public const string CHILD_CHECKOUT_LIMIT_EXCEEDED = "A child patron's checkout limit was exceeded.";
    }
}
