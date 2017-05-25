namespace Tank_Battle
{
    partial class GameForm
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
            this.lblPlayer1Name = new System.Windows.Forms.Label();
            this.lblPlayer2Name = new System.Windows.Forms.Label();
            this.lblPlayer1ShootAngle = new System.Windows.Forms.Label();
            this.lblPlayer1ShootPower = new System.Windows.Forms.Label();
            this.btnPlayer1Shoot = new System.Windows.Forms.Button();
            this.cbPlayer1Weapons = new System.Windows.Forms.ComboBox();
            this.pbPlayer1Fuel = new System.Windows.Forms.ProgressBar();
            this.pbPlayer1Health = new System.Windows.Forms.ProgressBar();
            this.lblPlayer1Fuel = new System.Windows.Forms.Label();
            this.lblPlayer1Health = new System.Windows.Forms.Label();
            this.lblPlayer2ShootPower = new System.Windows.Forms.Label();
            this.lblPlayer2ShootAngle = new System.Windows.Forms.Label();
            this.cbPlayer2Weapons = new System.Windows.Forms.ComboBox();
            this.btnPlayer2Shoot = new System.Windows.Forms.Button();
            this.pbPlayer2Health = new System.Windows.Forms.ProgressBar();
            this.pbPlayer2Fuel = new System.Windows.Forms.ProgressBar();
            this.lblPlayer2Fuel = new System.Windows.Forms.Label();
            this.lblPlayer2Health = new System.Windows.Forms.Label();
            this.lblPlayerTurn = new System.Windows.Forms.Label();
            this.lblRoundTime = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tmrGameSpeed
            // 
            this.tmrGameSpeed.Enabled = true;
            this.tmrGameSpeed.Interval = 15;
            this.tmrGameSpeed.Tick += new System.EventHandler(this.tmrGameSpeed_Tick);
            // 
            // lblPlayer1Name
            // 
            this.lblPlayer1Name.Location = new System.Drawing.Point(32, 0);
            this.lblPlayer1Name.Name = "lblPlayer1Name";
            this.lblPlayer1Name.Size = new System.Drawing.Size(196, 13);
            this.lblPlayer1Name.TabIndex = 0;
            this.lblPlayer1Name.Text = "Player 1 Name:";
            this.lblPlayer1Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlayer2Name
            // 
            this.lblPlayer2Name.Location = new System.Drawing.Point(860, 0);
            this.lblPlayer2Name.Name = "lblPlayer2Name";
            this.lblPlayer2Name.Size = new System.Drawing.Size(196, 13);
            this.lblPlayer2Name.TabIndex = 1;
            this.lblPlayer2Name.Text = "Player 2 Name:";
            this.lblPlayer2Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayer1ShootAngle
            // 
            this.lblPlayer1ShootAngle.Location = new System.Drawing.Point(32, 13);
            this.lblPlayer1ShootAngle.Name = "lblPlayer1ShootAngle";
            this.lblPlayer1ShootAngle.Size = new System.Drawing.Size(196, 13);
            this.lblPlayer1ShootAngle.TabIndex = 2;
            this.lblPlayer1ShootAngle.Text = "Shoot angle:";
            this.lblPlayer1ShootAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlayer1ShootPower
            // 
            this.lblPlayer1ShootPower.Location = new System.Drawing.Point(32, 26);
            this.lblPlayer1ShootPower.Name = "lblPlayer1ShootPower";
            this.lblPlayer1ShootPower.Size = new System.Drawing.Size(196, 13);
            this.lblPlayer1ShootPower.TabIndex = 3;
            this.lblPlayer1ShootPower.Text = "Shoot power:";
            this.lblPlayer1ShootPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPlayer1Shoot
            // 
            this.btnPlayer1Shoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlayer1Shoot.Location = new System.Drawing.Point(304, 22);
            this.btnPlayer1Shoot.Name = "btnPlayer1Shoot";
            this.btnPlayer1Shoot.Size = new System.Drawing.Size(72, 72);
            this.btnPlayer1Shoot.TabIndex = 4;
            this.btnPlayer1Shoot.TabStop = false;
            this.btnPlayer1Shoot.Text = "Shoot";
            this.btnPlayer1Shoot.UseVisualStyleBackColor = true;
            this.btnPlayer1Shoot.Click += new System.EventHandler(this.btnPlayer1Shoot_Click);
            this.btnPlayer1Shoot.MouseLeave += new System.EventHandler(this.btnPlayer1Shoot_MouseLeave);
            // 
            // cbPlayer1Weapons
            // 
            this.cbPlayer1Weapons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayer1Weapons.FormattingEnabled = true;
            this.cbPlayer1Weapons.Location = new System.Drawing.Point(234, 0);
            this.cbPlayer1Weapons.MaxDropDownItems = 30;
            this.cbPlayer1Weapons.Name = "cbPlayer1Weapons";
            this.cbPlayer1Weapons.Size = new System.Drawing.Size(142, 21);
            this.cbPlayer1Weapons.TabIndex = 5;
            this.cbPlayer1Weapons.TabStop = false;
            this.cbPlayer1Weapons.SelectedIndexChanged += new System.EventHandler(this.cbPlayer1Weapons_SelectedIndexChanged);
            // 
            // pbPlayer1Fuel
            // 
            this.pbPlayer1Fuel.Location = new System.Drawing.Point(35, 42);
            this.pbPlayer1Fuel.Name = "pbPlayer1Fuel";
            this.pbPlayer1Fuel.Size = new System.Drawing.Size(180, 23);
            this.pbPlayer1Fuel.TabIndex = 6;
            // 
            // pbPlayer1Health
            // 
            this.pbPlayer1Health.Location = new System.Drawing.Point(35, 71);
            this.pbPlayer1Health.Name = "pbPlayer1Health";
            this.pbPlayer1Health.Size = new System.Drawing.Size(180, 23);
            this.pbPlayer1Health.TabIndex = 7;
            // 
            // lblPlayer1Fuel
            // 
            this.lblPlayer1Fuel.Location = new System.Drawing.Point(221, 42);
            this.lblPlayer1Fuel.Name = "lblPlayer1Fuel";
            this.lblPlayer1Fuel.Size = new System.Drawing.Size(77, 23);
            this.lblPlayer1Fuel.TabIndex = 8;
            this.lblPlayer1Fuel.Text = "Fuel";
            this.lblPlayer1Fuel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlayer1Health
            // 
            this.lblPlayer1Health.Location = new System.Drawing.Point(221, 71);
            this.lblPlayer1Health.Name = "lblPlayer1Health";
            this.lblPlayer1Health.Size = new System.Drawing.Size(77, 23);
            this.lblPlayer1Health.TabIndex = 9;
            this.lblPlayer1Health.Text = "Health";
            this.lblPlayer1Health.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlayer2ShootPower
            // 
            this.lblPlayer2ShootPower.Location = new System.Drawing.Point(860, 26);
            this.lblPlayer2ShootPower.Name = "lblPlayer2ShootPower";
            this.lblPlayer2ShootPower.Size = new System.Drawing.Size(196, 13);
            this.lblPlayer2ShootPower.TabIndex = 11;
            this.lblPlayer2ShootPower.Text = "Shoot power:";
            this.lblPlayer2ShootPower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayer2ShootAngle
            // 
            this.lblPlayer2ShootAngle.Location = new System.Drawing.Point(860, 13);
            this.lblPlayer2ShootAngle.Name = "lblPlayer2ShootAngle";
            this.lblPlayer2ShootAngle.Size = new System.Drawing.Size(196, 13);
            this.lblPlayer2ShootAngle.TabIndex = 10;
            this.lblPlayer2ShootAngle.Text = "Shoot angle:";
            this.lblPlayer2ShootAngle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbPlayer2Weapons
            // 
            this.cbPlayer2Weapons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayer2Weapons.FormattingEnabled = true;
            this.cbPlayer2Weapons.Location = new System.Drawing.Point(712, 0);
            this.cbPlayer2Weapons.MaxDropDownItems = 30;
            this.cbPlayer2Weapons.Name = "cbPlayer2Weapons";
            this.cbPlayer2Weapons.Size = new System.Drawing.Size(142, 21);
            this.cbPlayer2Weapons.TabIndex = 13;
            this.cbPlayer2Weapons.TabStop = false;
            this.cbPlayer2Weapons.SelectedIndexChanged += new System.EventHandler(this.cbPlayer2Weapons_SelectedIndexChanged);
            // 
            // btnPlayer2Shoot
            // 
            this.btnPlayer2Shoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlayer2Shoot.Location = new System.Drawing.Point(712, 22);
            this.btnPlayer2Shoot.Name = "btnPlayer2Shoot";
            this.btnPlayer2Shoot.Size = new System.Drawing.Size(72, 72);
            this.btnPlayer2Shoot.TabIndex = 12;
            this.btnPlayer2Shoot.TabStop = false;
            this.btnPlayer2Shoot.Text = "Shoot";
            this.btnPlayer2Shoot.UseVisualStyleBackColor = true;
            this.btnPlayer2Shoot.Click += new System.EventHandler(this.btnPlayer2Shoot_Click);
            this.btnPlayer2Shoot.MouseLeave += new System.EventHandler(this.btnPlayer2Shoot_MouseLeave);
            // 
            // pbPlayer2Health
            // 
            this.pbPlayer2Health.Location = new System.Drawing.Point(873, 71);
            this.pbPlayer2Health.Name = "pbPlayer2Health";
            this.pbPlayer2Health.Size = new System.Drawing.Size(180, 23);
            this.pbPlayer2Health.TabIndex = 15;
            // 
            // pbPlayer2Fuel
            // 
            this.pbPlayer2Fuel.Location = new System.Drawing.Point(873, 43);
            this.pbPlayer2Fuel.Name = "pbPlayer2Fuel";
            this.pbPlayer2Fuel.Size = new System.Drawing.Size(180, 23);
            this.pbPlayer2Fuel.TabIndex = 14;
            // 
            // lblPlayer2Fuel
            // 
            this.lblPlayer2Fuel.Location = new System.Drawing.Point(790, 43);
            this.lblPlayer2Fuel.Name = "lblPlayer2Fuel";
            this.lblPlayer2Fuel.Size = new System.Drawing.Size(77, 23);
            this.lblPlayer2Fuel.TabIndex = 16;
            this.lblPlayer2Fuel.Text = "Fuel";
            this.lblPlayer2Fuel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayer2Health
            // 
            this.lblPlayer2Health.Location = new System.Drawing.Point(790, 71);
            this.lblPlayer2Health.Name = "lblPlayer2Health";
            this.lblPlayer2Health.Size = new System.Drawing.Size(77, 23);
            this.lblPlayer2Health.TabIndex = 17;
            this.lblPlayer2Health.Text = "Health";
            this.lblPlayer2Health.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPlayerTurn
            // 
            this.lblPlayerTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPlayerTurn.Location = new System.Drawing.Point(382, -3);
            this.lblPlayerTurn.Name = "lblPlayerTurn";
            this.lblPlayerTurn.Size = new System.Drawing.Size(324, 42);
            this.lblPlayerTurn.TabIndex = 18;
            this.lblPlayerTurn.Text = "Player X\'s turn:";
            this.lblPlayerTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRoundTime
            // 
            this.lblRoundTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRoundTime.Location = new System.Drawing.Point(382, 43);
            this.lblRoundTime.Name = "lblRoundTime";
            this.lblRoundTime.Size = new System.Drawing.Size(331, 42);
            this.lblRoundTime.TabIndex = 19;
            this.lblRoundTime.Text = "30";
            this.lblRoundTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(389, 192);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(317, 133);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 768);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblRoundTime);
            this.Controls.Add(this.lblPlayerTurn);
            this.Controls.Add(this.lblPlayer2Health);
            this.Controls.Add(this.lblPlayer2Fuel);
            this.Controls.Add(this.pbPlayer2Health);
            this.Controls.Add(this.pbPlayer2Fuel);
            this.Controls.Add(this.cbPlayer2Weapons);
            this.Controls.Add(this.btnPlayer2Shoot);
            this.Controls.Add(this.lblPlayer2ShootPower);
            this.Controls.Add(this.lblPlayer2ShootAngle);
            this.Controls.Add(this.lblPlayer1Health);
            this.Controls.Add(this.lblPlayer1Fuel);
            this.Controls.Add(this.pbPlayer1Health);
            this.Controls.Add(this.pbPlayer1Fuel);
            this.Controls.Add(this.cbPlayer1Weapons);
            this.Controls.Add(this.btnPlayer1Shoot);
            this.Controls.Add(this.lblPlayer1ShootPower);
            this.Controls.Add(this.lblPlayer1ShootAngle);
            this.Controls.Add(this.lblPlayer2Name);
            this.Controls.Add(this.lblPlayer1Name);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GameForm";
            this.Text = "Tank Battle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameForm_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGameSpeed;
        private System.Windows.Forms.Label lblPlayer1Name;
        private System.Windows.Forms.Label lblPlayer2Name;
        private System.Windows.Forms.Label lblPlayer1ShootAngle;
        private System.Windows.Forms.Label lblPlayer1ShootPower;
        private System.Windows.Forms.Button btnPlayer1Shoot;
        private System.Windows.Forms.ComboBox cbPlayer1Weapons;
        private System.Windows.Forms.ProgressBar pbPlayer1Fuel;
        private System.Windows.Forms.ProgressBar pbPlayer1Health;
        private System.Windows.Forms.Label lblPlayer1Fuel;
        private System.Windows.Forms.Label lblPlayer1Health;
        private System.Windows.Forms.Label lblPlayer2ShootPower;
        private System.Windows.Forms.Label lblPlayer2ShootAngle;
        private System.Windows.Forms.ComboBox cbPlayer2Weapons;
        private System.Windows.Forms.Button btnPlayer2Shoot;
        private System.Windows.Forms.ProgressBar pbPlayer2Health;
        private System.Windows.Forms.ProgressBar pbPlayer2Fuel;
        private System.Windows.Forms.Label lblPlayer2Fuel;
        private System.Windows.Forms.Label lblPlayer2Health;
        private System.Windows.Forms.Label lblPlayerTurn;
        private System.Windows.Forms.Label lblRoundTime;
        private System.Windows.Forms.Button btnExit;
    }
}