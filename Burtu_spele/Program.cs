using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Burtu_spele
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool need = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                need = false;
                Application.Run(new Form1(args));
            }
            else {
                need = true;
                Application.Run(new Intro_Form());
            }
            if (need)
            {
                Application.Run(new Form1(args));
            }
        }
    }
}