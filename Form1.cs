using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace EZAudioSwitcher
{
    public partial class Form1 : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static string LocalLowPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
        public string GameSavePath = LocalLowPath + "\\ZeekerssRBLX\\Lethal Company\\";
        public static string DefaultSaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LCSM\\GameBackups\\";
        public string CustomBackupDirectory = DefaultSaveDirectory;
        public static Dictionary<string, string> saveMap = new Dictionary<string, string>();

        public static string Save1 = "LCSaveFile1";
        public static string Save2 = "LCSaveFile2";
        public static string Save3 = "LCSaveFile3";



        public Form1()
        {
            InitializeComponent();
            
        }


        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // thisNotifyIcon.Click += ThisNotifyIcon_Click;
            this.FormBorderStyle = FormBorderStyle.None;
            System.IO.Directory.CreateDirectory(DefaultSaveDirectory);

            saveMap.Add("Save 1", Save1);
            saveMap.Add("Save 2", Save2);
            saveMap.Add("Save 3", Save3);

            // game save drop box
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Save 1");
            comboBox1.Items.Add("Save 2");
            comboBox1.Items.Add("Save 3");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            // backups drop box
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            PopulateBackups();

            


        }

        private void PopulateBackups()
        {
            comboBox2.Items.Clear();
            Directory.GetFiles(CustomBackupDirectory);
            foreach(string item in Directory.GetFiles(CustomBackupDirectory))
            {
                //System.IO.Path.GetFileName(item);
                comboBox2.Items.Add(System.IO.Path.GetFileName(item));
            }

            try
            {
                comboBox2.SelectedIndex = 0;
            }
            catch
            {
                comboBox2.Text = "No Backups...";
            }

        }

        #region WindowMods


        private void QuitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void MinimizeToTray_Click(object sender, EventArgs e)
        {
            thisNotifyIcon.Visible = true;
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            // delete game save file
            MessageBoxResult confirmResult = System.Windows.MessageBox.Show("Are you sure to delete this item? If it's not backed up, this may not be reversible.", "Confirm Delete!!", MessageBoxButton.YesNo);

            if (confirmResult == MessageBoxResult.Yes)
            {
                File.Delete(GameSavePath + saveMap[comboBox1.SelectedItem.ToString()]);
                comboBox1.SelectedIndex = 0;
                statusLabel.Text = "Success!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                statusLabel.Text = "Not deleted.";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // back up to local save folder
            // create new backup
            string backupName = "";


            for (int i = 0; i < 21; i++)
            {
                if(!File.Exists(CustomBackupDirectory + "LCBackup" + i.ToString()))
                {
                    backupName = CustomBackupDirectory + "LCBackup" + i.ToString();
                    break;
                }
            }
            if(backupName == "")
            {
                statusLabel.Text = "Too many backups";
                statusLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                try
                {
                    File.Copy(GameSavePath + saveMap[comboBox1.SelectedItem.ToString()], backupName);
                    statusLabel.Text = "Backed up!";
                    statusLabel.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    statusLabel.Text = "Could not back up, invalid save.";
                    statusLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            PopulateBackups();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string selectedFile = CustomBackupDirectory + comboBox2.SelectedItem;
            if (File.Exists(selectedFile))
            {
                File.Delete(selectedFile);
                statusLabel.Text = "Deleted backup!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
            PopulateBackups();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedBackup = CustomBackupDirectory + comboBox2.SelectedItem;
            string selectedSave = GameSavePath + saveMap[comboBox1.SelectedItem.ToString()];
            Console.WriteLine(selectedSave);

            if (File.Exists(selectedBackup))
            {
                File.Delete(selectedSave);
                File.Copy(selectedBackup, selectedSave);
                statusLabel.Text = "Loaded backup!";
                statusLabel.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveLastModified.Text = File.GetLastAccessTime(GameSavePath + saveMap[comboBox1.SelectedItem.ToString()]).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            backupLastModified.Text = File.GetLastAccessTime(CustomBackupDirectory + comboBox2.SelectedItem).ToString();
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
