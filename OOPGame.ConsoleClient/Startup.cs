namespace OOPGame.ConsoleClient
{
    using System;
    using OOPGame.Core.Models;
    using OOPGame.Core.Interfaces;
    using OOPGame.Core.Infrastructure;

    class Startup
    {
        static void Main()
        {
            Console.Write("Enter your hero's name: ");
            string name = Console.ReadLine();
            Hero hero = new Hero(name);

            IMonster[] monsters = Seed.SeedMonsters();
            Sword[] swords = Seed.SeedSwords();
            Shield[] shields = Seed.SeedShields();

            bool finalBoss = false;
            const int meetMonsterOpt = 2;
            const int attackMenuOpt = 4;
            int input;
            int bossIndex = monsters.Length - 1;

            //Meet every monster.
            for (int i = 0; i < monsters.Length; i++)
            {
                //If you are up against the final monster -> special boss dialog.
                if (i == bossIndex)
                {
                    finalBoss = true;
                }

                //Hero attack or flee menu
                if (!finalBoss)
                {
                    Dialoge.MeetMonster(monsters[i]);
                    input = Utillities.ValidateAnswer(meetMonsterOpt);
                }
                else //Boss dialog
                {
                    Dialoge.MeetBoss(monsters[i]);
                    input = 0;
                }

                //Option fight
                if (input == 0)
                {
                    //Fight until one is dead
                    while (hero.HP > 0 && monsters[i].HP > 0)
                    {
                        Dialoge.HeroAttackOptions(hero);
                        input = Utillities.ValidateAnswer(attackMenuOpt);

                        //Perform action based on answer
                        //If answer is an attack
                        if (input >= 0 && input < 3)
                        {
                            //Hero attacks monster
                            Utillities.Attack(hero, monsters[i], input);
                            //If monster is dead
                            if (monsters[i].HP <= 0)
                            {
                                //Killing a commom monster
                                if (!finalBoss)
                                {
                                    Dialoge.MonsterDefeated(monsters[i]);
                                    //To-Do Take weapon trought IWeapon interface
                                    if (i % 2 == 0)
                                    {
                                        int ind = i / 2;
                                        Console.WriteLine("You have found a new sword: {0}", swords[ind].Name);
                                        hero.Sword = swords[ind];
                                    }
                                    else
                                    {
                                        int ind = (i - 1) / 2;
                                        Console.WriteLine("You have found a new shield: {0}", shields[ind].Name);
                                        hero.Shield = shields[ind];
                                    }

                                    hero.LevelUp();
                                    Console.WriteLine("{0} - HP: {1} - Damage: {2} - Armor: {3}", hero.Name, hero.HP, hero.Damage, hero.Armor);

                                    break;
                                }
                                //Killing the Boss
                                else
                                {
                                    Dialoge.BossDefeated(monsters[i]);
                                }

                            }
                            //Monster still alive
                            else
                            {
                                Utillities.Attack(monsters[i], hero, 0);
                            }
                            //If hero dies
                            if (hero.HP <= 0)
                            {
                                Console.WriteLine("You have died and have failed your princess.");
                                break;
                            }
                        }
                        //answer left is 3, drink potion
                        else
                        {
                            //drink potion
                            if (hero.PotionsCount > 0)
                            {
                                hero.UsePotion();
                                Console.WriteLine("You used a potion and now have {0}HP.", hero.HP);
                            }
                            else
                            {
                                Console.WriteLine("You don't have any potions.");
                            }
                            Utillities.Attack(monsters[i], hero, 0);
                            if (hero.HP <= 0)
                            {
                                Console.WriteLine("You have died and have failed your princess.");
                                break;
                            }
                        }
                    }
                }
                //Option left - 1. flee
                else
                {
                    //Monster always inflicts damage on a fleeing opponent
                    int damageSuffered = monsters[i].DamageOnFlee();
                    hero.HP -= damageSuffered;
                    Dialoge.DamageTakenOnFlee(monsters[i], hero, damageSuffered);
                }

            }

        }

    }
}
