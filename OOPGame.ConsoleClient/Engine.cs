namespace OOPGame.ConsoleClient
{
    using System;

    using OOPGame.Core.Interfaces;
    using OOPGame.Core.Models;

    public static class Engine
    {
        public static void Initialize()
        {
            Console.Write("Enter your hero's name: ");
            string name = Console.ReadLine();
            IHero hero = new Hero(name);

            IMonster[] monsters = Seed.SeedMonsters();
            IWeapon[] weapons = Seed.SeedRewards();

            bool finalBoss = false;
            const int meetMonsterOpt = 2;
            const int attackMenuOpt = 4;
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
                int input;
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
                        if (input >= 0 && input < attackMenuOpt - 1)
                        {
                            //Hero attacks monster
                            Action.Attack(hero, monsters[i], input);
                            //If monster is dead
                            if (monsters[i].HP <= 0)
                            {
                                //Killing a commom monster
                                if (!finalBoss)
                                {
                                    Dialoge.MonsterDefeated(monsters[i]);

                                    Action.GetReward(weapons[i], hero);
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
                                Action.Attack(monsters[i], hero, 0);
                            }
                            //If hero dies
                            if (hero.HP <= 0)
                            {
                                Dialoge.HeroDied();
                                break;
                            }
                        }
                        //answer left is 3, drink potion
                        else
                        {
                            Action.DrinkPotion(hero);
                            Action.Attack(monsters[i], hero, 0);
                            if (hero.HP <= 0)
                            {
                                Dialoge.HeroDied();
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
                    if (hero.HP <= 0)
                    {
                        Dialoge.HeroDiedFleeing();
                        break;
                    }
                    else
                    {
                        Dialoge.DamageTakenOnFlee(monsters[i], hero, damageSuffered);
                    }
                }
            }
        }
    }
}
