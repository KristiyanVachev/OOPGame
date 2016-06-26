using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPGame.Core.Interfaces;

namespace OOPGame.Core.Models
{
    public class Monster : Creature, IMonster
    {
        //constructor
        public Monster(string name, int maxHP, int damage, int armor, int level,  string weakAttack, string strongAttack, string UltAttack) : base(name)
        {
            this.MaxHP = maxHP;
            this.HP = maxHP;
            this.Damage = damage;
            this.Armor = armor;
            this.Level = level;
            this.WeakAttackName = weakAttack;
            this.StrongAttackName = strongAttack;
            this.UltimateAttackName = UltAttack;
        }

        //methods
        public int DamageOnFlee()
        {
            Random rnd = new Random();
            //Inflict a random damage between the weakest and strongest attack.
            int damageDealth = rnd.Next(this.Damage / 2, this.Damage * 2);
            return damageDealth;          
        }

        //maybe remove this.
        public override string FinalWords()
        {
            throw new NotImplementedException();
        }

        
    }
}
