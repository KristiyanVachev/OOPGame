namespace OOPGame.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OOPGame.Core.Interfaces;

    public abstract class Creature : ICreature
    {
        //fields
        private string name;

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

        public string WeakAttackName { get; set; }

        public string StrongAttackName { get; set; }

        public string UltimateAttackName { get; set; }

        //constrcutors
        protected Creature(string name)
        {
            this.Name = name;
        }

        //methods
        public int WeakAttack()
        {
            //80% chance for a strike
            if (ChanceForStrike(80))
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
            if (ChanceForStrike(55))
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
            if (ChanceForStrike(30))
            {
                return this.Damage * 2;
            }
            else
            {
                return 0;
            }
        }

        protected bool ChanceForStrike(int chance)
        {  
            //lets say chance = 70, we have a random number between 1 and 100. 
            //Then we have 70% chance to have a number lower than the random
            Random random = new Random();
            int rnd = random.Next(1, 101);

            if (rnd < chance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract string FinalWords();
    }
}
