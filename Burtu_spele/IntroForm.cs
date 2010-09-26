using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Burtu_spele
{
    public partial class Intro_Form : Form
    {

        public Intro_Form()
        {
            InitializeComponent();

        }

        private void Intro_Form_Load(object sender, EventArgs e)
        {


            this.BackgroundImage = Image.FromFile("img/Intro.jpg");
        }

        private void Intro_Form_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}