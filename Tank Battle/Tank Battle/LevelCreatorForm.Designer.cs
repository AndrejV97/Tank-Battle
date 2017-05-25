namespace Tank_Battle
{
    partial class LevelCreatorForm
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
            this.tmrGameSpeed = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRandomize = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbPlayer1 = new System.Windows.Forms.RadioButton();
            this.rbPlayer2 = new System.Windows.Forms.RadioButton();
            this.rbTerrain = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSymmetrical = new System.Windows.Forms.RadioButton();
            this.rbAsymmetrical = new System.Windows.Forms.RadioButton();
            this.rbFree = new System.Windows.Forms.RadioButton();
            this.cbDebugTerrain = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbQuality32 = new System.Windows.Forms.RadioButton();
            this.rbQuality16 = new System.Windows.Forms.RadioButton();
            this.rbQuality8 = new System.Windows.Forms.RadioButton();
            this.rbQuality4 = new System.Windows.Forms.RadioButton();
            this.rbQuality2 = new System.Windows.Forms.RadioButton();
            this.rbQuality1 = new System.Windows.Forms.RadioButton();
            this.nudBrushSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSaveLevel = new System.Windows.Forms.Button();
            this.tbLevelName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrushSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrGameSpeed
            // 
            this.tmrGameSpeed.Enabled = true;
            this.tmrGameSpeed.Interval = 15;
            this.tmrGameSpeed.Tick += new System.EventHandler(this.tmrGameSpeed_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnRandomize
            // 
            this.btnRandomize.Location = new System.Drawing.Point(387, -3);
            this.btnRandomize.Name = "btnRandomize";
            this.btnRandomize.Size = new System.Drawing.Size(117, 23);
            this.btnRandomize.TabIndex = 33;
            this.btnRandomize.Text = "Randomize";
            this.btnRandomize.UseVisualStyleBackColor = true;
            this.btnRandomize.Click += new System.EventHandler(this.btnRandomize_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbPlayer1);
            this.groupBox3.Controls.Add(this.rbPlayer2);
            this.groupBox3.Controls.Add(this.rbTerrain);
            this.groupBox3.Location = new System.Drawing.Point(141, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(117, 81);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selection";
            // 
            // rbPlayer1
            // 
            this.rbPlayer1.AutoSize = true;
            this.rbPlayer1.Location = new System.Drawing.Point(6, 39);
            this.rbPlayer1.Name = "rbPlayer1";
            this.rbPlayer1.Size = new System.Drawing.Size(63, 17);
            this.rbPlayer1.TabIndex = 2;
            this.rbPlayer1.TabStop = true;
            this.rbPlayer1.Text = "Player 1";
            this.rbPlayer1.UseVisualStyleBackColor = true;
            // 
            // rbPlayer2
            // 
            this.rbPlayer2.AutoSize = true;
            this.rbPlayer2.Location = new System.Drawing.Point(6, 58);
            this.rbPlayer2.Name = "rbPlayer2";
            this.rbPlayer2.Size = new System.Drawing.Size(63, 17);
            this.rbPlayer2.TabIndex = 1;
            this.rbPlayer2.TabStop = true;
            this.rbPlayer2.Text = "Player 2";
            this.rbPlayer2.UseVisualStyleBackColor = true;
            // 
            // rbTerrain
            // 
            this.rbTerrain.AutoSize = true;
            this.rbTerrain.Location = new System.Drawing.Point(5, 19);
            this.rbTerrain.Name = "rbTerrain";
            this.rbTerrain.Size = new System.Drawing.Size(58, 17);
            this.rbTerrain.TabIndex = 0;
            this.rbTerrain.TabStop = true;
            this.rbTerrain.Text = "Terrain";
            this.rbTerrain.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSymmetrical);
            this.groupBox2.Controls.Add(this.rbAsymmetrical);
            this.groupBox2.Controls.Add(this.rbFree);
            this.groupBox2.Location = new System.Drawing.Point(387, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 81);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Symmetry";
            // 
            // rbSymmetrical
            // 
            this.rbSymmetrical.AutoSize = true;
            this.rbSymmetrical.Location = new System.Drawing.Point(6, 39);
            this.rbSymmetrical.Name = "rbSymmetrical";
            this.rbSymmetrical.Size = new System.Drawing.Size(81, 17);
            this.rbSymmetrical.TabIndex = 2;
            this.rbSymmetrical.TabStop = true;
            this.rbSymmetrical.Text = "Symmetrical";
            this.rbSymmetrical.UseVisualStyleBackColor = true;
            // 
            // rbAsymmetrical
            // 
            this.rbAsymmetrical.AutoSize = true;
            this.rbAsymmetrical.Location = new System.Drawing.Point(6, 58);
            this.rbAsymmetrical.Name = "rbAsymmetrical";
            this.rbAsymmetrical.Size = new System.Drawing.Size(86, 17);
            this.rbAsymmetrical.TabIndex = 1;
            this.rbAsymmetrical.TabStop = true;
            this.rbAsymmetrical.Text = "Asymmetrical";
            this.rbAsymmetrical.UseVisualStyleBackColor = true;
            // 
            // rbFree
            // 
            this.rbFree.AutoSize = true;
            this.rbFree.Location = new System.Drawing.Point(5, 19);
            this.rbFree.Name = "rbFree";
            this.rbFree.Size = new System.Drawing.Size(46, 17);
            this.rbFree.TabIndex = 0;
            this.rbFree.TabStop = true;
            this.rbFree.Text = "Free";
            this.rbFree.UseVisualStyleBackColor = true;
            // 
            // cbDebugTerrain
            // 
            this.cbDebugTerrain.AutoSize = true;
            this.cbDebugTerrain.Location = new System.Drawing.Point(264, 1);
            this.cbDebugTerrain.Name = "cbDebugTerrain";
            this.cbDebugTerrain.Size = new System.Drawing.Size(90, 17);
            this.cbDebugTerrain.TabIndex = 30;
            this.cbDebugTerrain.Text = "Debug terrain";
            this.cbDebugTerrain.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbQuality32);
            this.groupBox1.Controls.Add(this.rbQuality16);
            this.groupBox1.Controls.Add(this.rbQuality8);
            this.groupBox1.Controls.Add(this.rbQuality4);
            this.groupBox1.Controls.Add(this.rbQuality2);
            this.groupBox1.Controls.Add(this.rbQuality1);
            this.groupBox1.Location = new System.Drawing.Point(264, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 81);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Terrain Quality";
            // 
            // rbQuality32
            // 
            this.rbQuality32.AutoSize = true;
            this.rbQuality32.Location = new System.Drawing.Point(61, 58);
            this.rbQuality32.Name = "rbQuality32";
            this.rbQuality32.Size = new System.Drawing.Size(37, 17);
            this.rbQuality32.TabIndex = 5;
            this.rbQuality32.TabStop = true;
            this.rbQuality32.Text = "32";
            this.rbQuality32.UseVisualStyleBackColor = true;
            // 
            // rbQuality16
            // 
            this.rbQuality16.AutoSize = true;
            this.rbQuality16.Location = new System.Drawing.Point(61, 39);
            this.rbQuality16.Name = "rbQuality16";
            this.rbQuality16.Size = new System.Drawing.Size(37, 17);
            this.rbQuality16.TabIndex = 4;
            this.rbQuality16.TabStop = true;
            this.rbQuality16.Text = "16";
            this.rbQuality16.UseVisualStyleBackColor = true;
            // 
            // rbQuality8
            // 
            this.rbQuality8.AutoSize = true;
            this.rbQuality8.Location = new System.Drawing.Point(61, 20);
            this.rbQuality8.Name = "rbQuality8";
            this.rbQuality8.Size = new System.Drawing.Size(31, 17);
            this.rbQuality8.TabIndex = 3;
            this.rbQuality8.TabStop = true;
            this.rbQuality8.Text = "8";
            this.rbQuality8.UseVisualStyleBackColor = true;
            // 
            // rbQuality4
            // 
            this.rbQuality4.AutoSize = true;
            this.rbQuality4.Location = new System.Drawing.Point(7, 58);
            this.rbQuality4.Name = "rbQuality4";
            this.rbQuality4.Size = new System.Drawing.Size(31, 17);
            this.rbQuality4.TabIndex = 2;
            this.rbQuality4.TabStop = true;
            this.rbQuality4.Text = "4";
            this.rbQuality4.UseVisualStyleBackColor = true;
            // 
            // rbQuality2
            // 
            this.rbQuality2.AutoSize = true;
            this.rbQuality2.Location = new System.Drawing.Point(7, 39);
            this.rbQuality2.Name = "rbQuality2";
            this.rbQuality2.Size = new System.Drawing.Size(31, 17);
            this.rbQuality2.TabIndex = 1;
            this.rbQuality2.TabStop = true;
            this.rbQuality2.Text = "2";
            this.rbQuality2.UseVisualStyleBackColor = true;
            // 
            // rbQuality1
            // 
            this.rbQuality1.AutoSize = true;
            this.rbQuality1.Location = new System.Drawing.Point(7, 20);
            this.rbQuality1.Name = "rbQuality1";
            this.rbQuality1.Size = new System.Drawing.Size(31, 17);
            this.rbQuality1.TabIndex = 0;
            this.rbQuality1.TabStop = true;
            this.rbQuality1.Text = "1";
            this.rbQuality1.UseVisualStyleBackColor = true;
            // 
            // nudBrushSize
            // 
            this.nudBrushSize.Location = new System.Drawing.Point(202, -1);
            this.nudBrushSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudBrushSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBrushSize.Name = "nudBrushSize";
            this.nudBrushSize.Size = new System.Drawing.Size(56, 20);
            this.nudBrushSize.TabIndex = 28;
            this.nudBrushSize.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Brush size:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(32, 83);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 23);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(32, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 23);
            this.btnReset.TabIndex = 26;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSaveLevel
            // 
            this.btnSaveLevel.Location = new System.Drawing.Point(32, 54);
            this.btnSaveLevel.Name = "btnSaveLevel";
            this.btnSaveLevel.Size = new System.Drawing.Size(100, 23);
            this.btnSaveLevel.TabIndex = 24;
            this.btnSaveLevel.Text = "Save Level";
            this.btnSaveLevel.UseVisualStyleBackColor = true;
            this.btnSaveLevel.Click += new System.EventHandler(this.btnSaveLevel_Click);
            // 
            // tbLevelName
            // 
            this.tbLevelName.Location = new System.Drawing.Point(32, -1);
            this.tbLevelName.Name = "tbLevelName";
            this.tbLevelName.Size = new System.Drawing.Size(83, 20);
            this.tbLevelName.TabIndex = 23;
            this.tbLevelName.Text = "Level Name";
            // 
            // LevelCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 768);
            this.Controls.Add(this.btnRandomize);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbDebugTerrain);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nudBrushSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSaveLevel);
            this.Controls.Add(this.tbLevelName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LevelCreatorForm";
            this.Text = "Level Creator";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LevelCreatorForm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LevelCreatorForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LevelCreatorForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrushSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameSpeed;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnRandomize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbPlayer1;
        private System.Windows.Forms.RadioButton rbPlayer2;
        private System.Windows.Forms.RadioButton rbTerrain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbSymmetrical;
        private System.Windows.Forms.RadioButton rbAsymmetrical;
        private System.Windows.Forms.RadioButton rbFree;
        private System.Windows.Forms.CheckBox cbDebugTerrain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbQuality32;
        private System.Windows.Forms.RadioButton rbQuality16;
        private System.Windows.Forms.RadioButton rbQuality8;
        private System.Windows.Forms.RadioButton rbQuality4;
        private System.Windows.Forms.RadioButton rbQuality2;
        private System.Windows.Forms.RadioButton rbQuality1;
        private System.Windows.Forms.NumericUpDown nudBrushSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSaveLevel;
        private System.Windows.Forms.TextBox tbLevelName;
    }
}