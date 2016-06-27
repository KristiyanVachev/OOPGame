namespace OOPGame.ConsoleClient
{
    using System;
    using OOPGame.Core.Interfaces;

    public class Dialoge
    {
        public static void MeetMonster(IMonster monster)
        {
            Console.WriteLine("There is a {0} ahead.", monster.Name);
            Console.WriteLine("0. Fight");
            Console.WriteLine("1. Flee");
        }

        public static void MeetBoss(IMonster boss)
        {
            Console.WriteLine("You have reached the mighty {0}. You must slay it to save your princess!", boss.Name);
        }

        public static void HeroAttackOptions(IHero hero)
        {
            for (int j = 0; j < hero.AttackNames.Length; j++)
            {
                Console.WriteLine("{0}. Attack with {1}", j, hero.AttackNames[j]);
            }
            Console.WriteLine("3. Drink potion");
        }

        public static void MonsterDefeated(IMonster monster)
        {
            Console.WriteLine("You have defeated {0} and have reached a new level.", monster.Name);
        }

        public static void BossDefeated(IMonster boss)
        {
            Console.WriteLine("You have defeated the ëvil {0} and have saved your princess.", boss.Name);
        }

        public static void DamageTakenOnFlee(IMonster monster, IHero hero, int damageSuffered)
        {
            Console.WriteLine("While you were fleeing {0} dealth you {1}. You now have {2}HP.", monster.Name, damageSuffered, hero.HP);

        }

        public static void HeroDied()
        {
            Console.WriteLine("You have died and have failed your princess.");
        }

        public static void HeroDiedFleeing()
        {
            Console.WriteLine("You have died while fleeing. Shame!");
        }

        public static void NewSword(ISword sword)
        {
            Console.WriteLine("You have found a new sword: {0} with {1} damage and special attack: {2}. ", sword.Name, sword.Damage, sword.AttackName);
        }

        public static void NewShield(IShield shield)
        {
            Console.WriteLine("You have found a new shield: {0} with {1} armor. ", shield.Name, shield.Armor);
        }

        public static void NewLevel(IHero hero)
        {
            Console.WriteLine("{0} - HP: {1} - Damage: {2} - Armor: {3}", hero.Name, hero.HP, hero.Damage, hero.Armor);
        }

        public static void UsedPotion(IHero hero)
        {
            Console.WriteLine("You used a potion and now have {0}HP.", hero.HP);
        }

        public static void NoPotions()
        {
            Console.WriteLine("You don't have any potions.");
        }

    }
}
