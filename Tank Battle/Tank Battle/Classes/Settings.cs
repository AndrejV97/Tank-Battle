using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tank_Battle
{
    [Serializable]
    public class Settings
    {
        public bool debugTerrain { get; set; }
        public int terrainQuality { get; set; }
        public bool destructableTerrain { get; set; }
        public Color color { get; set; }
        public int roundTime { get; set; }
        public int rounds { get; set; }
        public bool sameWeapons { get; set; }
        public int playerHealth { get; set; }
        public int playerFuel { get; set; }
        public bool allowJumping { get; set; }
        public bool visualIndicators { get; set; }
        public double gravity { get; set; }
        public double jumpSpeed { get; set; }
        public string p1Name { get; set; }
        public Color p1Color { get; set; }
        public int p1Index { get; set; }
        public string p2Name { get; set; }
        public Color p2Color { get; set; }
        public int p2Index { get; set; }

        public Settings(bool debugTerrain, int terrainQuality, bool destructableTerrain, Color color,
                        int roundTime, int rounds, bool sameWeapons, int playerHealth, int playerFuel,
                        bool allowJumping, bool visualIndicators, double gravity, double jumpSpeed,
                        string p1Name, Color p1Color, int p1Index, string p2Name, Color p2Color, int p2Index)
        {
            this.debugTerrain = debugTerrain;
            this.terrainQuality = terrainQuality;
            this.destructableTerrain = destructableTerrain;
            this.color = color;
            this.roundTime = roundTime;
            this.rounds = rounds;
            this.sameWeapons = sameWeapons;
            this.playerHealth = playerHealth;
            this.playerFuel = playerFuel;
            this.allowJumping = allowJumping;
            this.visualIndicators = visualIndicators;
            this.gravity = gravity;
            this.jumpSpeed = jumpSpeed;
            this.p1Name = p1Name;
            this.p1Color = p1Color;
            this.p1Index = p1Index;
            this.p2Name = p2Name;
            this.p2Color = p2Color;
            this.p2Index = p2Index;
        }
    }
}
