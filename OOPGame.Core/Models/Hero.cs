namespace OOPGame.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OOPGame.Core.Interfaces;

    public class Hero : Creature, IHero
    {
        //fields

        //properties
        public int Experience { get; set; }

        public int BasicArmor { get; set; }

        public Shield Shield { get; set; }

        public int BasicDamage { get; set; }

        public Sword Sword { get; set; }

        public int PotionsCount { get; set; }

        //Constructors
        public Hero(string name) : base(name)
        {
            this.Experience = 0;
            this.Level = 1;
            this.MaxHP = 100;
            this.HP = this.MaxHP;
            this.BasicArmor = 5;
            this.Shield = new Shield("Wooden Round Shield", 20);
            this.Armor = this.BasicArmor + this.Shield.Armor;
            this.BasicDamage = 20;
            this.Sword = new Sword("Short Sword", 30, "Blow");
            this.Damage = this.BasicDamage + this.Sword.Damage;
            this.PotionsCount = 3;
            this.AttackNames = new string[3];
            this.AttackNames[0] = "Punch";
            this.AttackNames[1] = Sword.AttackName;
            this.AttackNames[2] = "MEGA cool Attack";
        }

        //Methods

        public void UsePotion()
        {
            if (this.PotionsCount > 1)
            {
                //potions restore 50% of max health
                int restoredHP = this.MaxHP / 2;
                if (this.HP + restoredHP > this.MaxHP)
                {
                    this.HP = this.MaxHP;
                }
                else
                {
                    this.HP += restoredHP;
                }
            }
        }

        public override string FinalWords()
        {
            return "Ahh you bastard!";
        }

        public void LevelUp()
        {
            this.Level++;
            this.MaxHP += 100;
            this.HP = MaxHP;
            this.BasicArmor += 5;
            this.Armor = this.BasicArmor + this.Shield.Armor;
            this.BasicDamage += 15;
            this.Damage = this.BasicDamage + this.Sword.Damage;
        }
    }
}
