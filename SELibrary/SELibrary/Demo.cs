using System.Windows.Forms;
using System.Collections.Generic;

namespace SELibrary
{
    static class Demo
    {
        public static void Run()
        {
            // the combo box accepts any object, not just strings.
            // if you give it something other than a string, it
            // calls the object's ToString() method to get something
            // to display. because of this...
            ComboBox box = new ComboBox();

            // if you assume this works (or put in a valid file)...
            Controller ctrlr = new Controller(null);
            List<Patron> pList = ctrlr.ListPatrons();
            
            foreach (Patron p in pList)
            {
                // ...you can add patrons to a combo box...
                box.Items.Add(p);
            }

            // ... and pull them back out again.
            Patron chosen = (Patron)box.Items[3];
            MessageBox.Show(
                string.Format(
                    "{0}\n, ID: {1}\n, Birthday: {2}",
                    chosen.Name,
                    chosen.ID,
                    chosen.Birthday));
        }
    }
}