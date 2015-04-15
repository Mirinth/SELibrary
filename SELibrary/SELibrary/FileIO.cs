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
        /// Opens a database file for reading.
        /// </summary>
        /// <param name="path">The path of the file to open.</param>
        /// <returns>An open FileStream, or null on failure.</returns>
        public static FileStream Open(string path)
        {
            FileStream _fileStream = null;

            try
            {
                _fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
            
            // ArgumentNullException should continue since caller should have
            // prevented that.
            // ArgumentOutOfRangeException should be impossible.
            // "Handling" is just leaving _fileStream as null so null
            // gets returned. The caller will figure out what to do
            // about the error.
            catch (IOException) { }
            catch (ArgumentException) { }
            catch (NotSupportedException) { }
            catch (UnauthorizedAccessException) { }
            catch (System.Security.SecurityException) { }

            return _fileStream;
        }

        /// <summary>
        /// Closes a database file.
        /// </summary>
        /// <param name="fs">The file to close.</param>
        public static void Close(FileStream fs)
        {
            if (fs == null)
            {
                return;
            }

            fs.Flush();
            fs.Close();
            fs.Dispose();
        }
        
        /// <summary>
        /// Saves the database to the given path.
        /// </summary>
        /// <param name="fs">The location to store the database in.</param>
        /// <param name="db">The database to store.</param>
        public static void SaveDatabase(FileStream fs, Database db)
        {
            BinaryFormatter _binaryFormat = new BinaryFormatter();

            // Assume _fileStream != null since it should have been
            // prevented by the caller.
            // This can still throw, but only in cases where either
            // the controller should have prevented it or we're
            // not handling. See requirement 2, "Not Handling"
            // section.
            _binaryFormat.Serialize(fs, db);
            
            fs.Flush();
        }

        /// <summary>
        /// Loads the database from the given file.
        /// </summary>
        /// <param name="fs">The file to store the database in.</param>
        /// <returns>The database stored in the file, or null on failure.</returns>
        public static Database LoadDatabase(FileStream fs)
        {
            BinaryFormatter _binaryFormat = new BinaryFormatter();
            Database db = null;

            try
            {
                db = (Database)_binaryFormat.Deserialize(fs);
            }
            // Exceptions are handled by returning null so the caller
            // can decide what to do.
            catch (System.Runtime.Serialization.SerializationException) { }
            catch (InvalidCastException) { }

            return db;
        }
    }
}