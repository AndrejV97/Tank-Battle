using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank_Battle
{
    [Serializable]
    public class Level
    {
        public string name { get; set; }
        public List<Terrain> terrain { get; set; }
        public double p1x { get; set; }
        public double p1y { get; set; }
        public double p2x { get; set; }
        public double p2y { get; set; }

        public Level(string name, double p1x, double p1y, double p2x, double p2y)
        {
            this.name = name;
            this.p1x = p1x;
            this.p1y = p1y;
            this.p2x = p2x;
            this.p2y = p2y;

            this.terrain = new List<Terrain>();
            this.terrain.Add(new Terrain(32, 736, 1024, 32, false));
            this.terrain.Add(new Terrain(32, -4096, 1024, 32, false));
            this.terrain.Add(new Terrain(0, -4096, 32, 4864, false));
            this.terrain.Add(new Terrain(1056, -4096, 32, 4864, false));
        }

        public override string ToString()
        {
            return name;
        }
    }
}
