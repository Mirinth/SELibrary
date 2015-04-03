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
        public FrmMainLibrary()
        {
            InitializeComponent();
        }
        private DatePicker date= new DatePicker();
        private void BtnDayForward_Click(object sender, EventArgs e)
        {
            date.incrementDat();
            TxtDate.Text = date.GetDate();
        }
    }
}
