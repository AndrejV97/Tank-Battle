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
    public partial class GameForm : Form
    {
        private Player player1;
        private Player player2;
        private Settings settings;

        private Player turn;
        private int roundTime;
        private int rounds;

        public List<Projectile> projectiles = new List<Projectile>();
        public List<Blast> blasts = new List<Blast>();
        private List<AfterBlast> afterBlasts = new List<AfterBlast>();

        private List<Terrain> terrain;

        public bool canInteract = true;

        //Initialization
        public GameForm(Player player1, Player player2, Settings settings, Level level)
        {
            InitializeComponent();

            this.settings = settings;
            this.terrain = level.terrain;

            this.player1 = player1;
            this.player2 = player2;

            player1.health = settings.playerHealth;
            player1.fuel = settings.playerFuel;
            player1.gravity = settings.gravity;
            player1.jumpSpeed = settings.jumpSpeed;

            player2.health = settings.playerHealth;
            player2.fuel = settings.playerFuel;
            player2.gravity = settings.gravity;
            player2.jumpSpeed = settings.jumpSpeed;

            this.player1.weapons.addWeapons(settings.rounds);

            if (settings.sameWeapons)
            {
                for (int i = 0; i < player1.weapons.weapons.Count; i++)
                    player2.weapons.weapons.Add(new Weapon(player1.weapons.weapons[i].name, player1.weapons.weapons[i].amount));
            }
            else
                this.player2.weapons.addWeapons(settings.rounds);

            for (int i = 0; i < player1.weapons.weapons.Count(); i++)
                cbPlayer1Weapons.Items.Add(player1.weapons.weapons[i].ToString());
            for (int i = 0; i < player2.weapons.weapons.Count(); i++)
                cbPlayer2Weapons.Items.Add(player2.weapons.weapons[i].ToString());

            lblPlayer1Name.Text = player1.name;
            lblPlayer1Name.ForeColor = player1.color;
            lblPlayer1ShootAngle.ForeColor = player1.color;
            lblPlayer1ShootPower.ForeColor = player1.color;
            cbPlayer1Weapons.SelectedIndex = player1.selectedWeapon;
            lblPlayer1Fuel.ForeColor = player1.color;
            lblPlayer1Health.ForeColor = player1.color;
            pbPlayer1Fuel.Maximum = player1.fuel;
            pbPlayer1Health.Maximum = player1.health;

            lblPlayer2Name.Text = player2.name;
            lblPlayer2Name.ForeColor = player2.color;
            lblPlayer2ShootAngle.ForeColor = player2.color;
            lblPlayer2ShootPower.ForeColor = player2.color;
            cbPlayer2Weapons.SelectedIndex = player2.selectedWeapon;
            lblPlayer2Fuel.ForeColor = player2.color;
            lblPlayer2Health.ForeColor = player2.color;
            pbPlayer2Fuel.Maximum = player2.fuel;
            pbPlayer2Health.Maximum = player2.health;

            this.turn = player1;
            this.roundTime = settings.roundTime * 100;
            this.rounds = settings.rounds;
            btnPlayer2Shoot.Enabled = false;
            cbPlayer2Weapons.Enabled = false;

            btnExit.Visible = false;
        }

        //Step event
        private void tmrGameSpeed_Tick(object sender, EventArgs e)
        {
            projectilePhysics();
            if (settings.destructableTerrain)
                destroyTerrain(settings.terrainQuality, 0, blasts.Count, 4);
            playerPhysics(player1);
            playerPhysics(player2);
            blastPhysics();
            afterBlastDecay();

            updateControls();
            gameLogic();

            Invalidate();
        }

        //Draw event
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            //Terrain
            for (int i = 0; i < terrain.Count; i++)
            {
                Terrain t = terrain[i];

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
            Bitmap rotatedPlayer;
            Point from;
            Point to;

            //Visual indicators for players
            if (settings.visualIndicators)
            {
                Color c = Color.FromArgb(64, turn.color);
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(c), 1), (int)(turn.x - turn.maxPower), (int)(turn.y - turn.offY / 2 - turn.maxPower), 2 * turn.maxPower, 2 * turn.maxPower);
                from = new Point((int)(turn.x), (int)(turn.y - turn.offY / 2));
                to = new Point((int)(turn.x + turn.shootPower * Math.Cos(degToRad(-turn.shootAngle))), (int)(turn.y - turn.offY / 2 + turn.shootPower * Math.Sin(degToRad(-turn.shootAngle))));
                Pen pen = new Pen(new SolidBrush(c), 1);
                e.Graphics.FillPie(new SolidBrush(c), new Rectangle((int)(turn.x - turn.shootPower), (int)(turn.y - turn.offY / 2 - turn.shootPower), (int)(2 * turn.shootPower), (int)(2 * turn.shootPower)), (float)-turn.shootAngle - 5, 10);
            }

            //The players and guns
            from = new Point((int)(player1.x - 2 * Math.Cos(degToRad(-player1.shootAngle))), (int)(player1.y - player1.offY / 2 - 2 * Math.Sin(degToRad(-player1.shootAngle))));
            to = new Point((int)(player1.x + player1.cannonLength * Math.Cos(degToRad(-player1.shootAngle))), (int)(player1.y - player1.offY / 2 + player1.cannonLength * Math.Sin(degToRad(-player1.shootAngle))));
            e.Graphics.DrawLine(new Pen(new SolidBrush(player1.color), 4), from, to);
            rotatedPlayer = rotateImageByAngle(player1.sprite, (float)clamp(player1.angle, -player1.climbAngle, player1.climbAngle));
            e.Graphics.DrawImage(rotatedPlayer, new Point((int)(player1.x - player1.offX), (int)(player1.y - player1.offY)));
            
            from = new Point((int)player2.x, (int)player2.y - player2.offY / 2);
            to = new Point((int)(player2.x + player2.cannonLength * Math.Cos(degToRad(-player2.shootAngle))), (int)(player2.y - player2.offY / 2 + player2.cannonLength * Math.Sin(degToRad(-player2.shootAngle))));
            e.Graphics.DrawLine(new Pen(new SolidBrush(player2.color), 4), from, to);
            rotatedPlayer = rotateImageByAngle(player2.sprite, (float)clamp(player2.angle, -player2.climbAngle, player2.climbAngle));
            e.Graphics.DrawImage(rotatedPlayer, new Point((int)(player2.x - player2.offX), (int)(player2.y - player2.offY)));
            rotatedPlayer.Dispose();

            //Projectiles
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles[i];

                e.Graphics.FillEllipse(new SolidBrush(turn.color), (int)p.x - 3, (int)p.y - 3, 6, 6);
                e.Graphics.DrawEllipse(Pens.Black, (int)p.x - 2, (int)p.y - 2, 4, 4);
            }

            //AfterBlasts
            for (int i = 0; i < afterBlasts.Count; i++)
            {
                AfterBlast ab = afterBlasts[i];
                e.Graphics.FillEllipse(new SolidBrush(ab.color), (int)(ab.x - ab.radius), (int)(ab.y - ab.radius), 2 * ab.radius, 2 * ab.radius);
            }
        }

        //When the game ends
        private void gameOver()
        {
            if (player1.health > player2.health)
            {
                lblPlayerTurn.Text = player1.name + " wins !!!";
                lblPlayerTurn.ForeColor = player1.color;
            }

            if (player1.health < player2.health)
            {
                lblPlayerTurn.Text = player2.name + " wins !!!";
                lblPlayerTurn.ForeColor = player2.color;
            }

            if (player1.health == player2.health)
            {
                lblPlayerTurn.Text = "Draw. Nobody wins !!!";
                lblPlayerTurn.ForeColor = Color.Black;
            }

            lblRoundTime.Text = "GAME OVER";
            btnPlayer1Shoot.Enabled = false;
            cbPlayer1Weapons.Enabled = false;
            btnPlayer2Shoot.Enabled = false;
            cbPlayer2Weapons.Enabled = false;
            btnExit.Visible = true;
            canInteract = false;
        }

        //Game logic (step)
        private void gameLogic()
        {
            if (rounds == 0 || player1.health == 0 || player2.health == 0)
            {
                gameOver();
                return;
            }

            if (roundTime > 0)
            {
                roundTime --;
            }

            if (roundTime == 0 && projectiles.Count==0 && afterBlasts.Count==0)
            {
                roundTime = settings.roundTime * 100;
                canInteract = true;

                if (turn == player1)
                {
                    turn = player2;
                    player2.fuel = pbPlayer2Fuel.Maximum;
                    btnPlayer1Shoot.Enabled = false;
                    cbPlayer1Weapons.Enabled = false;
                    btnPlayer2Shoot.Enabled = true;
                    cbPlayer2Weapons.Enabled = true;
                    player1.hsp = 0;

                    cbPlayer2Weapons.Focus();
                    this.ActiveControl = null;
                }
                else
                if (turn == player2)
                {
                    turn = player1;
                    player1.fuel = pbPlayer1Fuel.Maximum;
                    btnPlayer2Shoot.Enabled = false;
                    cbPlayer2Weapons.Enabled = false;
                    btnPlayer1Shoot.Enabled = true;
                    cbPlayer1Weapons.Enabled = true;
                    player2.hsp = 0;

                    cbPlayer1Weapons.Focus();
                    this.ActiveControl = null;

                    rounds--;
                }
            }
        }

        //Update controls (step)
        private void updateControls()
        {
            if (turn == player1)
            {
                lblPlayer1ShootAngle.Text = "Angle: " + Convert.ToString(player1.shootAngle);
                lblPlayer1ShootPower.Text = "Power: " + Convert.ToString(player1.shootPower);
            }
            else
            {
                lblPlayer1ShootAngle.Text = "Angle: ???";
                lblPlayer1ShootPower.Text = "Power: ???";
            }
            lblPlayer1Fuel.Text = "Fuel: " + Convert.ToString(player1.fuel);
            lblPlayer1Health.Text = "Health: " + Convert.ToString(player1.health);
            pbPlayer1Fuel.Value = player1.fuel;
            pbPlayer1Health.Value = player1.health;

            if (turn == player2)
            {
                lblPlayer2ShootAngle.Text = "Angle: " + Convert.ToString(player2.shootAngle);
                lblPlayer2ShootPower.Text = "Power: " + Convert.ToString(player2.shootPower);
            }
            else
            {
                lblPlayer2ShootAngle.Text = "Angle: ???";
                lblPlayer2ShootPower.Text = "Power: ???";
            }
            lblPlayer2Fuel.Text = "Fuel: " + Convert.ToString(player2.fuel);
            lblPlayer2Health.Text = "Health: " + Convert.ToString(player2.health);
            pbPlayer2Fuel.Value = player2.fuel;
            pbPlayer2Health.Value = player2.health;

            lblPlayerTurn.Text = turn.name + "'s Turn";
            lblPlayerTurn.ForeColor = turn.color;

            string moreRounds = "s";
            if (rounds == 1)
                moreRounds = "";
            lblRoundTime.Text = Convert.ToString(rounds) + " round" + moreRounds + " remaining (" + Convert.ToString(roundTime/100) + ")";
        }

        //Destroy terrain (step)
        private void destroyTerrain(int percision, int istart, int iend, int jstart)
        {
            for (int i = istart; i < iend; i++)
            {
                Blast b = blasts[i];

                for (int j = jstart-4; j < terrain.Count; j++)
                {
                    Terrain t = terrain[j];

                    if (t.isColliding(b) && t.destructable)
                    {
                        int x = t.x;
                        int y = t.y;
                        int width = t.width;
                        int height = t.height;

                        terrain.Remove(t);
                        destroyTerrain(percision, i, i+1, j);

                        if (width <= percision || height <= percision)
                        {
                            break;
                        }

                        Terrain gl = new Terrain(x, y, width / 2, height / 2, true);
                        Terrain gd = new Terrain(x + width / 2, y, width / 2, height / 2, true);
                        Terrain dl = new Terrain(x, y + height / 2, width / 2, height / 2, true);
                        Terrain dd = new Terrain(x + width / 2, y + height / 2, width / 2, height / 2, true);

                        terrain.Add(gl);
                        terrain.Add(gd);
                        terrain.Add(dl);
                        terrain.Add(dd);
                    }
                }
            }
        }

        //Player physics (step)
        private void playerPhysics(Player p)
        {
            //Angle
            p.angle = getAngle(p);

            //Gravity
            if (p.vsp < 32)
                p.vsp += p.gravity;

            //Climbing terrain
            if (!positionFree(p.x + p.hsp, p.y, terrain) && !positionFree(p.x, p.y + 1, terrain) && (p.angle <= p.climbAngle) && (p.angle >= -p.climbAngle) && p.fuel>0)
            {
                for (int i=0;i<=16;i+=1)
                {
                    if (positionFree(p.x + Math.Sign(p.hsp), p.y - i, terrain))
                    {
                        p.y -= i;
                        break;
                    }
                }
            }

            //Horisontal collision
            if (p.fuel > 0)
            {
                for (int i = 0; i < Math.Abs(p.hsp); i++)
                {
                    if (positionFree(p.x + Math.Sign(p.hsp), p.y, terrain))
                    {
                        p.x += Math.Sign(p.hsp);
                    }
                    else 
                    {
                        p.hsp = 0;
                        break;
                    }
                }
            }

            //Vertical collision
            for (int i = 0; i <= Math.Abs(p.vsp); i++)
            {
                if (positionFree(p.x, p.y + Math.Sign(p.vsp), terrain))
                    p.y += Math.Sign(p.vsp);
                else
                {
                    p.vsp = 0;
                    break;
                }
            }

            

            //Fuel consumption
            if (p.hsp != 0)
            {
                if (p.fuel > 0)
                    p.fuel--;
            }
        }

        //Projectile physics (step)
        private void projectilePhysics()
        {
            for (int i = 0; i < projectiles.Count; i++)
            {
                Projectile p = projectiles[i];
                double radians = degToRad(-p.direction);
                bool collided = false;

                if (p.direction != 90 && p.direction != -90)
                for (int j = 0; j < p.speed; j++)
                {
                    //Gravity
                    p.hsp = Math.Cos(radians);
                    p.y = p.yStart;
                    p.vsp = getTrajectory(p);

                    //Collision
                    if (!positionFree(p.x + p.hsp, p.y + p.vsp, terrain))
                    {
                        collided = true;
                        break;
                    }
                    
                    p.x += p.hsp;
                    p.y += p.vsp;
                }

                if (p.direction == 90 || p.direction == -90)
                {
                    //Gravity
                    p.vsp += p.speed*Math.Sin(radians);
                    p.speed = 0;
                    p.vsp += p.gravity;
                    
                    //Collision (vertical)
                    for (int j = 0; j < Math.Abs(p.vsp); j++)
                    {
                        if (!positionFree(p.x, p.y + Math.Sign(p.vsp), terrain))
                        {
                            p.vsp = 0;
                            collided = true;
                            break;
                        }
                        p.y += Math.Sign(p.vsp);
                    }
                }

                if (collided)
                {
                    p.execute(p.x + p.hsp, p.y + p.vsp, this);
                    projectiles.Remove(p);
                }
            }
        }

        //Blast physics (step)
        private void blastPhysics()
        {
            for (int i = 0; i < blasts.Count; i++)
            {
                if (player1.isColliding(blasts[i]))
                {
                    player1.health -= blasts[i].damage;
                    if (player1.health < 0)
                        player1.health = 0;
                }
                if (player2.isColliding(blasts[i]))
                {
                    player2.health -= blasts[i].damage;
                    if (player2.health < 0)
                        player2.health = 0;
                }
                afterBlasts.Add(new AfterBlast(blasts[i].x, blasts[i].y, blasts[i].radius, turn.color));
                blasts.RemoveAt(i);
            }
        }

        //AfterBlastDecay (step)
        private void afterBlastDecay()
        {
            for (int i = 0; i < afterBlasts.Count; i++)
            {
                AfterBlast ab = afterBlasts[i];

                ab.color = Color.FromArgb(ab.duration, turn.color);
                if (ab.duration > 2)
                    ab.duration-=3;
                else afterBlasts.Remove(ab);
            }
        }

        //Get projectile change rate trajectory Y from X (projectile physics)
        private double getTrajectory(Projectile p)
        {
            double radians = degToRad(-p.direction);
            //return p.y = (p.gravity / 2) * (Math.Pow((p.x - p.xStart), 2) / (Math.Pow(p.speed, 2) * Math.Pow(Math.Cos(radians), 2))) + Math.Tan(radians) * (p.x - p.xStart);
            return (p.x - p.xStart) * Math.Tan(radians) + ((p.gravity * Math.Pow(p.x - p.xStart, 2)) / (2 * Math.Pow(p.speed * Math.Cos(radians), 2)));
        }

        //Get player angle depending on terrain (player physics)
        private double getAngle(Player p)
        {
            //Return if player is in the air
            if (positionFree(p.x, p.y + 1, terrain))
                return p.angle;

            //End points 
            double x1 = p.x - 8;
            double y1 = p.y;
            double x2 = p.x + 8;
            double y2 = p.y;

            //Left side
            if (positionFree(x1, p.y, terrain))
            for (int i=0; true; i++)
            {
                if (!positionFree(x1, p.y + i, terrain))
                {
                    y1 = p.y+i-1;
                    break;
                }
            }
            else
                if (!positionFree(x1, p.y, terrain))
            for (int i=0; true; i--)
            {
                if (positionFree(x1, p.y + i, terrain))
                {
                    y1 = p.y+i;
                    break;
                }
            }
            
            //Right side
            if (positionFree(x2, p.y, terrain))
            for (int i=0; true; i++)
            {
                if (!positionFree(x2, p.y + i, terrain))
                {
                    y2 = p.y+i-1;
                    break;
                }
            }
            else
                if (!positionFree(x2, p.y, terrain))
            for (int i = 0; true; i--)
            {
                if (positionFree(x2, p.y + i, terrain))
                {
                    y2 = p.y + i;
                    break;
                }
            }

            return angleFromPoints(x1, y1, x2, y2);
        }

        //Rotate bitmap image/sprite (draw)
        private Bitmap rotateImageByAngle(System.Drawing.Image oldBitmap, float angle)
        {
            Bitmap newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);
            graphics.TranslateTransform((float)oldBitmap.Width / 2, (float)oldBitmap.Height / 2);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-(float)oldBitmap.Width / 2, -(float)oldBitmap.Height / 2);
            graphics.DrawImage(oldBitmap, new Point(0, 0));
            return newBitmap;
        }

        //Clamp values (math)
        private double clamp(double value, double min, double max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

        //Get the angle from 2 points in degrees (math)
        private double angleFromPoints(double x1, double y1, double x2, double y2)
        {
            return radToDeg(Math.Atan2(y2 - y1, x2 - x1));
        }

        //Radians to degrees (math)
        private double radToDeg(double radians)
        {
            return radians * (180 / Math.PI);
        }

        //Degrees to radians (math)
        private double degToRad(double degrees)
        {
            return Math.PI * degrees / 180;
        }

        //Position free
        public static bool positionFree(double x, double y, List<Terrain> terrain)
        {
            for (int i = 0; i < terrain.Count; i++)
            {
                Terrain t = terrain[i];

                if ((t.x <= x && x < t.x + t.width) && (t.y <= y && y < t.y + t.height))
                    return false;
            }
            return true;
        }

        //Key press
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!canInteract)
                return;

            this.ActiveControl = null;

            if (e.KeyCode == Keys.A)
            {
                turn.hsp = -turn.moveSpeed;
            }

            if (e.KeyCode == Keys.D)
            {
                turn.hsp = turn.moveSpeed;
            }

            if (e.KeyCode == Keys.W)
            {
                if (turn.shootPower < turn.maxPower)
                {
                    turn.shootPower++;
                }
                else
                {
                    turn.shootPower = turn.maxPower;
                }
            }

            if (e.KeyCode == Keys.S)
            {
                if (turn.shootPower > 2)
                {
                    turn.shootPower--;
                }
                else
                {
                    turn.shootPower = 2;
                }
            }

            if (e.KeyCode == Keys.Q)
            {
                turn.shootAngle++;
            }

            if (e.KeyCode == Keys.E)
            {
                turn.shootAngle--;
            }

            if (e.KeyCode == Keys.Space && settings.allowJumping)
            {
                if (turn.fuel >=20 && !positionFree(turn.x, turn.y + 1, terrain))
                {
                    turn.vsp = -turn.jumpSpeed;
                    turn.fuel -= 20;
                }
            }

            if (e.KeyCode == Keys.R)
            {
                if (turn == player1)
                {
                    player1Shoot();
                }
                else
                if (turn == player2)
                {
                    player2Shoot();
                }
            }
        }

        //Key release
        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                turn.hsp = 0;
            }
        }

        //Mouse button press
        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (!canInteract)
                return;

            if (e.Button == MouseButtons.Left)
            {
                double angle = -angleFromPoints(turn.x, turn.y - turn.offY / 2, e.Location.X, e.Location.Y);
                double power = Math.Sqrt(Math.Pow(turn.x - e.Location.X, 2) + Math.Pow(turn.y - turn.offY/2 - e.Location.Y, 2));
                if (power > turn.maxPower)
                    power = turn.maxPower;
                if (power < 2)
                    power = 2;

                turn.shootAngle = angle;
                turn.shootPower = power;
            }
        }

        //Mouse button held down
        private void GameForm_MouseMove(object sender, MouseEventArgs e)
        {
            GameForm_MouseDown(sender, e);
        }

        //Clicking the shoot button for player 1
        private void btnPlayer1Shoot_Click(object sender, EventArgs e)
        {
            player1Shoot();
            this.ActiveControl = null;
        }

        //Clicking the shoot button for player 2
        private void btnPlayer2Shoot_Click(object sender, EventArgs e)
        {
            player2Shoot();
            this.ActiveControl = null;
        }

        //Player 1 shoot
        private void player1Shoot()
        {
            if (btnPlayer1Shoot.Enabled == true)
            {
                shootProjectile(player1.weapons.weapons[player1.selectedWeapon].name);
                player1.selectedWeapon = player1.weapons.removeWeapon(player1.selectedWeapon);
                cbPlayer1Weapons.Items.Clear();
                for (int i = 0; i < player1.weapons.weapons.Count(); i++)
                    cbPlayer1Weapons.Items.Add(player1.weapons.weapons[i].ToString());
                if (cbPlayer1Weapons.Items.Count > 0)
                    cbPlayer1Weapons.SelectedIndex = player1.selectedWeapon;
                roundTime = 0;
            }
            btnPlayer1Shoot.Enabled = false;
            cbPlayer1Weapons.Enabled = false;
            canInteract = false;
        }

        //Player 2 shoot
        private void player2Shoot()
        {
            if (btnPlayer2Shoot.Enabled == true)
            {
                shootProjectile(player2.weapons.weapons[player2.selectedWeapon].name);
                player2.selectedWeapon = player2.weapons.removeWeapon(player2.selectedWeapon);
                cbPlayer2Weapons.Items.Clear();
                for (int i = 0; i < player2.weapons.weapons.Count(); i++)
                    cbPlayer2Weapons.Items.Add(player2.weapons.weapons[i].ToString());
                if (cbPlayer2Weapons.Items.Count > 0)
                    cbPlayer2Weapons.SelectedIndex = player2.selectedWeapon;
                roundTime = 0;
            }
            btnPlayer2Shoot.Enabled = false;
            cbPlayer2Weapons.Enabled = false;
            canInteract = false;
        }

        //The actual shooting of the projectile
        private void shootProjectile(string type)
        {
            switch (type)
            {
                case "Three-Shot":
                    {
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle, turn.shootPower / 8, settings.gravity, type));
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle - 5, turn.shootPower / 8, settings.gravity, type));
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle + 5, turn.shootPower / 8, settings.gravity, type));
                        break;
                    }
                case "Five-Shot":
                    {
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle, turn.shootPower / 8, settings.gravity, type));
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle - 5, turn.shootPower / 8, settings.gravity, type));
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle + 5, turn.shootPower / 8, settings.gravity, type));
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle - 10, turn.shootPower / 8, settings.gravity, type));
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle + 10, turn.shootPower / 8, settings.gravity, type));
                        break;
                    }
                case "Shotgun":
                    {
                        for (int i = 0; i < 20; i++)
                            projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle + ((double)MenuForm.random.Next(-3000, 3001) / 1000), ((double)MenuForm.random.Next(900, 1101) / 1000) * (turn.shootPower / 8), settings.gravity, type));
                        break;
                    }
                default:
                    {
                        projectiles.Add(new Projectile(turn.x, turn.y - turn.offY / 2, turn.shootAngle, turn.shootPower / 8, settings.gravity, type));
                        break;
                    }
            }
        }

        //What happens after we change the weapon type for player 1
        private void cbPlayer1Weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            player1.selectedWeapon = cbPlayer1Weapons.SelectedIndex;
            this.ActiveControl = null;
        }

        //What happens after we change the weapon type for player 2
        private void cbPlayer2Weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            player2.selectedWeapon = cbPlayer2Weapons.SelectedIndex;
            this.ActiveControl = null;
        }

        //If we decide not to press the player 1 shoot button
        private void btnPlayer1Shoot_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        //If we decide not to press the player 2 shoot button
        private void btnPlayer2Shoot_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        //Release memory when game window is closed
        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        //Game over and release memory
        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}