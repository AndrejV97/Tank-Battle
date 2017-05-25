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
    public partial class MenuForm : Form
    {
        public static Random random = new Random();

        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Settings settings { get; set; }
        public Levels levels = new Levels();
        public Level level { get; set; }

        public MenuForm()
        {
            InitializeComponent();

            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Levels");

            addLevels();

            int rndLvl = random.Next(levels.levels.Count);
            level = new Level(levels.levels[rndLvl].name, levels.levels[rndLvl].p1x, levels.levels[rndLvl].p1y, levels.levels[rndLvl].p2x, levels.levels[rndLvl].p2y);
            level.terrain = levels.levels[rndLvl].terrain;
            player1 = new Player("Player 1", 0, Color.Blue, level.p1x, level.p1y);
            player2 = new Player("Player 2", 0, Color.Red, level.p2x, level.p2y);

            string[] set = System.IO.Directory.GetFiles(Directory.GetCurrentDirectory(), "settings.set");
            if (set.Length == 0)
            {
                settings = new Settings(false, 1, true, Color.Green, 30, 10, true, 300, 200, true, true, 0.4, 8, player1.name, player1.color, player1.spriteIndex, player2.name, player2.color, player2.spriteIndex);

                System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                FileStream strm = new FileStream("settings.set", FileMode.Create, FileAccess.Write, FileShare.None);
                fmt.Serialize(strm, settings);
                strm.Close();
            }
            else
            {
                System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                FileStream strm = new FileStream("settings.set", FileMode.Open, FileAccess.Read, FileShare.None);
                settings = (Settings)fmt.Deserialize(strm);
                player1.name = settings.p1Name;
                player1.color = settings.p1Color;
                player1.spriteIndex = settings.p1Index;
                player2.name = settings.p2Name;
                player2.color = settings.p2Color;
                player2.spriteIndex = settings.p2Index;
                strm.Close();
            }
        }

        //New Game
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Player player1 = new Player(this.player1.name, this.player1.spriteIndex, this.player1.color, level.p1x, level.p1y);
            Player player2 = new Player(this.player2.name, this.player2.spriteIndex, this.player2.color, level.p2x, level.p2y);
            setColor(player1.sprite, player1.color);
            setColor(player2.sprite, player2.color);
            Settings set = new Settings(settings.debugTerrain, settings.terrainQuality, settings.destructableTerrain,
                                        settings.color, settings.roundTime, settings.rounds, settings.sameWeapons,
                                        settings.playerHealth, settings.playerFuel, settings.allowJumping,
                                        settings.visualIndicators, settings.gravity, settings.jumpSpeed,
                                        settings.p1Name, settings.p1Color, settings.p1Index,
                                        settings.p2Name, settings.p2Color, settings.p2Index);
            Level lvl = new Level(level.name, level.p1x, level.p1y, level.p2x, level.p2y);
            lvl.terrain.Clear();
            for (int i = 0; i < this.level.terrain.Count; i++ )
                lvl.terrain.Add(this.level.terrain[i]);
            lvl.p1x = level.p1x;
            lvl.p1y = level.p1y;
            lvl.p2x = level.p2x;
            lvl.p2y = level.p2y;
            GameForm gameForm = new GameForm(player1, player2, set, lvl);
            gameForm.ShowDialog();
        }

        //Level Select
        private void btnLevelSelect_Click(object sender, EventArgs e)
        {
            LevelSelectForm levelSelectForm = new LevelSelectForm(levels, level, settings.color, player1.color, player2.color);
            levelSelectForm.ShowDialog();
            level = levelSelectForm.level;
        }

        //Level Creator
        private void btnLevelCreate_Click(object sender, EventArgs e)
        {
            Player p1 = new Player(player1.name, player1.spriteIndex, player1.color, 256, 128);
            Player p2 = new Player(player2.name, player2.spriteIndex, player2.color, 792, 128);
            setColor(p1.sprite, p1.color);
            setColor(p2.sprite, p2.color);
            LevelCreatorForm levelCreatorForm = new LevelCreatorForm(new Settings(false, 1, true, settings.color, 30, 10, true, 300, 200, true, true, 0.4, 8,
                     settings.p1Name, settings.p1Color, settings.p1Index, settings.p2Name, settings.p2Color, settings.p2Index), levels, p1, p2);
            levelCreatorForm.ShowDialog();
        }

        //Options
        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsForm optionsForm = new OptionsForm(player1, player2, settings);
            optionsForm.ShowDialog();
        }

        //Read me!
        private void btnInfo_Click(object sender, EventArgs e)
        {
            string info = "";

            info += "Контроли:\n";
            info += "A, D - Движење на тенкот лево и десно\n";
            info += "W, S - Јачина со која ќе пукате\n";
            info += "Q, E - Агол под кој ќе пукате\n";
            info += "R - Испукај го селектираниот проектил\n";
            info += "Space - Скокање\n\n";

            info += "Дополнително, место да користите W, S, Q, E,\n";
            info += "можете да кликнете со маусот околу играчот за\n";
            info += "автоматски да ви се наместат јачината и аголот.\n\n";

            info += "Типот на проектил кој што сакате да го пукате\n";
            info += "можете да го изберете од горниот дел на прозорецот\n";
            info += "каде што исто така има копче за пукање.\n\n";

            info += "Целта на играта е да го уништите непријателскиот тенк,\n";
            info += "или да имате повеќе живот кога ќе истечат сите рунди.\n\n";

            info += "Забелешка: Доколку играта ви кочи, можете да смените\n";
            info += "опции или да одберете левел со помалку терен.\n\n";

            info += "                                       -Изработил: Андреј Велевски";

            MessageBox.Show(info, "Проектна задача по визуелно програмирање 2017", MessageBoxButtons.OK);
        }

        //Add pre-generated levels
        private void addLevels()
        {
            System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            FileStream strm;
            string[] levelFiles = System.IO.Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Levels", "*.lvl");

            if (levelFiles.Length == 0)
                levels.levels.Add(new Level("Blank",256,512,792, 512));
            
            for (int i = 0; i < levelFiles.Length; i++)
            {
                strm = new FileStream(levelFiles[i], FileMode.Open, FileAccess.Read, FileShare.None);
                Level lvl = (Level)fmt.Deserialize(strm);
                strm.Close();
                levels.levels.Add(lvl);
            }
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

        //Quit Game
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
