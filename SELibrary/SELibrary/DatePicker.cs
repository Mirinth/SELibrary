using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELibrary
{
    class DatePicker
    {
        private string date = "";
        public DatePicker(){date=DateTime.Now.ToString("M/d");}

        public string DatSimulator() { return date = DateTime.Now.ToString("M/d");}
        public void DecrementDat() {
            if (Convert.ToInt32(date.Substring(0, date.IndexOf("/"))) < 1)
                date = "30/" + (Convert.ToInt32(date.Substring(date.IndexOf("/") + 1)) - 1);
            else
                date = "" + (Convert.ToInt32(date.Substring(0, date.IndexOf("/"))) - 1) + date.Substring(date.IndexOf("/"));
        }

        public string GetDate() { return date; }

        public void incrementDat()
        {
            if (Convert.ToInt32(date.Substring(0, date.IndexOf("/"))) >= 30)
                date = "1/" + (Convert.ToInt32(date.Substring(date.IndexOf("/") + 1)) +1);
            else
                date = "" + (Convert.ToInt32(date.Substring(0, date.IndexOf("/"))) + 1) + date.Substring(date.IndexOf("/"));
        }
    }
}
