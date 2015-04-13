using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


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
            FileStream _fileStream;
            BinaryFormatter _binaryFormat;

            _fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            _binaryFormat = new BinaryFormatter();

            _binaryFormat.Serialize(_fileStream, db);

            _fileStream.Flush();
            _fileStream.Close();
        }

        /// <summary>
        /// Loads the database from the given file.
        /// </summary>
        /// <param name="path">The path to the file where th database is stored.</param>
        /// <returns>The database stored in the file, or null on failure.</returns>
        public static Database LoadDatabase(string path)
        {
            FileStream _fileStream;
            BinaryFormatter _binaryFormat;

            _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            _binaryFormat = new BinaryFormatter();

            Database db = (Database)_binaryFormat.Deserialize(_fileStream);

            _fileStream.Flush();
            _fileStream.Close();
            return db;
        }
    }
}