using System;
using System.Collections.Generic;

namespace SELibrary.Integration
{
    static class TestRunner
    {
        /*
        Requirement 1:
        - The book data is stored in a file (poor man’s database).
        Tests:
        - This is covered by the tests for requirements 2 and 3.
        Non-tests:
        - The specific format of the file will not be tested. As long the data can be accurately stored and retrieved, the format doesn't matter.
        */
        
        /*
        Requirement 2:
        - When the program starts, it reads the data from the file.
        - - Allow the user to select the file name.
        Tests:
        - Does the program ask for a file name when first started?
        - Does the program accept the file name given by the user (not ignoring it)?
        - - Does the program reject non-database files?
        - - Does the program reject nonexistent files?
        - - Does the program reject corrupted files?
        - - Does the program reject inaccessible files?
        - - Does the program reject illegal path names, like "Path<Contains|Bad}Chars"?
        - Does the program fail gracefully if the database is rejected?
        - - Does the program display an error message?
        - - Does the program request a different database on failure?
        - Is the data loaded from the file the same as what was stored?
        Not testing:
        - Changing file permissions while reading
        - Deleting the file while reading
        - Modifying the file while reading

        Requirement 3:
        - When the program exits, it writes the data back out to the file.
        Tests:
        - Is the database file updated when the program exits?
        - Will the tests for requirement 2 pass for the written file?
        - Does the program fail gracefully if the database is deleted between loading and saving?
        - - Does it display an error message?

        Requirement 4:
        - Checkout times:
        - - Adult books can be checked out for 2 weeks
        - - Children's books can be checked out for 1 week
        - All DVDs can be checked out for 2 days
        - All videos can be checked out for 3 days
        Tests:
        - Does the program check out adult books for exactly 2 weeks?
        - Does the program check out children's books for exactly 1 week?
        - Does the program check out DVDs for exactly 2 days?
        - Does the program check out videos for exactly 3 days?

        Requirement 5:
        - Checkout quantities:
        - - Adults can check out up to 6 books at a time
        - - Children can check out up to 3 books at a time
        Tests:
        - Will the program check out up to 6 items to an adult?
        - Will the program refuse to check out 7 or more items to an adult?
        - Will the program check out up to 3 items to a child?
        - Will the program refuse to check out 4 or more items to a child?

        Requirement 6:
        - Adults and children may check books out and check them back in.
        Tests:
        - Tests covered by requirements 5 & 6.

        Requirement 7:
        - The user is displayed a list of available patrons and media to choose from while checking items in and out.
        Tests:
        - Is the list of media visible to the user?
        - Is the list of media accurate?
        - Is the list of patrons visible to the user?
        - Is the list of patrons accurate?

        Requirement 8:
        - Checked out items may not be checked out ("duh")
        Tests:
        - Will the program refuse to check out an item that is already checked out?
        - Will the program allow the item to be checked out again once it's checked in?

        Requirement 9:
        - The user can view a list of all items and their status.
        Tests:
        - Can the user view a list of all items?
        - Does the list include the status of each items?
        - Is the list accurate?
        - Is the list complete?
        - Is it easy to find out how to generate the list?

        Requirement 10:
        - The user can view a list of all overdue items
        Tests:
        - Can the user view a list of all overdue items?
        - Is the list accurate (no non-overdue items)?
        - Is the list complete?
        - Is it easy to find out how to generate the list?
        - Will the program work correctly if there are no overdue items?

        Requirement 11:
        - The user can view a list of all items checked out to a specific patron
        Tests:
        - Can the user view a list of all books loaned to a specific patron?
        - Is the list accurate (no items checked out to other patrons included)?
        - Is the list complete?
        - Is it easy to find out how to generate the list?
        - Will the program work correctly if a patron has no items?

        Requirement 12:
        - Allow the date to be advanced, one day at a time, to simulate time passing.
        Tests:
        - Can the date be advanced?
        - Does the date advance exactly 1 day at a time?
        - Does the new date affect other time-sensitive features?

        Requirement 13:
        - The user might appreciate if the interface was usable.
        Tests:
        - Are error messages easy to understand, accurate, and descriptive?
        - Given an arbitrary patron at the counter or media item in hand, can the user easily locate the correct patron or media in the lists?
        - Is it clear what the various media lists are and how to generate them?
        - Is it clear what the various drop-down menus are for?
        - - e.g. is it clear that the list of patrons is a list of patrons?
        - Is it clear what the buttons do?
        - Does the program say when lists are empty? The user might otherwise assume the program failed somehow when presented with an empty list.
        - Is it easy to figure out how to check items out and back in?
        - Scenario: The user wants to check out item 10098_8_987332, and accidentally types 10098_9_987332. The program informs the user that the item is already checked out. The user assumes the item simply failed to check in, instructs the program to check it back in and then out to the new patron. The old patron now has a free book and the new one is stuck paying for it. Will the program assist the librarian in preventing this situation?

        Requirement 14:
        - The program should handle multiple patrons with the same name and age, because it's only a matter of time until two people like that show up.
        Tests:
        - Give it a database with duplicate patrons.

        Requirement 15:
        - If the library is going to have multiple copies of popular items, it will need to handle duplicates.
        Tests:
        - Give it a database with duplicate media items.

        Requirement 16:
        - Graceful shutdown. Requirement 3 needs this.
        Tests:
        - Will the program close gracefully when the close button is clicked?

        Requirement 17:
        - Rating restrictions:
        - - Adults can check out any item (subject to quantity rules)
        - - Children can only check out children's items (subject to quantity rules)
        Tests:
        - Can adults check out adult items?
        - Can adults check out children's items?
        - Can children check out children's items?
        - Will the program refuse to check out adult items to children?

        Requirement 18:
        - Input validation
        Tests:
        - Will the program fail gracefully if given a patron or media item that doesn't exist?
        - Will the program work correctly if the user opens it up and immediately starts clicking buttons without entering any input?
        - Is an error message displayed?

        Requirement 19:
        - The program can distinguish between children and adults (needed by other requirements that differ between children/adults)
        Tests:
        - Will the program treat patrons below the child limit as children?
        - Will the program treat patrons above th child limit as adults?
*/
    }
}