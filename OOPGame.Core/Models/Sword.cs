namespace OOPGame.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OOPGame.Core.Interfaces;

    public class Sword : ISword
    {
        //properties
        public string Name { get; set; }

        public int Damage { get; set; }

        public string AttackName { get; set; }

        //constructors
        public Sword(string name, int damage, string attackName)
        {
            this.Name = name;
            this.Damage = damage;
            this.AttackName = attackName;
        }
    }
}
