using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SELibrary
{
    public partial class FrmMainLibrary : Form, ILibraryUI
    {
        private Controller proControl;

        /// <summary>
        /// Initializes the form.
        /// </summary>
        public FrmMainLibrary()
        {
            // This method is used by the IDE; try not to modify
            // it unless absolutely needed. Use FrmMainLibrary_Load
            // for initialization instead.
            InitializeComponent();
        }

        /// <summary>
        /// Prepares the form for viewing by the user.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void FrmMainLibrary_Load(object sender, EventArgs e)
        {
            proControl = new Controller(this);
        }

        /// <summary>
        /// Passes time
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void BtnDayForward_Click_1(object sender, EventArgs e)
        {
            proControl.PassTime();
        }

        /// <summary>
        /// Updates the form to display no items in its list.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void RdoListNone_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            LstBookList.Items.Add("None");
        }

        /// <summary>
        /// Updates the form to display all items in its list.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void RdoListAll_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            List<Media> allMedia = proControl.ListMedia();
            foreach(Media item in allMedia)
            {
                LstBookList.Items.Add(item.Title.ToString());
            }
        }

        /// <summary>
        /// Updates the form to display all overdue items in its list.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void RdoListOverdue_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            List<Media> overdueMedia = proControl.ListMedia();
            foreach (Media item in overdueMedia)
            {
                LstBookList.Items.Add(item);
            }
        }

        private void RdoListByPatron_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            LstBookList.Items.Add("Patron's Books");
        }

        //Save DB
        private void BtnSaveClose_Click(object sender, EventArgs e)
        {
            proControl.SaveDatabase("Library_Database.bin");
            this.Close();
        }
    }
}
