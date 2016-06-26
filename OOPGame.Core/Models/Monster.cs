using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPGame.Core.Interfaces;

namespace OOPGame.Core.Models
{
    class Monster : Creature, IMonster
    {
        //constructor
        //TO-DO attack names
        public Monster(string name) : base(name)
        {
        }

        //methods
        public int DamageOnFlee()
        {
            
            throw new NotImplementedException();
        }

        public override string FinalWords()
        {
            throw new NotImplementedException();
        }
    }
}
