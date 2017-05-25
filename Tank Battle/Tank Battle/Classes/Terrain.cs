using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank_Battle
{
    [Serializable]
    public class Terrain
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool destructable { get; set; }

        public Terrain(int x, int y, int width, int height, bool destructable)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.destructable = destructable;
        }

        public bool isColliding(Blast blast)
        {
            double xx = blast.x;
            double yy = blast.y;
            int rr = blast.radius;

            double closestX = (xx < x ? x : (xx > x+width ? x+width : xx));
            double closestY = (yy < y ? y : (yy > y + height ? y + height : yy));
            double dx = closestX - xx;
            double dy = closestY - yy;

            return (dx * dx + dy * dy) <= (rr * rr);
        }
    }
}
