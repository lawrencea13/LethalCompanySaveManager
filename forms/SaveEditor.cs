using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LethalCompanySaveManager
{
	public partial class SaveEditor : Form
	{
		public static bool isShown = false;
		public LCSE Form1;
		public SaveEditor()
		{
			InitializeComponent();
		}

		private void SaveEditor_Load(object sender, EventArgs e)
		{
			isShown = true;
			this.FormBorderStyle = FormBorderStyle.None;

			coinCountNumeric.Value = LCSE.BackupInfo.credits;
			deathsNumeric.Value = LCSE.BackupInfo.deaths;
			quotaNumeric.Value = LCSE.BackupInfo.quota;
			deadlineNumeric.Value = LCSE.BackupInfo.deadline;
			planetSeedNumeric.Value = LCSE.BackupInfo.planetSeed;
			quotaPassedNumeric.Value = LCSE.BackupInfo.quotasPassed;
			timeNumeric.Value = LCSE.BackupInfo.time;
			stepsTakenNumeric.Value = LCSE.BackupInfo.stepsTaken;
			valueCollectedNumeric.Value = LCSE.BackupInfo.valueCollected;
			daySpentNumeric.Value = LCSE.BackupInfo.daySpent;
			planetIdCombo.SelectedIndex = LCSE.BackupInfo.planet;
		}

		private void DisplayValues()
		{

		}

		#region WindowMod
		private void SaveEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			isShown = false;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			Form1.DisableSaveEdition(true);
			Form1.editionStatus = false;
			Form1.statusLabel.Text = "Modifications are pending (unsaved state)";
			Form1.statusLabel.ForeColor = Color.FromArgb(94, 24, 24);
			this.Close();
		}

		private void MinimizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		#region Value Change Handlers
		private void coinCountNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.credits = (int) me.Value;
		}

		private void deathsNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.deaths = (int)me.Value;
		}

		private void quotaNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.quota = (int)me.Value;
		}

		private void deadlineNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.deadline = (int)me.Value;
		}

		private void planetSeedNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.planetSeed = (int)me.Value;
		}

		private void quotaPassedNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.quotasPassed = (int)me.Value;
		}

		private void timeNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.time = (int)me.Value;
		}

		private void stepsTakenNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.stepsTaken = (int)me.Value;
		}

		private void valueCollectedNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.valueCollected = (int)me.Value;
		}

		private void daySpentNumeric_ValueChanged(object sender, EventArgs e)
		{
			NumericUpDown me = (NumericUpDown)sender;
			LCSE.BackupInfo.daySpent = (int)me.Value;
		}

		private void planetIdCombo_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox planetIdCombo = sender as ComboBox;
			LCSE.BackupInfo.planet = planetIdCombo.SelectedIndex;
		}

		private void shipScrapValuesRichBox_TextChanged(object sender, EventArgs e)
		{
			RichTextBox me = (RichTextBox)sender;
			if (me.Text.Length > 0)
			{
				string[] strSplit = me.Text.Split(',');
				int[] ids = new int[strSplit.Length];
				int index = 0;
				foreach (string str in strSplit)
				{
					ids[index] = int.Parse(str);
					index++;
				}

				LCSE.BackupInfo.shipScrapValues = ids;
			}
		}
		#endregion

		private void SaveAbortButton_Click(object sender, EventArgs e)
		{
			Form1.DisableSaveEdition(true);
			Form1.editionStatus = false;
			Form1.statusLabel.Text = "Modifications are pending (unsaved state)";
			Form1.statusLabel.ForeColor = Color.FromArgb(94, 24, 24);
			this.Close();
		}

		private void goToShipStorageButton_Click(object sender, EventArgs e)
		{
			if (!ShipStore.isShown)
			{
				ShipStore shipEditor = new ShipStore();
				shipEditor.Show();
			}
		}

		private void SaveConfirmChangeButton_Click(object sender, EventArgs e)
		{
			try
			{
				File.WriteAllBytes(LCSE.CustomBackupDirectory + Form1.BackupComboBox.SelectedItem, 
					LCSecurity.Encrypt(LCSE.BackupInfo.saveData));
				Form1.statusLabel.Text = "Updated Backup";
				Form1.statusLabel.ForeColor = System.Drawing.Color.Green;

			}
			catch (Exception ex)
			{
				Form1.statusLabel.Text = "Failed to update, restoring";
				Form1.statusLabel.ForeColor = System.Drawing.Color.Red;
				Console.WriteLine(ex.Message);
			}
			Form1.DisableSaveEdition(true);
			Form1.editionStatus = false;
			Form1.BackupComboBox.Enabled = true;

			Form1.LoadBackupData();
			this.Close();
		}
	}
}
