namespace OOPGame.ConsoleClient
{
    using System;
    using OOPGame.Core.Interfaces;
    using OOPGame.Core.Infrastructure;
    using OOPGame.Core.Models;

    public static class Action
    {
        public static void Attack(ICreature attacker, ICreature deffender, int answer)
        {
            //Chance of armor deflecting the attack 
            //If armor doesnt stop the attack.
            if (RandomChance.Success(100 - deffender.Armor))
            {
                //Chance of dealing damage.
                int damageDealth = attacker.Attack(attacker.AttackChance[answer], attacker.AttackPower[answer]);
                //If any damage dealth
                if (damageDealth != 0)
                {
                    deffender.HP -= damageDealth;
                    //If defender is dead.
                    if (deffender.HP > 0)
                    {
                        Console.WriteLine($"{attacker.Name} dealth {damageDealth} damage. {deffender.Name} now has {deffender.HP}HP");
                    }
                    else
                    {
                        Console.WriteLine("{1} dealth {0} damage.", damageDealth, attacker.Name);
                    }
                }
                //No damage dealth.
                else
                {
                    //Attack failed
                    Console.WriteLine("{1} couldn't perform {0}.", attacker.AttackNames[answer], attacker.Name);
                }
            }
            else
            {
                //armor blocked
                Console.WriteLine("{0}'s armor stopped {1} attack.", deffender.Name, attacker.Name);
            }
        }

        public static void GetReward(IWeapon weapon, IHero hero)
        {
            if (weapon is Sword)
            {
                hero.Sword = weapon as Sword;
                Dialoge.NewSword(hero.Sword);
            }
            else
            {
                hero.Shield = weapon as Shield;
                Dialoge.NewShield(hero.Shield);
            }
            hero.LevelUp();
            Dialoge.NewLevel(hero);
        }

        public static void DrinkPotion(IHero hero)
        {
            if (hero.PotionsCount > 0)
            {
                hero.UsePotion();
                Dialoge.UsedPotion(hero);
            }
            else
            {
                Dialoge.NoPotions();
            }
        }

        //To-Do
        //public static void Fight(IHero hero, IMonster monster)
        //{

        //}
    }
}
