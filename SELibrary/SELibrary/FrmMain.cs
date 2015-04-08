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
    public partial class FrmMainLibrary : Form
    {
        private Controller proControl = new Controller("Library_Database.bin");

        public FrmMainLibrary()
        {
            InitializeComponent();
        }

        //Open DB
        private void FrmMainLibrary_Load(object sender, EventArgs e)
        {
            //proControl.CurrentDate = DateTime.Today;
            TxtDate.Text = proControl.CurrentDate.ToShortDateString();
        }

        //Save DB
        private void BtnSaveClose_Click(object sender, EventArgs e)
        {
            proControl.SaveDB("Library_Database.bin");
            this.Close();
        }

        private void BtnDayForward_Click_1(object sender, EventArgs e)
        {
            proControl.CurrentDate = proControl.CurrentDate.AddDays(1);
            TxtDate.Text = proControl.CurrentDate.ToShortDateString();
        }

        private void RdoListNone_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            LstBookList.Items.Add("None");
        }

        private void RdoListAll_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            List<Media> allMedia = proControl.ListMedia();
            foreach(Media item in allMedia)
            {
                LstBookList.Items.Add(item.Title.ToString());
            }
        }

        private void RdoListOverdue_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            LstBookList.Items.Add("OverDue");
        }

        private void RdoListByPatron_CheckedChanged(object sender, EventArgs e)
        {
            LstBookList.Items.Clear();
            LstBookList.Items.Add("Patron's Books");
        }
    }
}
