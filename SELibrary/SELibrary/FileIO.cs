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
        /// <param name="ui">A user interface to report errors to.</param>
        /// <param name="path">The path to the file to store the database in.</param>
        /// <param name="db">The database to store.</param>
        public static void SaveDatabase(ILibraryUI ui, string path, Database db)
        {
            FileStream _fileStream = null;
            BinaryFormatter _binaryFormat;

            try
            {
                _fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            }
            // let ArgumentNullException rise since Controller should have
            // prevented that

            // ArgumentOutOfRangeException should be impossible
            catch (IOException)
            {
                ui.ReportBadFilePath();
                return;
            }
            catch (ArgumentException)
            {
                ui.ReportBadFilePath();
                return;
            }
            catch (NotSupportedException)
            {
                ui.ReportBadFilePath();
                return;
            }
            catch (UnauthorizedAccessException)
            {
                ui.ReportBadFilePath();
                return;
            }
            catch (System.Security.SecurityException)
            {
                ui.ReportBadFilePath();
                return;
            }

            _binaryFormat = new BinaryFormatter();

            // Assume _fileStream != null since it should have been
            // assigned above if an exception wasn't thrown.
            // This can still throw, but only in cases where either
            // the controller should have prevented it or there isn't
            // much that can be done about the situation.
            _binaryFormat.Serialize(_fileStream, db);
            
            _fileStream.Flush();
            _fileStream.Close();
        }

        /// <summary>
        /// Loads the database from the given file.
        /// </summary>
        /// <param name="ui">A user interface to report errors to.</param>
        /// <param name="path">The path to the file where th database is stored.</param>
        /// <returns>The database stored in the file, or null on failure.</returns>
        public static Database LoadDatabase(ILibraryUI ui, string path)
        {
            FileStream _fileStream = null;
            BinaryFormatter _binaryFormat;

            try
            {
                _fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            }
            // let ArgumentNullException rise since Controller should have
            // prevented that

            // ArgumentOutOfRangeException should be impossible
            catch (IOException)
            {
                ui.ReportBadFilePath();
                return null;
            }
            catch (ArgumentException)
            {
                ui.ReportBadFilePath();
                return null;
            }
            catch (NotSupportedException)
            {
                ui.ReportBadFilePath();
                return null;
            }
            catch (UnauthorizedAccessException)
            {
                ui.ReportBadFilePath();
                return null;
            }
            catch (System.Security.SecurityException)
            {
                ui.ReportBadFilePath();
                return null;
            }

            _binaryFormat = new BinaryFormatter();

            try
            {
                Database db = (Database)_binaryFormat.Deserialize(_fileStream);
                return db;
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                ui.ReportCorruptedDatabase();
                return null;
            }
            finally
            {
                _fileStream.Flush();
                _fileStream.Close();
            }
        }
    }
}