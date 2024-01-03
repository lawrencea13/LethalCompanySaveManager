namespace LethalCompanySaveManager
{
	partial class SaveEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveEditor));
			this.SaveAbortButton = new System.Windows.Forms.Button();
			this.planetIdCombo = new System.Windows.Forms.ComboBox();
			this.quotaNumeric = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.MinimizeButton = new System.Windows.Forms.Button();
			this.QuitButton = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label14 = new System.Windows.Forms.Label();
			this.shipScrapValuesRichBox = new System.Windows.Forms.RichTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.goToShipStorageButton = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.daySpentNumeric = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.valueCollectedNumeric = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.stepsTakenNumeric = new System.Windows.Forms.NumericUpDown();
			this.timeNumeric = new System.Windows.Forms.NumericUpDown();
			this.quotaPassedNumeric = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.deadlineNumeric = new System.Windows.Forms.NumericUpDown();
			this.deathsNumeric = new System.Windows.Forms.NumericUpDown();
			this.planetSeedNumeric = new System.Windows.Forms.NumericUpDown();
			this.coinCountNumeric = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SaveConfirmChangeButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.thisNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			((System.ComponentModel.ISupportInitialize)(this.quotaNumeric)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.daySpentNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.valueCollectedNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stepsTakenNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.timeNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.quotaPassedNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deadlineNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.deathsNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.planetSeedNumeric)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.coinCountNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// SaveAbortButton
			// 
			this.SaveAbortButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.SaveAbortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveAbortButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.SaveAbortButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.SaveAbortButton.Location = new System.Drawing.Point(307, 256);
			this.SaveAbortButton.Name = "SaveAbortButton";
			this.SaveAbortButton.Size = new System.Drawing.Size(88, 23);
			this.SaveAbortButton.TabIndex = 46;
			this.SaveAbortButton.Text = "Abort";
			this.SaveAbortButton.UseVisualStyleBackColor = false;
			this.SaveAbortButton.Click += new System.EventHandler(this.SaveAbortButton_Click);
			// 
			// planetIdCombo
			// 
			this.planetIdCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.planetIdCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.planetIdCombo.FormattingEnabled = true;
			this.planetIdCombo.Items.AddRange(new object[] {
            "71-Gordion",
            "41-Experimentation",
            "220-Assurance",
            "56-Vow",
            "21-Offense",
            "61-March",
            "85-Rend",
            "7-Dine",
            "8-Titan"});
			this.planetIdCombo.Location = new System.Drawing.Point(7, 172);
			this.planetIdCombo.Name = "planetIdCombo";
			this.planetIdCombo.Size = new System.Drawing.Size(114, 21);
			this.planetIdCombo.TabIndex = 40;
			this.planetIdCombo.SelectedIndexChanged += new System.EventHandler(this.planetIdCombo_SelectedIndexChanged);
			// 
			// quotaNumeric
			// 
			this.quotaNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.quotaNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.quotaNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.quotaNumeric.Location = new System.Drawing.Point(151, 73);
			this.quotaNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.quotaNumeric.Name = "quotaNumeric";
			this.quotaNumeric.Size = new System.Drawing.Size(114, 20);
			this.quotaNumeric.TabIndex = 39;
			this.quotaNumeric.ValueChanged += new System.EventHandler(this.quotaNumeric_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(13)))), ((int)(((byte)(18)))));
			this.panel1.Controls.Add(this.MinimizeButton);
			this.panel1.Controls.Add(this.QuitButton);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(564, 38);
			this.panel1.TabIndex = 27;
			// 
			// MinimizeButton
			// 
			this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.MinimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.MinimizeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.MinimizeButton.Location = new System.Drawing.Point(478, 6);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.Size = new System.Drawing.Size(34, 23);
			this.MinimizeButton.TabIndex = 11;
			this.MinimizeButton.Text = "_";
			this.MinimizeButton.UseVisualStyleBackColor = false;
			this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
			// 
			// QuitButton
			// 
			this.QuitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.QuitButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.QuitButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.QuitButton.Location = new System.Drawing.Point(518, 6);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(34, 23);
			this.QuitButton.TabIndex = 10;
			this.QuitButton.Text = "X";
			this.QuitButton.UseVisualStyleBackColor = false;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// panel4
			// 
			this.panel4.AutoScroll = true;
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(13)))), ((int)(((byte)(18)))));
			this.panel4.Controls.Add(this.label14);
			this.panel4.Controls.Add(this.shipScrapValuesRichBox);
			this.panel4.Controls.Add(this.label13);
			this.panel4.Controls.Add(this.goToShipStorageButton);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Controls.Add(this.daySpentNumeric);
			this.panel4.Controls.Add(this.label11);
			this.panel4.Controls.Add(this.valueCollectedNumeric);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.label10);
			this.panel4.Controls.Add(this.stepsTakenNumeric);
			this.panel4.Controls.Add(this.timeNumeric);
			this.panel4.Controls.Add(this.quotaPassedNumeric);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.SaveAbortButton);
			this.panel4.Controls.Add(this.planetIdCombo);
			this.panel4.Controls.Add(this.quotaNumeric);
			this.panel4.Controls.Add(this.deadlineNumeric);
			this.panel4.Controls.Add(this.deathsNumeric);
			this.panel4.Controls.Add(this.planetSeedNumeric);
			this.panel4.Controls.Add(this.coinCountNumeric);
			this.panel4.Controls.Add(this.label8);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.label7);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Controls.Add(this.SaveConfirmChangeButton);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Location = new System.Drawing.Point(12, 56);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(564, 295);
			this.panel4.TabIndex = 26;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(141, 201);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(131, 13);
			this.label14.TabIndex = 63;
			this.label14.Text = "only modify existing values";
			// 
			// shipScrapValuesRichBox
			// 
			this.shipScrapValuesRichBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.shipScrapValuesRichBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.shipScrapValuesRichBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
			this.shipScrapValuesRichBox.Location = new System.Drawing.Point(3, 217);
			this.shipScrapValuesRichBox.Name = "shipScrapValuesRichBox";
			this.shipScrapValuesRichBox.Size = new System.Drawing.Size(262, 75);
			this.shipScrapValuesRichBox.TabIndex = 62;
			this.shipScrapValuesRichBox.Text = "";
			this.shipScrapValuesRichBox.TextChanged += new System.EventHandler(this.shipScrapValuesRichBox_TextChanged);
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label13.Location = new System.Drawing.Point(3, 196);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(142, 20);
			this.label13.TabIndex = 61;
			this.label13.Text = "Ship Scrap Values";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// goToShipStorageButton
			// 
			this.goToShipStorageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.goToShipStorageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.goToShipStorageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.goToShipStorageButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.goToShipStorageButton.Location = new System.Drawing.Point(436, 149);
			this.goToShipStorageButton.Name = "goToShipStorageButton";
			this.goToShipStorageButton.Size = new System.Drawing.Size(114, 43);
			this.goToShipStorageButton.TabIndex = 59;
			this.goToShipStorageButton.Text = "Ship Storage WIP";
			this.goToShipStorageButton.UseVisualStyleBackColor = false;
			this.goToShipStorageButton.Visible = false;
			this.goToShipStorageButton.Click += new System.EventHandler(this.goToShipStorageButton_Click);
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label12.Location = new System.Drawing.Point(436, 99);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(110, 20);
			this.label12.TabIndex = 58;
			this.label12.Text = "Day Spent";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// daySpentNumeric
			// 
			this.daySpentNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.daySpentNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.daySpentNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.daySpentNumeric.Location = new System.Drawing.Point(436, 123);
			this.daySpentNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.daySpentNumeric.Name = "daySpentNumeric";
			this.daySpentNumeric.Size = new System.Drawing.Size(114, 20);
			this.daySpentNumeric.TabIndex = 57;
			this.daySpentNumeric.ValueChanged += new System.EventHandler(this.daySpentNumeric_ValueChanged);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label11.Location = new System.Drawing.Point(432, 49);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(120, 20);
			this.label11.TabIndex = 56;
			this.label11.Text = "Value Collected";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// valueCollectedNumeric
			// 
			this.valueCollectedNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.valueCollectedNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.valueCollectedNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.valueCollectedNumeric.Location = new System.Drawing.Point(436, 73);
			this.valueCollectedNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.valueCollectedNumeric.Name = "valueCollectedNumeric";
			this.valueCollectedNumeric.Size = new System.Drawing.Size(114, 20);
			this.valueCollectedNumeric.TabIndex = 55;
			this.valueCollectedNumeric.ValueChanged += new System.EventHandler(this.valueCollectedNumeric_ValueChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label1.Location = new System.Drawing.Point(295, 148);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 20);
			this.label1.TabIndex = 54;
			this.label1.Text = "Steps Taken";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label10.Location = new System.Drawing.Point(295, 49);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(110, 20);
			this.label10.TabIndex = 53;
			this.label10.Text = "Quota Passed";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// stepsTakenNumeric
			// 
			this.stepsTakenNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.stepsTakenNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.stepsTakenNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.stepsTakenNumeric.Location = new System.Drawing.Point(295, 172);
			this.stepsTakenNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.stepsTakenNumeric.Name = "stepsTakenNumeric";
			this.stepsTakenNumeric.Size = new System.Drawing.Size(114, 20);
			this.stepsTakenNumeric.TabIndex = 52;
			this.stepsTakenNumeric.ValueChanged += new System.EventHandler(this.stepsTakenNumeric_ValueChanged);
			// 
			// timeNumeric
			// 
			this.timeNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.timeNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.timeNumeric.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.timeNumeric.Location = new System.Drawing.Point(295, 123);
			this.timeNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.timeNumeric.Name = "timeNumeric";
			this.timeNumeric.Size = new System.Drawing.Size(114, 20);
			this.timeNumeric.TabIndex = 51;
			this.timeNumeric.ValueChanged += new System.EventHandler(this.timeNumeric_ValueChanged);
			// 
			// quotaPassedNumeric
			// 
			this.quotaPassedNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.quotaPassedNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.quotaPassedNumeric.Location = new System.Drawing.Point(295, 73);
			this.quotaPassedNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.quotaPassedNumeric.Name = "quotaPassedNumeric";
			this.quotaPassedNumeric.Size = new System.Drawing.Size(114, 20);
			this.quotaPassedNumeric.TabIndex = 50;
			this.quotaPassedNumeric.ValueChanged += new System.EventHandler(this.quotaPassedNumeric_ValueChanged);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label3.Location = new System.Drawing.Point(295, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 20);
			this.label3.TabIndex = 48;
			this.label3.Text = "Time";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// deadlineNumeric
			// 
			this.deadlineNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.deadlineNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.deadlineNumeric.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.deadlineNumeric.Location = new System.Drawing.Point(151, 123);
			this.deadlineNumeric.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.deadlineNumeric.Name = "deadlineNumeric";
			this.deadlineNumeric.Size = new System.Drawing.Size(114, 20);
			this.deadlineNumeric.TabIndex = 38;
			this.deadlineNumeric.ValueChanged += new System.EventHandler(this.deadlineNumeric_ValueChanged);
			// 
			// deathsNumeric
			// 
			this.deathsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.deathsNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.deathsNumeric.Location = new System.Drawing.Point(7, 123);
			this.deathsNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.deathsNumeric.Name = "deathsNumeric";
			this.deathsNumeric.Size = new System.Drawing.Size(114, 20);
			this.deathsNumeric.TabIndex = 37;
			this.deathsNumeric.ValueChanged += new System.EventHandler(this.deathsNumeric_ValueChanged);
			// 
			// planetSeedNumeric
			// 
			this.planetSeedNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.planetSeedNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.planetSeedNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.planetSeedNumeric.Location = new System.Drawing.Point(151, 173);
			this.planetSeedNumeric.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this.planetSeedNumeric.Name = "planetSeedNumeric";
			this.planetSeedNumeric.Size = new System.Drawing.Size(114, 20);
			this.planetSeedNumeric.TabIndex = 35;
			this.planetSeedNumeric.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			this.planetSeedNumeric.ValueChanged += new System.EventHandler(this.planetSeedNumeric_ValueChanged);
			// 
			// coinCountNumeric
			// 
			this.coinCountNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
			this.coinCountNumeric.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.coinCountNumeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.coinCountNumeric.Location = new System.Drawing.Point(7, 73);
			this.coinCountNumeric.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
			this.coinCountNumeric.Name = "coinCountNumeric";
			this.coinCountNumeric.Size = new System.Drawing.Size(114, 20);
			this.coinCountNumeric.TabIndex = 34;
			this.coinCountNumeric.ValueChanged += new System.EventHandler(this.coinCountNumeric_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label8.Location = new System.Drawing.Point(181, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 20);
			this.label8.TabIndex = 33;
			this.label8.Text = "Quota";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label9.Location = new System.Drawing.Point(26, 148);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 20);
			this.label9.TabIndex = 30;
			this.label9.Text = "Planet ID";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label6.Location = new System.Drawing.Point(168, 99);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 20);
			this.label6.TabIndex = 29;
			this.label6.Text = "DeadLine";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label7.Location = new System.Drawing.Point(160, 148);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 20);
			this.label7.TabIndex = 26;
			this.label7.Text = "Planet Seed";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label5.Location = new System.Drawing.Point(34, 99);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 20);
			this.label5.TabIndex = 25;
			this.label5.Text = "Deaths";
			// 
			// SaveConfirmChangeButton
			// 
			this.SaveConfirmChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(91)))), ((int)(((byte)(61)))));
			this.SaveConfirmChangeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveConfirmChangeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(247)))), ((int)(((byte)(236)))));
			this.SaveConfirmChangeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.SaveConfirmChangeButton.Location = new System.Drawing.Point(450, 256);
			this.SaveConfirmChangeButton.Name = "SaveConfirmChangeButton";
			this.SaveConfirmChangeButton.Size = new System.Drawing.Size(88, 23);
			this.SaveConfirmChangeButton.TabIndex = 22;
			this.SaveConfirmChangeButton.Text = "Confirm";
			this.SaveConfirmChangeButton.UseVisualStyleBackColor = false;
			this.SaveConfirmChangeButton.Click += new System.EventHandler(this.SaveConfirmChangeButton_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label4.Location = new System.Drawing.Point(42, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "Coins";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.label2.Location = new System.Drawing.Point(225, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Save Editor";
			// 
			// thisNotifyIcon
			// 
			this.thisNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.thisNotifyIcon.BalloonTipText = "I\'m still here";
			this.thisNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("thisNotifyIcon.Icon")));
			this.thisNotifyIcon.Text = "EZAudioSwitcher";
			this.thisNotifyIcon.Visible = true;
			// 
			// SaveEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.ClientSize = new System.Drawing.Size(585, 352);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel4);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(177)))), ((int)(((byte)(166)))));
			this.MaximizeBox = false;
			this.Name = "SaveEditor";
			this.Text = "Save Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveEditor_FormClosing);
			this.Load += new System.EventHandler(this.SaveEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.quotaNumeric)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.daySpentNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.valueCollectedNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stepsTakenNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.timeNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.quotaPassedNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deadlineNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.deathsNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.planetSeedNumeric)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.coinCountNumeric)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button SaveAbortButton;
		private System.Windows.Forms.ComboBox planetIdCombo;
		private System.Windows.Forms.NumericUpDown quotaNumeric;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button MinimizeButton;
		private System.Windows.Forms.Button QuitButton;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.NumericUpDown deadlineNumeric;
		private System.Windows.Forms.NumericUpDown deathsNumeric;
		private System.Windows.Forms.NumericUpDown planetSeedNumeric;
		private System.Windows.Forms.NumericUpDown coinCountNumeric;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button SaveConfirmChangeButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NotifyIcon thisNotifyIcon;
		private System.Windows.Forms.NumericUpDown stepsTakenNumeric;
		private System.Windows.Forms.NumericUpDown timeNumeric;
		private System.Windows.Forms.NumericUpDown quotaPassedNumeric;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.NumericUpDown daySpentNumeric;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown valueCollectedNumeric;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button goToShipStorageButton;
		private System.Windows.Forms.RichTextBox shipScrapValuesRichBox;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
	}
}