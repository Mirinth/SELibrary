using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace SELibrary
{
    class FileIO
    {
        private FileStream _fileStream;
        private SaveFileDialog saveDlg;
        private OpenFileDialog openDlg;
        private string filePath;

        public FileIO()
        {
            _fileStream = null;
            filePath = null;
        }

        internal Patron Patron
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal Media Media
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        //Opens The Save Stream
        public void SaveStream()
        {

        }

        //Opens The Open Stream
        public void OpenStream()
        {

        }

        //Reads in a patron Database
        public List<Patron> ReadPatrons()
        {
            return null;
        }

        //Writes out a patron Database
        public void WritePatrons(List<Patron> allPatrons)
        {

        }

        //Reads in a media database
        public List<Media> ReadMedia()
        {
            return null;
        }

        //Writes out a media database
        public void WriteMedia(List<Media> allMedia)
        {

        }

        //Closes the Steam
        public void CloseStream()
        {

        }
    }
}
