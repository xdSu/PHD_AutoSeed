using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace PHD_AutoSeed
{
    public partial class FrmSettings : Form
    {
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath); 

        public FrmSettings()
        {
            InitializeComponent();
            //PostSeed("a.torrent", "E:\\Seedbox\\b.torrent", "", "name=AutoSeed2&descr=AutoSeed&type=404");
            LoadConfig();
            
        }

        private void LoadConfig()
        {
            if (File.Exists("config.ini"))
            {
                StringBuilder sb = new StringBuilder(65535);
                GetPrivateProfileString("Cookies", "c_secure_uid", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                txt_uid.Text = sb.ToString();
                GetPrivateProfileString("Cookies", "c_secure_login", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                txt_login.Text = sb.ToString();
                GetPrivateProfileString("Cookies", "c_secure_pass", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                txt_pass.Text = sb.ToString();
                GetPrivateProfileString("Cookies", "anonymous", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                if (sb.ToString() != "1")
                    chbAnonymous.Checked = false;
                else
                    chbAnonymous.Checked = true;
                GetPrivateProfileString("Cookies", "website", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                txtWebsite.Text = sb.ToString();
                //GetPrivateProfileString("Torrents", "passkey", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                //passkey = sb.ToString();
                GetPrivateProfileString("Torrents", "watch", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                lstWatch.Items.Clear();
                foreach (string s in sb.ToString().Split(';'))
                    if (s != "")
                        lstWatch.Items.Add(s);
                GetPrivateProfileString("Torrents", "torrents", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                txtTorrents.Text = sb.ToString();
                GetPrivateProfileString("Torrents", "download", "", sb, 65535, Environment.CurrentDirectory + "\\config.ini");
                txtDownload.Text = sb.ToString();
            }
            else
                MessageBox.Show("cofing.ini WAS NOT FOUND");
        }

        private void SaveConfig()
        {
            WritePrivateProfileString("Cookies", "c_secure_uid", txt_uid.Text, Environment.CurrentDirectory + "\\config.ini");
            WritePrivateProfileString("Cookies", "c_secure_login", txt_login.Text, Environment.CurrentDirectory + "\\config.ini");
            WritePrivateProfileString("Cookies", "c_secure_pass", txt_pass.Text, Environment.CurrentDirectory + "\\config.ini");
            WritePrivateProfileString("Cookies", "website", txtWebsite.Text, Environment.CurrentDirectory + "\\config.ini");
            WritePrivateProfileString("Torrents", "torrents", txtTorrents.Text, Environment.CurrentDirectory + "\\config.ini");
            WritePrivateProfileString("Torrents", "download", txtDownload.Text, Environment.CurrentDirectory + "\\config.ini");
            if (chbAnonymous.Checked)
                WritePrivateProfileString("Cookies", "anonymous", "1", Environment.CurrentDirectory + "\\config.ini");
            else
                WritePrivateProfileString("Cookies", "anonymous", "0", Environment.CurrentDirectory + "\\config.ini");
            string watch = "";
            foreach (object item in lstWatch.Items)
            {
                watch += item.ToString() + ";";
            }
            WritePrivateProfileString("Torrents", "watch", watch, Environment.CurrentDirectory + "\\config.ini");
            
        }

        private void btnAddWatch_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            lstWatch.Items.Add(folderBrowserDialog1.SelectedPath);
        }

        private void btnRemoveWatch_Click(object sender, EventArgs e)
        {
            if (lstWatch.SelectedIndex >=0)
                lstWatch.Items.RemoveAt(lstWatch.SelectedIndex);
        }

        private void btnTorrents_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtTorrents.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDownload.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfig();
            PHDWatch.LoadConfig();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadConfig();
        }
    }
}
