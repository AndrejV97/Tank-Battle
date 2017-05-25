using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Tank_Battle
{
    public partial class OptionsForm : Form
    {
        Player player1;
        Player player2;
        Settings settings;

        Bitmap p1OriginalSprite;
        Bitmap p2OriginalSprite;

        public OptionsForm(Player player1, Player player2, Settings settings)
        {
            InitializeComponent();

            this.player1 = player1;
            this.player2 = player2;
            
            p1OriginalSprite = player1.sprite;
            p2OriginalSprite = player2.sprite;

            tbPlayer1Name.Text = settings.p1Name;
            btnPlayer1Color.BackColor = settings.p1Color;
            lblIndex1.Text = Convert.ToString(settings.p1Index + 1);
            pbPlayer1Sprite.Image = setColor(player1.models[settings.p1Index], settings.p1Color);

            tbPlayer2Name.Text = settings.p2Name;
            btnPlayer2Color.BackColor = settings.p2Color;
            lblIndex2.Text = Convert.ToString(settings.p2Index + 1);
            pbPlayer2Sprite.Image = setColor(player2.models[settings.p2Index], settings.p2Color);
            

            this.settings = settings;
            if (settings.terrainQuality == 1) rbQuality1.Checked = true;
            if (settings.terrainQuality == 2) rbQuality2.Checked = true;
            if (settings.terrainQuality == 4) rbQuality4.Checked = true;
            if (settings.terrainQuality == 8) rbQuality8.Checked = true;
            if (settings.terrainQuality == 16) rbQuality16.Checked = true;
            if (settings.terrainQuality == 32) rbQuality32.Checked = true;
            cbDebugTerrain.Checked = settings.debugTerrain;
            cbDestructableTerrain.Checked = settings.destructableTerrain;
            btnTerrainColor.BackColor = settings.color;
            nudRoundTime.Value = settings.roundTime;
            nudRounds.Value = settings.rounds;
            cbSameWeapons.Checked = settings.sameWeapons;
            nudPlayerHealth.Value = settings.playerHealth;
            nudPlayerFuel.Value = settings.playerFuel;
            cbAllowJumping.Checked = settings.allowJumping;
            cbVisualIndicator.Checked = settings.visualIndicators;
            nudGravity.Value = Convert.ToDecimal(settings.gravity);
            nudJumpSpeed.Value = Convert.ToDecimal(settings.jumpSpeed);
        }

        //Choose color for player 1
        private void btnPlayer1Color_Click(object sender, EventArgs e)
        {
            ColorDialog color = new System.Windows.Forms.ColorDialog();

            if (color.ShowDialog() == DialogResult.OK)
            {
                btnPlayer1Color.BackColor = color.Color;
                pbPlayer1Sprite.Image = setColor(player1.models[settings.p1Index], color.Color);
            }
        }

        //Choose color for player 2
        private void btnPlayer2Color_Click(object sender, EventArgs e)
        {
            ColorDialog color = new System.Windows.Forms.ColorDialog();

            if (color.ShowDialog() == DialogResult.OK)
            {
                btnPlayer2Color.BackColor = color.Color;
                pbPlayer2Sprite.Image = setColor(player2.models[settings.p2Index], color.Color);
            }
        }

        //Choose color for terrain
        private void btnTerrainColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new System.Windows.Forms.ColorDialog();

            if (color.ShowDialog() == DialogResult.OK)
            {
                btnTerrainColor.BackColor = color.Color;
            }
        }

        //Rotate player 1 selection left
        private void btnLeft1_Click(object sender, EventArgs e)
        {
            player1.spriteIndex--;

            if (player1.spriteIndex == -1)
                player1.spriteIndex = player1.models.Count - 1;

            player1.sprite = player1.models[player1.spriteIndex];
            pbPlayer1Sprite.Image = setColor(player1.models[player1.spriteIndex], btnPlayer1Color.BackColor);
            lblIndex1.Text = Convert.ToString(player1.spriteIndex+1);
        }

        //Rotate player 1 selection right
        private void btnRight1_Click(object sender, EventArgs e)
        {
            player1.spriteIndex++;

            if (player1.spriteIndex == player1.models.Count)
                player1.spriteIndex = 0;

            player1.sprite = player1.models[player1.spriteIndex];
            pbPlayer1Sprite.Image = setColor(player1.models[player1.spriteIndex], btnPlayer1Color.BackColor);
            lblIndex1.Text = Convert.ToString(player1.spriteIndex + 1);
        }

        //Rotate player 2 selection left
        private void btnLeft2_Click(object sender, EventArgs e)
        {
            player2.spriteIndex--;

            if (player2.spriteIndex == -1)
                player2.spriteIndex = player2.models.Count - 1;

            player2.sprite = player2.models[player2.spriteIndex];
            pbPlayer2Sprite.Image = setColor(player2.models[player2.spriteIndex], btnPlayer2Color.BackColor);
            lblIndex2.Text = Convert.ToString(player2.spriteIndex + 1);
        }

        //Rotate player 2 selection right
        private void btnRight2_Click(object sender, EventArgs e)
        {
            player2.spriteIndex++;

            if (player2.spriteIndex == player2.models.Count)
                player2.spriteIndex = 0;

            player2.sprite = player2.models[player2.spriteIndex];
            pbPlayer2Sprite.Image = setColor(player2.models[player2.spriteIndex], btnPlayer2Color.BackColor);
            lblIndex2.Text = Convert.ToString(player2.spriteIndex + 1);
        }

        //Accept
        private void btnAccept_Click(object sender, EventArgs e)
        {
            player1.name = tbPlayer1Name.Text;
            player1.color = btnPlayer1Color.BackColor;
            player1.spriteIndex = Convert.ToInt32(lblIndex1.Text)-1;
            player1.sprite = player1.models[player1.spriteIndex];

            player2.name = tbPlayer2Name.Text;
            player2.color = btnPlayer2Color.BackColor;
            player2.spriteIndex = Convert.ToInt32(lblIndex2.Text)-1;
            player2.sprite = player2.models[player2.spriteIndex];

            if (rbQuality1.Checked) settings.terrainQuality = 1;
            if (rbQuality2.Checked) settings.terrainQuality = 2;
            if (rbQuality4.Checked) settings.terrainQuality = 4;
            if (rbQuality8.Checked) settings.terrainQuality = 8;
            if (rbQuality16.Checked) settings.terrainQuality = 16;
            if (rbQuality32.Checked) settings.terrainQuality = 32;

            settings.debugTerrain = cbDebugTerrain.Checked;
            settings.destructableTerrain = cbDestructableTerrain.Checked;
            settings.color = btnTerrainColor.BackColor;
            settings.roundTime = (int) nudRoundTime.Value;
            settings.rounds = (int) nudRounds.Value;
            settings.sameWeapons = cbSameWeapons.Checked;
            settings.playerHealth = (int) nudPlayerHealth.Value;
            settings.playerFuel = (int) nudPlayerFuel.Value;
            settings.allowJumping = cbAllowJumping.Checked;
            settings.visualIndicators = cbVisualIndicator.Checked;
            settings.gravity = (double) nudGravity.Value;
            settings.jumpSpeed = (double)nudJumpSpeed.Value;
            settings.p1Name = player1.name;
            settings.p1Color = player1.color;
            settings.p1Index = player1.spriteIndex;
            settings.p2Name = player2.name;
            settings.p2Color = player2.color;
            settings.p2Index = player2.spriteIndex;

            System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            FileStream strm = new FileStream("settings.set", FileMode.Create, FileAccess.Write, FileShare.None);
            fmt.Serialize(strm, settings);
            strm.Close();

            Dispose();
        }

        //Reset to defaults
        private void btnResetToDefaults_Click(object sender, EventArgs e)
        {
            rbQuality1.Checked = true;
            cbDebugTerrain.Checked = false;
            cbDestructableTerrain.Checked = true;
            btnTerrainColor.BackColor = Color.Green;
            nudRoundTime.Value = 30;
            nudRounds.Value = 10;
            cbSameWeapons.Checked = true;
            nudPlayerHealth.Value = 300;
            nudPlayerFuel.Value = 200;
            cbAllowJumping.Checked = true;
            cbVisualIndicator.Checked = true;
            nudGravity.Value = Convert.ToDecimal(0.4);
            nudJumpSpeed.Value = Convert.ToDecimal(8);
        }

        //Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            player1.sprite = p1OriginalSprite;
            player2.sprite = p2OriginalSprite;
            Dispose();
        }

        //Set the color of the tank
        private Bitmap setColor(Bitmap sprite, Color color)
        {
            Color originalColor = sprite.GetPixel(20, 20);

            for (int x = 0; x < sprite.Width; x++)
            {
                for (int y = 0; y < sprite.Height; y++)
                {
                    if (sprite.GetPixel(x, y) == originalColor)
                    {
                        sprite.SetPixel(x, y, color);
                    }
                }
            }
            return sprite;
        }

        //Valid player 1 name
        private bool validPlayer1Name()
        {
            if (tbPlayer1Name.Text.Trim().Length > 0)
                return true;
            else return false;
        }

        //Valid player 2 name
        private bool validPlayer2Name()
        {
            if (tbPlayer2Name.Text.Trim().Length > 0)
                return true;
            else return false;
        }

        //Error 
        private void tbPlayer1Name_Validating(object sender, CancelEventArgs e)
        {
            if (!validPlayer1Name())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPlayer1Name, "Внесете име на првиот играч!");
            }
            else
            {
                errorProvider1.SetError(tbPlayer1Name, null);
            }
        }

        //Error 
        private void tbPlayer2Name_Validating(object sender, CancelEventArgs e)
        {
            if (!validPlayer2Name())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPlayer2Name, "Внесете име на вториот играч!");
            }
            else
            {
                errorProvider1.SetError(tbPlayer2Name, null);
            }
        }
    }
}
