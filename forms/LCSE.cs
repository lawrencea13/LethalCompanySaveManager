using LethalCompanySaveManager.forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI.WebControls.WebParts;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace LethalCompanySaveManager
{
	public partial class LCSE : Form
	{
		public static readonly string LocalLowPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\LocalLow\\";
		public static string GameSavePath = LocalLowPath + "ZeekerssRBLX\\Lethal Company\\";
		public static readonly string DefaultSaveDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LCSM\\GameBackups\\";
		public static string CustomBackupDirectory = DefaultSaveDirectory;

		public static Dictionary<int, string> Saves = new();
		public static readonly string PlayerSave = "LCGeneralSaveData";

		public static LCPlayer PlayerInfo = new();
		public static LCSave SaveInfo = new();
		public static LCSave BackupInfo = new();

		public bool editionStatus = false;

		public LCSE()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.None;
			System.IO.Directory.CreateDirectory(DefaultSaveDirectory);

			DisplayPlayerData();

			SaveComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			PopulateSaves();

			//select last played save
			SaveInfo = new(GameSavePath + Saves[PlayerInfo.lastSelectedFile]);
			SaveComboBox.SelectedIndex = PlayerInfo.lastSelectedFile;

			// backups drop box
			BackupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			PopulateBackups();

			DisableSaveEdition(true);

			/*string test = LCSecurity.Decrypt(File.ReadAllBytes(GameSavePath + PlayerSave));
			File.WriteAllText("corrupt.txt", test);*/
			/*string test = LCSecurity.Decrypt(File.ReadAllBytes(CustomBackupDirectory + "LCBackup2"));
			File.WriteAllText("backup.txt", test);*/
		}

		#region Loading and Displaying datas
		private void PopulateBackups()
		{
			BackupComboBox.Items.Clear();
			DirectoryInfo dir = new DirectoryInfo(CustomBackupDirectory);

			foreach (FileInfo item in dir.GetFiles())
			{
				//System.IO.Path.GetFileName(item);
				BackupComboBox.Items.Add(item.Name);
			}

			try
			{
				BackupComboBox.SelectedIndex = 0;
			}
			catch
			{
				BackupComboBox.Text = "No Backups...";
			}
		}

		private void PopulateSaves()
		{
			// Due to a strange case of save file named Save0, 1 and 3, this algorithm will
			// select all savefiles in the game save directory
			// THIS WILL NOT MAKE IT COMPATIBLE WITH THE MoreSave MOD	
			// More Save mod modify the save file encryption
			SaveComboBox.Items.Clear();
			Saves.Clear();
			DirectoryInfo saveDir = new DirectoryInfo(GameSavePath);
			int number = 1;

			if (!saveDir.Exists)
			{
				editionStatus = true;
				return;
			}
			foreach (FileInfo item in saveDir.GetFiles())
			{
				if (item.Name.Contains("LCSaveFile"))
				{
					Saves.Add(number - 1, item.Name);
					SaveComboBox.Items.Add("Save " + number);
					number++;
				}
			}
			if (SaveComboBox.Items.Count == 0) Debug.WriteLine("No save found");
            else SaveComboBox.SelectedIndex = 0;
        }

		private void LoadPlayerData()
		{
			PlayerInfo.Load();
			DisplayPlayerData();
		}

		private void DisplayPlayerData()
		{
			try
			{
				LastSaveNumeric.Value = PlayerInfo.lastSelectedFile;
			}
			catch (Exception)
			{
				LastSaveNumeric.Value = 1;
			}
			PlayerXPNumeric.Value = PlayerInfo.playerXP;
			PlayerLevelNumeric.Value = PlayerInfo.playerLevel;
			FinishedShockMinigameNumeric.Value = PlayerInfo.finishedShockMinigame;
			TimesLandedNumeric.Value = PlayerInfo.timesLanded;
			playerLastVersionLabel.Text = PlayerInfo.lastPlayedVersion.ToString();
			StartInOnlineCheckBox.Checked = PlayerInfo.startInOnlineMode;
			FinishedSetupComboBox.Checked = PlayerInfo.playerFinishedSetup;
			PlayerHostPublicCheckBox.Checked = PlayerInfo.hostPublicGame;
			HasUsedTerminalCombBox.Checked = PlayerInfo.hasUsedTerminal;
			HostNameTextBox.Text = PlayerInfo.hostName;
		}

		private void LoadSaveData(string savePath)
		{
			if (!File.Exists(savePath)) throw new FileNotFoundException(savePath + " not found");
			SaveInfo.Load(savePath);
			saveLastModified.Text = File.GetLastAccessTime(savePath).ToString();
			saveCreditsLabel.Text = SaveInfo.credits.ToString();
			saveQuotaLabel.Text = SaveInfo.quota.ToString();
			SaveGameVersionLabel.Text = SaveInfo.gameVer.ToString();
		}

		internal void LoadBackupData()
		{
			BackupInfo.Load(CustomBackupDirectory + BackupComboBox.SelectedItem);
			backupLastModified.Text = File.GetLastAccessTime(CustomBackupDirectory + BackupComboBox.SelectedItem).ToString();
			backupCreditsLabel.Text = BackupInfo.credits.ToString();
			backupQuotaLabel.Text = BackupInfo.quota.ToString();
			BackupGameVersionLabel.Text = BackupInfo.gameVer.ToString();
		}

		internal void DisableSaveEdition(bool readOnly)
		{
			BackupComboBox.Enabled = readOnly;
		}
		#endregion

		#region WindowMods
		private void QuitButton_Click(object sender, EventArgs e)
		{

			if (editionStatus)
			{
				MessageBoxResult confirmResult = System.Windows.MessageBox.Show("You have a backup open, are you sure you'd like to quit?", "Confirm Close", MessageBoxButton.YesNo);
				if (confirmResult == MessageBoxResult.Yes)
				{
					File.WriteAllBytes(CustomBackupDirectory + BackupComboBox.SelectedItem, LCSecurity.Encrypt(BackupInfo.saveData));
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

		#region Player Panel
		private void PlayerResetButton_Click(object sender, EventArgs e)
		{
			LoadPlayerData();
			playerStatusLabel.Text = "Resetted player";
		}

		private void PlayerSaveButton_Click(object sender, EventArgs e)
		{
			// Display last legal name accepted and write its attributes
			HostNameTextBox.Text = PlayerInfo.hostName;
			string tempHost = '"' + PlayerInfo.hostName + '"';
			PlayerInfo.WriteToAttribute(LCPlayer.HostName, tempHost);

			try
			{
				File.WriteAllBytes(GameSavePath + PlayerSave, LCSecurity.Encrypt(PlayerInfo.saveData));
				playerStatusLabel.Text = "Successfully saved the player !";
			}
			catch (Exception ex)
			{
				playerStatusLabel.Text = "Oops something went wrong ...";
				Console.WriteLine(ex.Message);
			}
		}

		#region Player Editor Values Handlers
		private void LastSaveNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			PlayerInfo.lastSelectedFile = (int)me.Value;
		}

		private void PlayerXPNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			PlayerInfo.playerXP = (int)me.Value;
		}

		private void PlayerLevelNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			PlayerInfo.playerLevel = (int)me.Value;
		}

		private void FinishedShockMinigameNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			PlayerInfo.finishedShockMinigame = (int)me.Value;
		}

		private void TimesLandedNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			PlayerInfo.timesLanded = (int)me.Value;
		}

		private void StartInOnlineCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			PlayerInfo.startInOnlineMode = me.Checked;
		}

		private void FinishedSetupComboBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			PlayerInfo.playerFinishedSetup = me.Checked;
		}

		private void PlayerHostPublicCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			PlayerInfo.hostPublicGame = me.Checked;
		}

		private void HasUsedTerminalCombBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			PlayerInfo.hasUsedTerminal = me.Checked;
		}

		private void HostNameTextBox_TextChanged(object sender, EventArgs e)
		{
			TextBox me = (TextBox)sender;
			if (me.Text.Length > 2)
				PlayerInfo.hostName = me.Text;
		}
		#endregion

		#endregion

		#region SaveLoader Panel
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				LoadSaveData(GameSavePath + Saves[SaveComboBox.SelectedIndex]);
				statusLabel.Text = "Save loaded";
				statusLabel.ForeColor = System.Drawing.Color.Green;
			}
			catch (Exception ex)
			{
				// save could not be loaded because it's either corrupted or does not exist
				using (File.Create(GameSavePath + Saves[SaveComboBox.SelectedIndex]))
				{
					saveLastModified.Text = "No save in slot";
					saveCreditsLabel.Text = "No save in slot";
					saveQuotaLabel.Text = "No save in slot";
					statusLabel.Text = "Error loading save";
					statusLabel.ForeColor = System.Drawing.Color.Red;
					Debug.WriteLine(ex);
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			// delete game save file
			MessageBoxResult confirmResult = System.Windows.MessageBox.Show("Are you sure to delete this item? If it's not backed up, this may not be reversible.", "Confirm Delete!!", MessageBoxButton.YesNo);

			if (confirmResult == MessageBoxResult.Yes)
			{
				File.Delete(GameSavePath + Saves[SaveComboBox.SelectedIndex]);
				SaveComboBox.SelectedIndex = 0;
				statusLabel.Text = "Success!";
				statusLabel.ForeColor = System.Drawing.Color.Green;
				PopulateSaves();
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

			DirectoryInfo backupDir = new DirectoryInfo(CustomBackupDirectory);

			FileInfo[] files = backupDir.GetFiles();

			backupName = "LCBackup" + files.Count().ToString();

			if (backupName == "")
			{
				statusLabel.Text = "Too many backups";
				statusLabel.ForeColor = System.Drawing.Color.Red;
			}
			else
			{
				try
				{
					File.Copy(GameSavePath + Saves[SaveComboBox.SelectedIndex], CustomBackupDirectory + backupName);
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
			if (editionStatus)
			{
				// do a message box just in case
				System.Windows.MessageBox.Show("You are editing this file, please save before you delete.", "Notice", MessageBoxButton.OK);
				return;
			}
			string selectedFile = CustomBackupDirectory + BackupComboBox.SelectedItem;
			if (File.Exists(selectedFile))
			{
				File.Delete(selectedFile);
				statusLabel.Text = "Deleted backup!";
				statusLabel.ForeColor = System.Drawing.Color.Green;
			}
			PopulateBackups();
		}
		#endregion

		#region Backup Panel
		private void button1_Click(object sender, EventArgs e)
		{
			string selectedBackup = CustomBackupDirectory + BackupComboBox.SelectedItem;
			string selectedSave = GameSavePath + Saves[SaveComboBox.SelectedIndex];

			if (File.Exists(selectedBackup) && File.Exists(selectedSave))
			{
				File.Delete(selectedSave);
				File.Copy(selectedBackup, selectedSave);
				statusLabel.Text = "Loaded backup!";
				statusLabel.ForeColor = System.Drawing.Color.Green;

				LoadSaveData(selectedSave);
			}
			else
			{
				statusLabel.Text = "Save doesn't exists, unable to load backup !";
				statusLabel.ForeColor = System.Drawing.Color.Red;
			}
		}

		private void comboBox2_MouseClick(object sender, MouseEventArgs e)
		{
			if (editionStatus)
			{
				BackupComboBox.Enabled = false;
				MessageBoxResult confirmChanges = System.Windows.MessageBox.Show("You need to click \"Confirm.\"", "Notice", MessageBoxButton.OK);
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadBackupData();
		}

		private void editBackupButton_Click(object sender, EventArgs e)
		{
			if (editionStatus)
			{
				// do a message box just in case
				MessageBoxResult confirmChanges = System.Windows.MessageBox.Show("You are already editing this file.", "Notice", MessageBoxButton.OK);
				return;
			}
			try
			{
				LoadBackupData();
				editionStatus = true;
				if (!SaveEditor.isShown)
				{
					SaveEditor saveEditor = new SaveEditor();
					saveEditor.Form1 = this;
					saveEditor.Show();
				}
			}
			catch (Exception ex)
			{
				editionStatus = false;
				Console.WriteLine(ex.Message);
			}

		}
		private void renameBackupButton_Click(object sender, EventArgs e)
		{
			FileInfo backup = new FileInfo(CustomBackupDirectory + BackupComboBox.SelectedItem);
			if (backup.Exists)
			{
				RenameDialog renameDialog = new RenameDialog();
				if (renameDialog.ShowDialog(this) == DialogResult.OK)
				{
					string litteral = Uri.EscapeUriString(renameDialog.fileNameTextBox.Text);
					string newName = CustomBackupDirectory + litteral;
					if (!File.Exists(newName))
					{
						File.Move(backup.FullName, newName);
						statusLabel.Text = "Backup renamed to : " + litteral;
						statusLabel.ForeColor = Color.Green;
						PopulateBackups();
					}
					else
					{
						statusLabel.Text = "Impossible to rename the backup to : \"" +
							litteral + "\", the file already exists.";
						statusLabel.ForeColor = Color.Orange;
					}
				}
			}
		}
		#endregion
	}
}
