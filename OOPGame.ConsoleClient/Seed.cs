using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPGame.Core.Interfaces;
using OOPGame.Core.Models;

namespace OOPGame.ConsoleClient
{
    public static class Seed
    {
        public static IMonster[] SeedMonsters()
        {
            IMonster[] monsters =
            {
                new Monster("Stupid Panda", 100, 20, 10, 1, "Fur blow", "Bamboo strike", "Bamboo spear throw"),
                new Monster("Killer Whale", 200, 40, 20, 2, "Water shot","Tail punch", "Ripping bite")
            };

            return monsters;
        }

        public static IWeapon[] SeedRewards()
        {
            IWeapon[] weapons =
            {
                new Sword("Bastard Sword", 30, "Thrust"),
                new Shield("Roman Shield", 40),
                new Sword("Long Sword", 60, "Decapitating")

            };

            return weapons;
        }

    }
}
