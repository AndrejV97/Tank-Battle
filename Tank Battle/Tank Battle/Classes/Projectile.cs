using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank_Battle
{
    public class Projectile
    {
        public double xStart { get; set; }
        public double yStart { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double direction { get; set; }
        public double gravity { get; set; }
        public double hsp { get; set; }
        public double vsp { get; set; }
        public double speed { get; set; }
        public string type { get; set; }

        public Projectile(double x, double y, double direction, double speed, double gravity, string type)
        {
            this.xStart = x;
            this.yStart = y;
            this.x = x;
            this.y = y;
            this.direction = direction;
            this.gravity = gravity;
            this.hsp = 0;
            this.vsp = 0;
            this.speed = speed;
            this.type = type;
        }

        public void execute(double x, double y, GameForm gf)
        {
            switch (type)
            {
                case "Small Shot":
                    {
                        gf.blasts.Add(new Blast(x, y, 10));
                        break;
                    }
                case "Heavy Shot":
                    {
                        gf.blasts.Add(new Blast(x, y, 25));
                        break;
                    }
                case "Massive Shot":
                    {
                        gf.blasts.Add(new Blast(x, y, 50));
                        break;
                    }
                case "Fountain":
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            double angle = ((double) MenuForm.random.Next(8000, 10001) / 100);
                            double power = Math.Sin(angle * Math.PI / 180) * ((double)MenuForm.random.Next(500, 1501) / 100);
                            gf.projectiles.Add(new Projectile(x, y - 1, angle, power, gravity,  "Fountain_Piece"));
                        }
                            
                        break;
                    }
                case "Fountain_Piece":
                    {
                        gf.blasts.Add(new Blast(x, y, 8));
                        break;
                    }
                case "Three-Shot":
                    {
                        gf.blasts.Add(new Blast(x, y, 20));
                        break;
                    }
                case "Five-Shot":
                    {
                        gf.blasts.Add(new Blast(x, y, 15));
                        break;
                    }
                case "Breaker":
                    {
                        gf.projectiles.Add(new Projectile(x, y - 1, 45, 5, gravity, "Breaker_Piece"));
                        gf.projectiles.Add(new Projectile(x, y - 1, 135, 5, gravity, "Breaker_Piece"));
                        gf.projectiles.Add(new Projectile(x, y - 1, 90, 5, gravity, "Breaker_Piece"));
                        break;
                    }
                case "Breaker_Piece":
                    {
                        gf.blasts.Add(new Blast(x, y, 15));
                        break;
                    }
                case "Digger":
                    {
                        gf.blasts.Add(new Blast(x, y, 20));
                        gf.projectiles.Add(new Projectile(x, y - 1, 90, 8, gravity, "Digger_Piece_1"));
                        break;
                    }
                case "Digger_Piece_1":
                    {
                        gf.blasts.Add(new Blast(x, y, 15));
                        gf.projectiles.Add(new Projectile(x, y - 1, 90, 4, gravity, "Digger_Piece_2"));
                        break;
                    }
                case "Digger_Piece_2":
                    {
                        gf.blasts.Add(new Blast(x, y, 8));
                        gf.projectiles.Add(new Projectile(x, y - 1, 90, 2, gravity, "Digger_Piece_3"));
                        break;
                    }
                case "Digger_Piece_3":
                    {
                        gf.blasts.Add(new Blast(x, y, 4));
                        gf.projectiles.Add(new Projectile(x, y - 1, 90, 1, gravity, "Digger_Piece_4"));
                        break;
                    }
                case "Digger_Piece_4":
                    {
                        gf.blasts.Add(new Blast(x, y, 2));
                        gf.projectiles.Add(new Projectile(x, y - 1, 90, 1, gravity, "Digger_Piece_5"));
                        break;
                    }
                case "Digger_Piece_5":
                    {
                        gf.blasts.Add(new Blast(x, y, 1));
                        break;
                    }
                case "Shotgun":
                    {
                        gf.blasts.Add(new Blast(x, y, 6));
                        break;
                    }
                case "Nuke":
                    {
                        gf.blasts.Add(new Blast(x, y, 100));
                        break;
                    }
                case "Sniper":
                    {
                        Blast b = new Blast(x, y, 4);
                        b.damage = 100;
                        gf.blasts.Add(b);
                        break;
                    }
            }
        }
    }
}
