using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
        public static string PlayerSave = "LCGeneralSaveData";

        public string currentSaveData;

        // attributes of the save files, do not modify unless the savedata changes
        public static string Credits = "GroupCredits";
        public static string Deaths = "Stats_Deaths";
        public static string PlanetSeed = "RandomSeed";
        public static string Deadline = "DeadlineTime";
        public static string Planet = "CurrentPlanetID";
        public static string Quota = "ProfitQuota";
        public static string QuotasPassed = "QuotasPassed";
        public static string QuotaFulfilled = "QuoatFulfilled"; // not sure what this one is
        public static string Time = "GlobalTime";


        public string coinCount = "10000";
        public string deathCount = "0";
        public string seed = "10000";
        public string timeLeft = "10000";
        public string planetID = "1";
        public string quotaAmount = "0";
        public string quotas = "10000";
        public string fulfilledQuota = "0";
        public string globalTime = "37";


        // do not edit
        public static string Password = "lcslime14a5";
        public bool decryptionStatus = false;



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

        private string Decrypt(string password, byte[] data)
        {
            byte[] IV = new byte[16];
            Array.Copy(data, IV, 16);
            byte[] dataToDecrypt = new byte[data.Length - 16];
            Array.Copy(data, 16, dataToDecrypt, 0, dataToDecrypt.Length);

            using (Rfc2898DeriveBytes k2 = new Rfc2898DeriveBytes(password, IV, 100, HashAlgorithmName.SHA1))
            using (Aes decAlg = Aes.Create())
            {
                decAlg.Mode = CipherMode.CBC;
                decAlg.Padding = PaddingMode.PKCS7;
                decAlg.Key = k2.GetBytes(16);
                decAlg.IV = IV;

                using (MemoryStream decryptionStreamBacking = new MemoryStream())
                using (CryptoStream decrypt = new CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    decrypt.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    decrypt.FlushFinalBlock();

                    return new UTF8Encoding(true).GetString(decryptionStreamBacking.ToArray());
                }
            }
        }

        private byte[] Encrypt(string password, string data)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                aesAlg.KeySize = 128;

                // Generate a random IV
                aesAlg.GenerateIV();

                using (Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, aesAlg.IV, 100, HashAlgorithmName.SHA1))
                {
                    aesAlg.Key = keyDerivation.GetBytes(16); // 128-bit key

                    using (MemoryStream encryptedStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(encryptedStream, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                            cryptoStream.Write(dataBytes, 0, dataBytes.Length);
                        }

                        byte[] iv = aesAlg.IV; // Get IV
                        byte[] encryptedData = encryptedStream.ToArray(); // Get encrypted data

                        // Combine IV and encrypted data
                        byte[] ivAndEncryptedData = new byte[iv.Length + encryptedData.Length];
                        Array.Copy(iv, 0, ivAndEncryptedData, 0, iv.Length);
                        Array.Copy(encryptedData, 0, ivAndEncryptedData, iv.Length, encryptedData.Length);

                        return ivAndEncryptedData;
                    }
                }
            }
        }


        private void PopulateBackups()
        {
            comboBox2.Items.Clear();
            Directory.GetFiles(CustomBackupDirectory);
            foreach (string item in Directory.GetFiles(CustomBackupDirectory))
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

            if (decryptionStatus)
            {
                MessageBoxResult confirmResult = System.Windows.MessageBox.Show("You have a backup open, are you sure you'd like to quit?", "Confirm Close", MessageBoxButton.YesNo);
                if (confirmResult == MessageBoxResult.Yes)
                {
                    File.WriteAllBytes(CustomBackupDirectory + comboBox2.SelectedItem, Encrypt(Password, currentSaveData));
                    System.Windows.Forms.Application.Exit();
                }
            }
            else
            {
                System.Windows.Forms.Application.Exit();
            }
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
                if (!File.Exists(CustomBackupDirectory + "LCBackup" + i.ToString()))
                {
                    backupName = CustomBackupDirectory + "LCBackup" + i.ToString();
                    break;
                }
            }
            if (backupName == "")
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

            if (File.Exists(selectedBackup))
            {
                File.Delete(selectedSave);
                File.Copy(selectedBackup, selectedSave);
                statusLabel.Text = "Loaded backup!";
                statusLabel.ForeColor = System.Drawing.Color.Green;

                var loadedSave = Decrypt(Password, File.ReadAllBytes(GameSavePath + saveMap[comboBox1.SelectedItem.ToString()]));
                saveLastModified.Text = File.GetLastAccessTime(GameSavePath + saveMap[comboBox1.SelectedItem.ToString()]).ToString();
                saveCreditsLabel.Text = getDataFromSave(loadedSave, Credits);
                saveQuotaLabel.Text = getDataFromSave(loadedSave, Quota);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loadedSave = Decrypt(Password, File.ReadAllBytes(GameSavePath + saveMap[comboBox1.SelectedItem.ToString()]));
            saveLastModified.Text = File.GetLastAccessTime(GameSavePath + saveMap[comboBox1.SelectedItem.ToString()]).ToString();
            saveCreditsLabel.Text = getDataFromSave(loadedSave, Credits);
            saveQuotaLabel.Text = getDataFromSave(loadedSave, Quota);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loadedBackup = Decrypt(Password, File.ReadAllBytes(CustomBackupDirectory + comboBox2.SelectedItem));
            backupLastModified.Text = File.GetLastAccessTime(CustomBackupDirectory + comboBox2.SelectedItem).ToString();
            backupCreditsLabel.Text = getDataFromSave(loadedBackup, Credits);
            backupQuotaLabel.Text = getDataFromSave(loadedBackup, Quota);
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private string getDataFromSave(string savedata, string attribute)
        {
            if (!savedata.Contains(attribute))
            {
                return "";
            }
            int first = savedata.IndexOf(attribute) + attribute.Length;

            List<int> termsList = new List<int>();
            int b = 0;
            bool foundInt = false;

            for (int i = 20; i < 100; i++)
            {
                bool result = int.TryParse(savedata[first + i].ToString(), out b);
                if (result)
                {
                    foundInt = true;
                    termsList.Add(b);
                }
                else
                {
                    if (foundInt)
                    {
                        break;
                    }
                }

            }

            string finalNumberStr = "";

            foreach (int i in termsList)
            {
                finalNumberStr += i.ToString();
            }

            return finalNumberStr;
        }

        private string writeToAttribute(string savedata, string attribute, string newAmount)
        {
            if (!savedata.Contains(attribute))
            {
                return "";
            }
            int first = savedata.IndexOf(attribute) + attribute.Length;
            int firstInt = 0;
            int b = 0;
            bool foundInt = false;

            List<int> termsList = new List<int>();
            for (int i = 20; i < 45; i++)
            {
                bool result = int.TryParse(savedata[first + i].ToString(), out b);
                if (result)
                {
                    if (firstInt == 0)
                    {
                        firstInt = first + i;
                    }

                    foundInt = true;
                    termsList.Add(b);
                }
                else
                {
                    if (foundInt)
                    {
                        break;
                    }
                }
            }
            string tempRemovedData = savedata.Remove(firstInt, termsList.Count);
            string updatedData = tempRemovedData.Insert(firstInt, newAmount);

            return updatedData;
        }

        private void setEditBoxes(string saveData, bool clear = false)
        {
            if (clear)
            {
                coinCountTextBox.Text = "";
                deathCountTextBox.Text = "";
                planetSeedTextBox.Text = "";
                deadlineTextBox.Text = "";
                planetIDTextBox.Text = "";
                quotaTextBox.Text = "";
            }
            else
            {
                coinCountTextBox.Text = getDataFromSave(saveData, Credits);
                deathCountTextBox.Text = getDataFromSave(saveData, Deaths);
                planetSeedTextBox.Text = getDataFromSave(saveData, PlanetSeed);
                deadlineTextBox.Text = getDataFromSave(saveData, Deadline);
                planetIDTextBox.Text = getDataFromSave(saveData, Planet);
                quotaTextBox.Text = getDataFromSave(saveData, Quota);
            }
        }

        private void setEditBoxesReadOnly(bool readOnly)
        {
            coinCountTextBox.ReadOnly = readOnly;
            deathCountTextBox.ReadOnly = readOnly;
            planetSeedTextBox.ReadOnly = readOnly;
            deadlineTextBox.ReadOnly = readOnly;
            planetIDTextBox.ReadOnly = readOnly;
            quotaTextBox.ReadOnly = readOnly;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (decryptionStatus)
            {
                // may be a good idea to do something here before we return
                // likely unnecessary
                return;
            }
            try
            {
                string selectedBackup = CustomBackupDirectory + comboBox2.SelectedItem;
                string saveData = Decrypt(Password, File.ReadAllBytes(selectedBackup));
                currentSaveData = saveData;
                setEditBoxesReadOnly(false);
                decryptionStatus = true;
                statusLabel.Text = "Loaded backup";
                statusLabel.ForeColor = System.Drawing.Color.Green;
                setEditBoxes(saveData);
            }
            catch(Exception ex) 
            {
                statusLabel.Text = "Invalid save or password";
                statusLabel.ForeColor = System.Drawing.Color.Red;
                decryptionStatus = false;
                Console.WriteLine(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {


            currentSaveData = writeToAttribute(currentSaveData, Credits, coinCount);
            currentSaveData = writeToAttribute(currentSaveData, Deaths, deathCount);
            currentSaveData = writeToAttribute(currentSaveData, PlanetSeed, seed);
            currentSaveData = writeToAttribute(currentSaveData, Deadline, timeLeft);
            currentSaveData = writeToAttribute(currentSaveData, Planet, planetID);
            currentSaveData = writeToAttribute(currentSaveData, Quota, quotaAmount);
            
            try
            {
                File.WriteAllBytes(CustomBackupDirectory + comboBox2.SelectedItem, Encrypt(Password, currentSaveData));
                statusLabel.Text = "Updated Backup";
                statusLabel.ForeColor = System.Drawing.Color.Green;

            } catch (Exception ex)
            {
                statusLabel.Text = "Failed to update, restoring";
                statusLabel.ForeColor = System.Drawing.Color.Red;
                Console.WriteLine(ex.Message);
            }
            setEditBoxesReadOnly(true);
            setEditBoxes("", true);
            decryptionStatus = false;
            comboBox2.Enabled = true;
            

        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (decryptionStatus)
            {
                comboBox2.Enabled = false;
                MessageBoxResult confirmChanges = System.Windows.MessageBox.Show("You need to click \"Confirm.\"", "Notice", MessageBoxButton.OK);
            }
        }

        #region TEXTBOX CLICK
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (coinCountTextBox.ReadOnly)
            {
                System.Windows.MessageBox.Show("You need to click \"Edit backup\"", "Notice", MessageBoxButton.OK);

            }
        }

        private void deathCountTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (deathCountTextBox.ReadOnly)
            {
                System.Windows.MessageBox.Show("You need to click \"Edit backup\"", "Notice", MessageBoxButton.OK);

            }
        }

        private void planetSeedTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (planetSeedTextBox.ReadOnly)
            {
                System.Windows.MessageBox.Show("You need to click \"Edit backup\"", "Notice", MessageBoxButton.OK);

            }
        }

        private void deadlineTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (deadlineTextBox.ReadOnly)
            {
                System.Windows.MessageBox.Show("You need to click \"Edit backup\"", "Notice", MessageBoxButton.OK);

            }
        }

        private void planetIDTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (planetIDTextBox.ReadOnly)
            {
                System.Windows.MessageBox.Show("You need to click \"Edit backup\"", "Notice", MessageBoxButton.OK);

            }
        }

        private void quotaTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (quotaTextBox.ReadOnly)
            {
                System.Windows.MessageBox.Show("You need to click \"Edit backup\"", "Notice", MessageBoxButton.OK);

            }
        }

        #endregion

        #region TEXTBOX EDIT

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            coinCount = coinCountTextBox.Text;
        }

        private void deathCountTextBox_TextChanged(object sender, EventArgs e)
        {
            deathCount = deathCountTextBox.Text;
        }

        private void planetSeedTextBox_TextChanged(object sender, EventArgs e)
        {
            seed = planetSeedTextBox.Text;
        }

        private void deadlineTextBox_TextChanged(object sender, EventArgs e)
        {
            
            timeLeft = deadlineTextBox.Text;
        }

        private void planetIDTextBox_TextChanged(object sender, EventArgs e)
        {
            planetID = planetIDTextBox.Text;
        }

        private void quotaTextBox_TextChanged(object sender, EventArgs e)
        {
            quotaAmount = quotaTextBox.Text;
        }

        #endregion

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }

}
