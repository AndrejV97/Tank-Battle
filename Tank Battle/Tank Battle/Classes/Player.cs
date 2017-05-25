using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tank_Battle
{
    public class Player
    {
        public List<Bitmap> models { get; set; }
        public string name { get; set; }
        public int spriteIndex { get; set; }
        public Color color { get; set; }
        public Bitmap sprite;
        public int offX { get; set; }
        public int offY { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double gravity { get; set; }
        public double hsp { get; set; }
        public double vsp { get; set; }
        public double moveSpeed { get; set; }
        public double jumpSpeed { get; set; }
        public double angle { get; set; }
        public int climbAngle { get; set; }
        public double shootAngle { get; set; }
        public double shootPower { get; set; }
        public int maxPower { get; set; }
        public int fuel { get; set; }
        public int health { get; set; }
        public int cannonLength { get; set; }
        public int collisionRadius { get; set; }
        public Weapons weapons { get; set; }
        public int selectedWeapon { get; set; }

        public Player(string name, int spriteIndex, Color color, double x, double y)
        {
            this.models = new List<Bitmap>();
            models.Add(Properties.Resources.model0);
            models.Add(Properties.Resources.model1);
            models.Add(Properties.Resources.model2);
            models.Add(Properties.Resources.model3);
            models.Add(Properties.Resources.model4);
            models.Add(Properties.Resources.model5);
            models.Add(Properties.Resources.model6);

            this.name = name;
            this.spriteIndex = spriteIndex;
            this.color = color;
            this.sprite = models[spriteIndex];
            this.offX = 20;
            this.offY = 27;
            this.x = x+offX;
            this.y = y+offY;
            this.gravity = 2;
            this.hsp = 0;
            this.vsp = 0;
            this.moveSpeed = 2;
            this.jumpSpeed = 8;
            this.angle = 0;
            this.climbAngle = 60;
            this.shootAngle = 90;
            this.shootPower = 100;
            this.maxPower = 200;
            this.fuel = 200;
            this.health = 300;
            this.cannonLength = 24;
            this.collisionRadius = 16;
            this.weapons = new Weapons();
            this.selectedWeapon = 0;
        }

        public bool isColliding(Blast blast)
        {
            double xx = blast.x;
            double yy = blast.y;
            int rr = blast.radius;

            double closestX = (xx < x ? x : (xx > x + collisionRadius ? x + collisionRadius : xx));
            double closestY = (yy < y ? y : (yy > y + collisionRadius ? y + collisionRadius : yy));
            double dx = closestX - xx;
            double dy = closestY - yy;

            return (dx * dx + dy * dy) <= (rr * rr);
        }
    }
}
