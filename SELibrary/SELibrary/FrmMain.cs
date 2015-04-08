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
        private Controller proControl = new Controller("Library_Database.txt");

        public FrmMainLibrary()
        {
            InitializeComponent();
        }

        private void FrmMainLibrary_Load(object sender, EventArgs e)
        {
            proControl.CurrentDate = DateTime.Today;
            TxtDate.Text = proControl.CurrentDate.ToShortDateString();
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
            LstBookList.Items.Add("All");
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
