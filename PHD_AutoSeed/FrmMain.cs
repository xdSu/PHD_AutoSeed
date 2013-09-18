using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace PHD_AutoSeed
{
    public partial class FrmMain : Form
    {
        PHDWatch phd;
        

        public FrmMain()
        {
            InitializeComponent();
        }

        

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.notifyIcon1.Visible = true;
            //PHDWatch.LoadConfig();
            phd = new PHDWatch();
            phd.Start();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            mnuMain.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            (new FrmSettings()).Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            phd.Quit();
            Application.Exit();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            switch (btnControl.Text)
            {
                case "Pause":
                    phd.Quit();
                    btnControl.Text = "Start";
                    break;
                case "Start":
                    phd.Start();
                    btnControl.Text = "Pause";
                    break;
            }

        }
    }
}
