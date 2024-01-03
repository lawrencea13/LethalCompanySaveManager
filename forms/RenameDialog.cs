using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LethalCompanySaveManager.forms
{
	public partial class RenameDialog : Form
	{
		public RenameDialog()
		{
			InitializeComponent();
		}

		private void RenameDialog_Load(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.None;
			this.AcceptButton = SaveButton;
			this.CancelButton = AbortButton;
		}

		private void SaveButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
