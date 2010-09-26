using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Burtu_spele
{
    public partial class Records : Form
    {
        Form1 F1;
        public Records(Form1 F)
        {
            InitializeComponent();
            F1 = F;
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            F1.Show();
            this.Close();
        }
    }
}