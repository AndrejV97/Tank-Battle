using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tank_Battle
{
    public partial class LevelCreatorForm : Form
    {
        private Level level = new Level("My Level", 256, 128, 792, 128);
        private Settings settings { get; set; }
        private Levels levels { get; set; }
        private List<Blast> blasts;
        private Point bp = new Point(512,512);
        private Player player1;
        private Player player2;
        private Point rndGen;
        private bool generating = false;

        public LevelCreatorForm(Settings settings, Levels levels, Player player1, Player player2)
        {
            InitializeComponent();

            this.player1 = player1;
            this.player2 = player2;

            this.settings = settings;
            this.levels = levels;
            this.level.terrain.Add(new Terrain(32, 256 - 32, 512, 512, true));
            this.level.terrain.Add(new Terrain(32 + 512, 256 - 32, 512, 512, true));
            this.blasts = new List<Blast>();

            tbLevelName.Text = level.name;
            rbTerrain.Checked = true;
            rbQuality32.Checked = true;
            rbFree.Checked = true;
        }

        //Step event
        private void tmrGameSpeed_Tick(object sender, EventArgs e)
        {
            destroyTerrain(settings.terrainQuality, 0, blasts.Count, 4);
            blastPhysics();
            updateControls();
            if (generating)
            randomizeTerrain();

            Invalidate();
        }

        //Draw event
        private void LevelCreatorForm_Paint(object sender, PaintEventArgs e)
        {
            //Terrain
            for (int i = 0; i < level.terrain.Count; i++)
            {
                Terrain t = level.terrain[i];

                if (t.destructable == false)
                {
                    e.Graphics.FillRectangle(Brushes.Black, t.x, t.y, t.width, t.height);
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(settings.color), t.x, t.y, t.width, t.height);
                    if (settings.debugTerrain)
                        e.Graphics.DrawRectangle(Pens.Black, t.x, t.y, t.width-1, t.height-1);
                }
            }

            //Players
            e.Graphics.DrawImage(player1.sprite, new Point((int)(player1.x - player1.offX), (int)(player1.y - player1.offY)));
            e.Graphics.DrawImage(player2.sprite, new Point((int)(player2.x - player2.offX), (int)(player2.y - player2.offY)));

            //Brush
            if (rbTerrain.Checked && generating==false)
            {
                if (rbFree.Checked)
                {
                    e.Graphics.DrawEllipse(Pens.Black, bp.X - (int)nudBrushSize.Value, bp.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                }

                if (rbSymmetrical.Checked)
                {
                    e.Graphics.DrawEllipse(Pens.Black, bp.X - (int)nudBrushSize.Value, bp.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                    e.Graphics.DrawEllipse(Pens.Black, this.Width - 17 - bp.X - (int)nudBrushSize.Value, bp.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                }

                if (rbAsymmetrical.Checked)
                {
                    e.Graphics.DrawEllipse(Pens.Black, bp.X - (int)nudBrushSize.Value, bp.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                    e.Graphics.DrawEllipse(Pens.Black, this.Width - 17 - bp.X - (int)nudBrushSize.Value, this.Height + 160 - bp.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                }
            }

            //Random
            if (generating)
            {
                if (rbFree.Checked)
                {
                    e.Graphics.DrawEllipse(Pens.Black, rndGen.X - (int)nudBrushSize.Value, rndGen.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                }

                if (rbSymmetrical.Checked)
                {
                    e.Graphics.DrawEllipse(Pens.Black, rndGen.X - (int)nudBrushSize.Value, rndGen.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                    e.Graphics.DrawEllipse(Pens.Black, this.Width - 17 - rndGen.X - (int)nudBrushSize.Value, rndGen.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                }

                if (rbAsymmetrical.Checked)
                {
                    e.Graphics.DrawEllipse(Pens.Black, rndGen.X - (int)nudBrushSize.Value, rndGen.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                    e.Graphics.DrawEllipse(Pens.Black, this.Width - 17 - rndGen.X - (int)nudBrushSize.Value, this.Height + 160 - rndGen.Y - (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value, 2 * (int)nudBrushSize.Value);
                }
            }
        }

        //Destroy terrain (step)
        private void destroyTerrain(int percision, int istart, int iend, int jstart)
        {
            for (int i = istart; i < iend; i++)
            {
                Blast b = blasts[i];

                for (int j = jstart - 4; j < level.terrain.Count; j++)
                {
                    Terrain t = level.terrain[j];

                    if (t.isColliding(b) && t.destructable)
                    {
                        int x = t.x;
                        int y = t.y;
                        int width = t.width;
                        int height = t.height;

                        level.terrain.Remove(t);
                        destroyTerrain(percision, i, i + 1, j);

                        if (width <= percision || height <= percision)
                        {
                            break;
                        }

                        Terrain gl = new Terrain(x, y, width / 2, height / 2, true);
                        Terrain gd = new Terrain(x + width / 2, y, width / 2, height / 2, true);
                        Terrain dl = new Terrain(x, y + height / 2, width / 2, height / 2, true);
                        Terrain dd = new Terrain(x + width / 2, y + height / 2, width / 2, height / 2, true);

                        level.terrain.Add(gl);
                        level.terrain.Add(gd);
                        level.terrain.Add(dl);
                        level.terrain.Add(dd);
                    }
                }
            }
        }

        //Blast physics (step)
        private void blastPhysics()
        {
            for (int i = 0; i < blasts.Count; i++)
                blasts.RemoveAt(i);
        }

        //Randomize terrain
        private void randomizeTerrain()
        {
            if (rbFree.Checked)
            {
                blasts.Add(new Blast(rndGen.X, rndGen.Y, (int)nudBrushSize.Value));
            }

            if (rbSymmetrical.Checked)
            {
                blasts.Add(new Blast(rndGen.X, rndGen.Y, (int)nudBrushSize.Value));
                blasts.Add(new Blast(this.Width - rndGen.X - 17, rndGen.Y, (int)nudBrushSize.Value));
            }

            if (rbAsymmetrical.Checked)
            {
                blasts.Add(new Blast(rndGen.X, rndGen.Y, (int)nudBrushSize.Value));
                blasts.Add(new Blast(this.Width - rndGen.X - 17, this.Height - rndGen.Y + 160, (int)nudBrushSize.Value));
            }

            rndGen = new Point(rndGen.X + 1, rndGen.Y + MenuForm.random.Next(-(int)nudBrushSize.Value, (int)nudBrushSize.Value + 1));

            if (rndGen.X == 1072)
            {
                generating = false;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                btnReset.Enabled = true;
                btnSaveLevel.Enabled = true;
            }
        }

        //Randomize terrain button
        private void btnRandomize_Click(object sender, EventArgs e)
        {
            if (generating)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                btnReset.Enabled = true;
                btnSaveLevel.Enabled = true;
                generating = false;
                return;
            }

            rndGen = new Point(32, MenuForm.random.Next(224, 737));
            generating = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            btnReset.Enabled = false;
            btnSaveLevel.Enabled = false;
        }

        //Update controls
        private void updateControls()
        {
            if (generating)
                btnRandomize.Text = "Stop";
            else
                btnRandomize.Text = "Randomize";

            if (rbQuality1.Checked)
                settings.terrainQuality = 1;
            if (rbQuality2.Checked)
                settings.terrainQuality = 2;
            if (rbQuality4.Checked)
                settings.terrainQuality = 4;
            if (rbQuality8.Checked)
                settings.terrainQuality = 8;
            if (rbQuality16.Checked)
                settings.terrainQuality = 16;
            if (rbQuality32.Checked)
                settings.terrainQuality = 32;

            if (cbDebugTerrain.Checked)
                settings.debugTerrain = true;
            else settings.debugTerrain = false;

            if (player1.x <= 48)
                player1.x = 48;
            if (player1.x >= 1039)
                player1.x = 1039;

            if (player2.x <= 48)
                player2.x = 48;
            if (player2.x >= 1039)
                player2.x = 1039;

            if (player1.y >= 735)
                player1.y = 735;
            if (player1.y <= 0)
                player1.y = 0;

            if (player2.y >= 735)
                player2.y = 735;
            if (player2.y <= 0)
                player2.y = 0;
        }

        //Mouse pressed
        private void LevelCreatorForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (generating)
                return;

            if (e.Button == MouseButtons.Left )
            {
                if (rbTerrain.Checked)
                {
                    if (rbFree.Checked)
                    {
                        blasts.Add(new Blast(e.Location.X, e.Location.Y, (int)nudBrushSize.Value));
                    }

                    if (rbSymmetrical.Checked)
                    {
                        blasts.Add(new Blast(e.Location.X, e.Location.Y, (int)nudBrushSize.Value));
                        blasts.Add(new Blast(this.Width - e.Location.X - 17, e.Location.Y, (int)nudBrushSize.Value));
                    }

                    if (rbAsymmetrical.Checked)
                    {
                        blasts.Add(new Blast(e.Location.X, e.Location.Y, (int)nudBrushSize.Value));
                        blasts.Add(new Blast(this.Width - e.Location.X - 17, this.Height - e.Location.Y + 160, (int)nudBrushSize.Value));
                    }
                }

                if (rbPlayer1.Checked)
                {
                    if (rbFree.Checked)
                    {
                        player1.x = e.Location.X;
                        player1.y = e.Location.Y;
                    }

                    if (rbSymmetrical.Checked)
                    {
                        player1.x = e.Location.X;
                        player1.y = e.Location.Y;
                        player2.x = this.Width - e.Location.X - 17;
                        player2.y = e.Location.Y;
                    }

                    if (rbAsymmetrical.Checked)
                    {
                        player1.x = e.Location.X;
                        player1.y = e.Location.Y;
                        player2.x = this.Width - e.Location.X - 17;
                        player2.y = this.Height - e.Location.Y + 160;
                    }
                }

                if (rbPlayer2.Checked)
                {
                    if (rbFree.Checked)
                    {
                        player2.x = e.Location.X;
                        player2.y = e.Location.Y;
                    }

                    if (rbSymmetrical.Checked)
                    {
                        player2.x = e.Location.X;
                        player2.y = e.Location.Y;
                        player1.x = this.Width - e.Location.X - 17;
                        player1.y = e.Location.Y;
                    }

                    if (rbAsymmetrical.Checked)
                    {
                        player2.x = e.Location.X;
                        player2.y = e.Location.Y;
                        player1.x = this.Width - e.Location.X - 17;
                        player1.y = this.Height - e.Location.Y + 60;
                    }
                }
            }

            bp = e.Location;
        }

        //Mouse held down
        private void LevelCreatorForm_MouseMove(object sender, MouseEventArgs e)
        {
            LevelCreatorForm_MouseDown(sender, e);
        }

        //Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            level = new Level("My Level", 256, 128, 792, 128);
            level.terrain.Add(new Terrain(32, 256 - 32, 512, 512, true));
            level.terrain.Add(new Terrain(32 + 512, 256 - 32, 512, 512, true));
            rbQuality1.Enabled = true;
            rbQuality2.Enabled = true;
            rbQuality4.Enabled = true;
            rbQuality8.Enabled = true;
            rbQuality16.Enabled = true;
            rbQuality32.Enabled = true;
            rbQuality32.Checked = true;
        }

        //Save level
        private void btnSaveLevel_Click(object sender, EventArgs e)
        {
            level.name = tbLevelName.Text;
            level.p1x = player1.x-20;
            level.p1y = player1.y-11;
            level.p2x = player2.x-20;
            level.p2y = player2.y-11;

            levels.levels.Add(level);

            System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            FileStream strm = new FileStream(Directory.GetCurrentDirectory() + @"\Levels\" + level.name + ".lvl", FileMode.Create, FileAccess.Write, FileShare.None);
            fmt.Serialize(strm, level);
            strm.Close();

            Dispose();
        }

        //Error name
        private void tbLevelName_Validating(object sender, CancelEventArgs e)
        {
            if (tbLevelName.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(tbLevelName, "Внесете име на левелот!");
            }
            else
            {
                errorProvider1.SetError(tbLevelName, null);
            }
        }

        //Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
