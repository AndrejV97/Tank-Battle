using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank_Battle
{
    public class Blast
    {
        public double x { get; set; }
        public double y { get; set; }
        public int radius { get; set; }
        public int damage { get; set; }

        public Blast(double x, double y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.damage = radius;
        }
    }
}
