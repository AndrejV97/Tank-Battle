using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tank_Battle
{
    public partial class LevelSelectForm : Form
    {
        public Level level { get; set; }
        public Color tc { get; set; }
        public Color p1c { get; set; }
        public Color p2c { get; set; }

        public LevelSelectForm(Levels levels, Level level, Color tc, Color p1c, Color p2c)
        {
            InitializeComponent();

            this.level = level;
            this.tc = tc;
            this.p1c = p1c;
            this.p2c = p2c;

            for (int i = 0; i < levels.levels.Count; i++)
                lbLevels.Items.Add(levels.levels[i]);

            for (int i = 0; i < levels.levels.Count; i++)
            {
                if (level.name == levels.levels[i].name)
                {
                    lbLevels.SelectedIndex = i;
                    break;
                }
            }

            pbLevel.Image = drawLevel(level);
        }

        //If we change the level
        private void lbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbLevel.Image = drawLevel(lbLevels.SelectedItem as Level);
        }

        //Draw level
        private Bitmap drawLevel(Level level)
        {
            Bitmap lvl = new Bitmap(Properties.Resources.terrainImage, new Size(1024, 768));

            for (int i = 4; i < level.terrain.Count; i++)
            {
                Terrain t = level.terrain[i];
                for (int j = 0; j < t.width; j++)
                {
                    for (int k = 0; k < t.height; k++)
                    lvl.SetPixel(t.x - 32 + j, t.y + 32 + k, tc);
                }

            }

            for (int i = 0; i <= 33; i++)
            {
                for (int j = 0; j <= 21; j++)
                {
                    lvl.SetPixel((int)level.p1x-28 + i, (int)level.p1y+21 + j, p1c);
                    lvl.SetPixel((int)level.p2x-29 + i, (int)level.p2y+21 + j, p2c);
                }
            }

            return lvl;
        }

        //Accept
        private void button1_Click(object sender, EventArgs e)
        {
            level = lbLevels.SelectedItem as Level;
            Dispose();
        }

        //Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
