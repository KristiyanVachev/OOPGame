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
    }
}
