using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank_Battle
{
    public class Weapons
    {
        private List<string> allWeapons;
        public List<Weapon> weapons { get; set; }

        public Weapons()
        {
            allWeapons = new List<string>();
            allWeapons.Add("Small Shot");
            allWeapons.Add("Heavy Shot");
            allWeapons.Add("Massive Shot");
            allWeapons.Add("Fountain");
            allWeapons.Add("Three-Shot");
            allWeapons.Add("Five-Shot");
            allWeapons.Add("Breaker");
            allWeapons.Add("Digger");
            allWeapons.Add("Shotgun");
            allWeapons.Add("Nuke");
            allWeapons.Add("Sniper");

            weapons = new List<Weapon>();
        }

        public void addWeapons(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Weapon newWeapon = new Weapon(allWeapons[MenuForm.random.Next(0, allWeapons.Count)], 1);
                bool exists = false;

                for (int j = 0; j < weapons.Count; j++)
                {
                    if (weapons[j].name == newWeapon.name)
                    {
                        weapons[j].amount++;
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                weapons.Add(newWeapon);
            }
        }

        public int removeWeapon(int index)
        {
            if (weapons[index].amount > 0)
            {
                weapons[index].amount--;
            }
            if (weapons[index].amount == 0)
            {
                weapons.RemoveAt(index);
                return 0;
            }
            return index;
        }
    }
}
