namespace OOPGame.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OOPGame.Core.Interfaces;
    using OOPGame.Core.Infrastructure;

    public abstract class Creature : ICreature
    {
        //fields
        private string name;
        private readonly int[] attackChance = { 80, 60, 30 };
        private readonly double[] attackPower = { 0.5, 1, 2 };

        //properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                //simple validation
                if (value == string.Empty)
                {
                    this.name = "Poop";
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int MaxHP { get; set; }

        public int HP { get; set; }

        public int Damage { get; set; }

        public int Armor { get; set; }

        public int Level { get; set; }

        public int[] AttackChance { get { return this.attackChance; } }

        public double[] AttackPower { get { return this.attackPower; } }

        public string[] AttackNames { get; set; }

        public string WeakAttackName { get; set; }

        public string StrongAttackName { get; set; }

        public string UltimateAttackName { get; set; }

        //constrcutors
        protected Creature(string name)
        {
            this.Name = name;
        }

        //methods

        public int Attack(int chance, double multiplier)
        {
            //80% chance for a strike
            if (RandomChance.Success(chance))
            {
                return Convert.ToInt32(this.Damage * multiplier);
            }
            else
            {
                return 0;
            }
        }
        public int WeakAttack()
        {
            //80% chance for a strike
            if (RandomChance.Success(80))
            {
                return this.Damage / 2;
            }
            else
            {
                return 0;
            }
        }

        public int StrongAttack()
        {
            //55% chance for a strike
            if (RandomChance.Success(55))
            {
                return this.Damage;
            }
            else
            {
                return 0;
            }
        }

        public int UltimateAttack()
        {
            //30% chance for a strike
            if (RandomChance.Success(30))
            {
                return this.Damage * 2;
            }
            else
            {
                return 0;
            }
        }
        public abstract string FinalWords();
    }
}
