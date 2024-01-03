using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LethalCompanySaveManager
{
	public partial class ShipStore : Form
	{
		internal static bool isShown = false;
		public ShipStore()
		{
			InitializeComponent();
		}

		#region WindowMod
		private void SaveEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			isShown = false;
		}

		private void QuitButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MinimizeButton_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		private void ShipStore_Load(object sender, EventArgs e)
		{
			// Storage need to have proper object unlocked data
			// I don't have the list of IDs corresponding to an object so postponed.
			this.FormBorderStyle = FormBorderStyle.None;

			isShown = true;
			TeleporterBox.Checked = LCSE.BackupInfo.isAcquiredTeleporter;
			inverseTeleporterBox.Checked = LCSE.BackupInfo.isAcquiredInverseTeleporter;
			loudHornBox.Checked = LCSE.BackupInfo.isAcquiredLoudHorn;
			signalTransmitterBox.Checked = LCSE.BackupInfo.isAcquiredSignalTransmitter;
			jackolanternBox.Checked = LCSE.BackupInfo.isAcquiredJackOLantern;
			bunkbedsBox.Checked = LCSE.BackupInfo.isAcquiredBunkBeds;
			romanticTableBox.Checked = LCSE.BackupInfo.isAcquiredRomanticTable;
			tableBox.Checked = LCSE.BackupInfo.isAcquiredTable;
			recordPlayerBox.Checked = LCSE.BackupInfo.isAcquiredRecordPlayer;
			showerBox.Checked = LCSE.BackupInfo.isAcquiredShower;
			toiletBox.Checked = LCSE.BackupInfo.isAcquiredToilet;
			fileCabinetBox.Checked = LCSE.BackupInfo.isAcquiredFileCabinet;
			cupboardBox.Checked = LCSE.BackupInfo.isAcquiredCupboard;
			televisionBox.Checked = LCSE.BackupInfo.isAcquiredTelevision;
			string tempText = "";
			foreach (int i in LCSE.BackupInfo.unlockedShipObjects)
			{
				tempText += i.ToString() + ',';
			}
			ShipUnlockedObjectsRichBox.Text = tempText;
		}

		#region Value Change Handlers
		private void TeleporterBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredTeleporter = me.Checked;
		}

		private void inverseTeleporterBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredInverseTeleporter = me.Checked;
		}

		private void loudHornBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredLoudHorn = me.Checked;
		}

		private void signalTransmitterBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredSignalTransmitter = me.Checked;
		}

		private void jackolanternBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredJackOLantern = me.Checked;
		}

		private void bunkbedsBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredBunkBeds = me.Checked;
		}

		private void romanticTableBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredRomanticTable = me.Checked;
		}

		private void tableBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredTable = me.Checked;
		}

		private void recordPlayerBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredRecordPlayer = me.Checked;
		}

		private void showerBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredShower = me.Checked;
		}

		private void toiletBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredToilet = me.Checked;
		}

		private void fileCabinetBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredFileCabinet = me.Checked;
		}

		private void cupboardBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredCupboard = me.Checked;
		}

		private void televisionBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox me = (CheckBox)sender;
			LCSE.BackupInfo.isAcquiredTelevision = me.Checked;
		}

		private void ShipUnlockedObjectsRichBox_TextChanged(object sender, EventArgs e)
		{
			RichTextBox me = (RichTextBox)sender;
			if (me.Text.Length > 0)
			{
				string[] strSplit = me.Text.Trim().Split(',');
				int[] ids = new int[strSplit.Length];
				int index = 0;
				foreach (string str in strSplit)
				{
					if (String.IsNullOrEmpty(str)) continue;
					ids[index] = int.Parse(str);
					index++;
				}

				LCSE.BackupInfo.shipScrapValues = ids;
			}
		}
		#endregion
	}
}
