using System;

namespace SELibrary
{
    /// <summary>
    /// Stores and retrieves the database to/from the disk.
    /// </summary>
    static class FileIO
    {
        /// <summary>
        /// Saves the database to the given path.
        /// </summary>
        /// <param name="path">The path to the file to store the database in.</param>
        /// <param name="db">The database to store.</param>
        public static void SaveDatabase(string path, Database db)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads th database from the given file.
        /// </summary>
        /// <param name="path">The path to the file where th database is stored.</param>
        /// <returns>The database stored in the file, or null on failure.</returns>
        public static Database LoadDatabase(string path)
        {
            throw new NotImplementedException();
        }
    }
}
