using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SELibrary
{
    /// <summary>
    /// Stores and retrieves the database to/from the disk.
    /// </summary>
    class FileIO
    {
        /// <summary>
        /// Saves the database to the given path.
        /// </summary>
        /// <param name="path">The path to the file to store the database in.</param>
        /// <param name="db">The database to store.</param>
        public void SaveDatabase(string path, Database db)
        {
            FileStream _fileStream;
            BinaryFormatter _binaryFormat;

            _fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            _binaryFormat = new BinaryFormatter();

            _binaryFormat.Serialize(_fileStream, db);

            _fileStream.Flush();
            _fileStream.Close();
        }

        /// <summary>
        /// Loads th database from the given file.
        /// </summary>
        /// <param name="path">The path to the file where th database is stored.</param>
        /// <returns>The database stored in the file, or null on failure.</returns>
        public Database LoadDatabase(string path)
        {
            return null;
        }
    }
}
