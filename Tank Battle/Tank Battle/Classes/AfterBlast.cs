using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tank_Battle
{
    public class AfterBlast
    {
        public double x { get; set; }
        public double y { get; set; }
        public int radius { get; set; }
        public Color color { get; set; }
        public int duration { get; set; }

        public AfterBlast (double x, double y, int radius, Color color)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.color = color;
            this.duration = 255;
        }
    }
}
