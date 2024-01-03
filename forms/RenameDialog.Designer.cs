namespace LethalCompanySaveManager.forms
{
	partial class RenameDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameDialog));
			this.thisNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.label13 = new System.Windows.Forms.Label();
			this.AbortButton = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.fileNameTextBox = new System.Windows.Forms.TextBox();
			this.SaveButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// thisNotifyIcon
			// 
			this.thisNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.thisNotifyIcon.BalloonTipText = "I\'m still here";
			this.thisNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("thisNotifyIcon.Icon")));
			this.thisNotifyIcon.Text = "EZAudioSwitcher";
			this.thisNotifyIcon.Visible = true;
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label13.Location = new System.Drawing.Point(3, 27);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(204, 20);
			this.label13.TabIndex = 61;
			this.label13.Text = "Please enter the new filename";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AbortButton
			// 
			this.AbortButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.AbortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AbortButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.AbortButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.AbortButton.Location = new System.Drawing.Point(6, 80);
			this.AbortButton.Name = "AbortButton";
			this.AbortButton.Size = new System.Drawing.Size(88, 23);
			this.AbortButton.TabIndex = 46;
			this.AbortButton.Text = "Abort";
			this.AbortButton.UseVisualStyleBackColor = false;
			// 
			// panel4
			// 
			this.panel4.AutoScroll = true;
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(13)))), ((int)(((byte)(18)))));
			this.panel4.Controls.Add(this.fileNameTextBox);
			this.panel4.Controls.Add(this.label13);
			this.panel4.Controls.Add(this.AbortButton);
			this.panel4.Controls.Add(this.SaveButton);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Location = new System.Drawing.Point(2, 1);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(215, 110);
			this.panel4.TabIndex = 28;
			// 
			// fileNameTextBox
			// 
			this.fileNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.fileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
			this.fileNameTextBox.Location = new System.Drawing.Point(6, 50);
			this.fileNameTextBox.Name = "fileNameTextBox";
			this.fileNameTextBox.Size = new System.Drawing.Size(201, 24);
			this.fileNameTextBox.TabIndex = 64;
			// 
			// SaveButton
			// 
			this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(91)))), ((int)(((byte)(61)))));
			this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.SaveButton.Location = new System.Drawing.Point(119, 80);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(88, 23);
			this.SaveButton.TabIndex = 22;
			this.SaveButton.Text = "Confirm";
			this.SaveButton.UseVisualStyleBackColor = false;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label2.Location = new System.Drawing.Point(7, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Rename";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RenameDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.ClientSize = new System.Drawing.Size(217, 111);
			this.Controls.Add(this.panel4);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.Name = "RenameDialog";
			this.Text = "RenameDialog";
			this.Load += new System.EventHandler(this.RenameDialog_Load);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon thisNotifyIcon;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button AbortButton;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox fileNameTextBox;
	}
}