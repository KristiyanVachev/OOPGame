namespace OOPGame.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OOPGame.Core.Interfaces;

    public class Shield : IShield
    {
        //properties
        public string Name { get; set; }

        public int Armor { get; set; }

        //constructors
        public Shield(string name, int armor)
        {
            this.Name = name;
            this.Armor = armor;
        }

    }
}
