﻿using System;
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
        /// Prompts the user for a database path and returns it.
        /// </summary>
        /// <returns>
        /// The database path selected by the user,
        /// or null if the user cancelled the operation.
        /// </returns>
        public string PromptForFilePath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = UIStrings.LIBRARY_DATABASE_FILTER;
            ofd.Title = UIStrings.LIBRARY_DATABASE_DIALOG_TITLE;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return null;
            }
        }

        #region Event handlers
        /// <summary>
        /// Prepares the form for viewing by the user.
        /// </summary>
        /// <param name="sender">Unused.</param>
        /// <param name="e">Unused.</param>
        private void FrmMainLibrary_Load(object sender, EventArgs e)
        {
            proControl = new Controller(this);
            proControl.LoadDatabase();
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
            if (((RadioButton)sender).Checked == false)
            {
                // don't generate lists for *un*check event
                return;
            }

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
            if (((RadioButton)sender).Checked == false)
            {
                // don't generate lists for *un*check event
                return;
            }

            LstBookList.Items.Clear();
            List<Media> allMedia = proControl.ListMedia();
            foreach(Media item in allMedia)
            {
                LstBookList.Items.Add(item);
            }
        }

        /// <summary>
        /// Updates the form to display all overdue items in its list.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void RdoListOverdue_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
            {
                // don't generate lists for *un*check event
                return;
            }

            LstBookList.Items.Clear();
            List<Media> overdueMedia = proControl.ListOverdueMedia();
            foreach (Media item in overdueMedia)
            {
                LstBookList.Items.Add(item);
            }
        }

        /// <summary>
        /// Updates the form to display all items checked out by the
        /// currently selected patron.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Unused</param>
        private void RdoListByPatron_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
            {
                // don't generate lists for *un*check event
                return;
            }

            LstBookList.Items.Clear();
            List<Media> patronMedia = proControl.ListMediaByPatron((Patron)CBoxPatron.SelectedItem);
            foreach (Media item in patronMedia)
            {
                LstBookList.Items.Add(item);
            }
        }

        /// <summary>
        /// Checks in the currently selected item.
        /// </summary>
        /// <param name="sender">Unused</param>
        /// <param name="e">Also unused</param>
        private void BtnCheckIn_Click(object sender, EventArgs e)
        {
            proControl.CheckIn((Media)CBoxBook.SelectedItem);
        }

        /// <summary>
        /// Checks out the currently selected item to the currently
        /// selected patron.
        /// </summary>
        /// <param name="sender">Unused (as usual)</param>
        /// <param name="e">Unused (surprise!)</param>
        private void BtnCheckOut_Click(object sender, EventArgs e)
        {
            proControl.CheckOut(
                (Media)CBoxBook.SelectedItem,
                (Patron)CBoxPatron.SelectedItem);
        }

        /// <summary>
        /// Saves the database to disk.
        /// </summary>
        /// <param name="sender">Unused (but more than usual)</param>
        /// <param name="e">Unused (but less than usual)</param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            proControl.SaveDatabase();
            this.Close();
        }
        /// <summary>
        /// Clears any errors currently on display.
        /// </summary>
        public void ClearErrors()
        {
            EProvReport.Clear();
        }

        /// <summary>
        /// Notifies the user that a null patron was encountered.
        /// </summary>
        public void ReportPatronWasNull()
        {
            // Null patrons usually happen because the user typed in
            // a name that doesn't exist in the combo box. Selecting
            // a name from the combo box should fix the issue.
            EProvReport.SetError(CBoxPatron, UIStrings.SELECT_PATRON);
        }

        /// <summary>
        /// Notifies the user that a null item was encountered.
        /// </summary>
        public void ReportItemWasNull()
        {
            // Null items usually happen because the user typed in
            // a name that doesn't exist in the combo box. Selecting
            // a name from the combo box should fix the issue.
            EProvReport.SetError(CBoxBook, UIStrings.SELECT_ITEM);
        }

        /// <summary>
        /// Updates the currently displayed date.
        /// </summary>
        /// <param name="newDate"></param>
        public void ReportDateChanged(DateTime newDate)
        {
            TxtDate.Text = newDate.ToShortDateString();
        }

        /// <summary>
        /// Notifies the user that an item was already checked in.
        /// </summary>
        /// <param name="item">The item that was already checked out.</param>
        public void ReportItemAlreadyCheckedIn(Media item)
        {
            EProvReport.SetError(CBoxBook, UIStrings.ITEM_ALREADY_CHECKED_IN);
        }

        /// <summary>
        /// Notifies the user that an item was already checked out.
        /// </summary>
        /// <param name="item">The item that was already checked out.</param>
        public void ReportItemAlreadyCheckedOut(Media item)
        {
            EProvReport.SetError(CBoxBook, UIStrings.ITEM_ALREADY_CHECKED_OUT);
        }

        /// <summary>
        /// Notifies the user that an adult's checkout limit was exceeded.
        /// </summary>
        /// <param name="item">The item that exceeded the limit.</param>
        /// <param name="borrower">The patron whose limit was exceeded.</param>
        public void ReportAdultCheckoutsExceeded(Media item, Patron borrower)
        {
            EProvReport.SetError(CBoxPatron, UIStrings.ADULT_CHECKOUT_LIMIT_EXCEEDED);
        }

        /// <summary>
        /// Notifies the user that a child's checkout limit was exceeded.
        /// </summary>
        /// <param name="item">The item that exceeded the limit.</param>
        /// <param name="borrower">The patron whose limit was exceeded.</param>
        public void ReportChildCheckoutsExceeded(Media item, Patron borrower)
        {
            EProvReport.SetError(CBoxPatron, UIStrings.CHILD_CHECKOUT_LIMIT_EXCEEDED);
        }

        /// <summary>
        /// Notifies the user that the selected database was corrupted.
        /// </summary>
        public void ReportCorruptedDatabase()
        {
            MessageBox.Show(UIStrings.DATABASE_CORRUPTED);
        }

        /// <summary>
        /// Notifies the user that a file faild to open.
        /// </summary>
        public void ReportFileOpenFail()
        {
            MessageBox.Show(UIStrings.FILE_OPEN_FAIL);
        }

        /// <summary>
        /// Updates the UI to reflect a new database.
        /// </summary>
        public void ReportDatabaseChanged()
        {
            CBoxBook.Items.Clear();
            foreach (Media med in proControl.ListMedia())
            {
                CBoxBook.Items.Add(med);
            }

            CBoxPatron.Items.Clear();
            foreach (Patron pat in proControl.ListPatrons())
            {
                CBoxPatron.Items.Add(pat);
            }

            RdoListNone.Checked = true;
        }

        /// <summary>
        /// Notifies the user that a patron attempted to check out an
        /// item that the patron doesn't have permission to check out.
        /// </summary>
        public void ReportRatingRestrictionViolation()
        {
            EProvReport.SetError(CBoxPatron, UIStrings.RATING_RESTRICTION);
        }
        #endregion
    }
}
