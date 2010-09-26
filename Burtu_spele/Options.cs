using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Burtu_spele
{
    public partial class Form_settings : Form
    {
        Form1 F1;
        public Form_settings(Form1 F)
        {
            InitializeComponent();
            F1 = F;
        }

        private void Form_settings_Load(object sender, EventArgs e)
        {
            F1.Read_Config();
            tb_nick.Text = F1.Nick;
            cb_level.Items.Add("1");
            cb_level.Items.Add("2");
            cb_level.Items.Add("3");
            cb_level.SelectedIndex = F1.level-1;
            cb_sound.Checked = F1.sound;          
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            F1.Nick = tb_nick.Text;
            string tmp = cb_level.Items[cb_level.SelectedIndex].ToString();
            F1.level = Convert.ToInt32(tmp);
            F1.sound = cb_sound.Checked;
            F1.Enabled = true;
            F1.Write_Config();
            this.Close();
        }

        private void Form_settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            F1.Enabled = true;
        }
    }
}