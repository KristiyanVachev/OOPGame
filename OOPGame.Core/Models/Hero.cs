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

        public int ShieldArmor { get; set; }

        public int BasicDamage { get; set; }

        public int SwordDamage { get; set; }

        public int PotionsCount { get; set; }

        //Constructors
        public Hero(string name) : base(name)
        {
            this.Experience = 0;
            this.Level = 1;
            this.HP = 100;
            this.BasicArmor = 5;
            this.ShieldArmor = 10;
            this.Armor = this.BasicArmor + this.ShieldArmor;
            this.BasicDamage = 20;
            this.SwordDamage = 30;
            this.Damage = this.BasicDamage + this.SwordDamage;
            this.PotionsCount = 3;
            this.WeakAttackName = "Punch";
            this.StrongAttackName = "Sword swing";
            this.UltimateAttackName = "MEGA cool Attack";
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
    }
}
