using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank_Battle
{
    public class Weapon
    {
        public string name { get; set; }
        public int amount { get; set; }

        public Weapon (string name, int amount)
        {
            this.name = name;
            this.amount = amount;
        }

        public override string ToString()
        {
            return Convert.ToString(amount) + " X " + name;
        }
    }
}
