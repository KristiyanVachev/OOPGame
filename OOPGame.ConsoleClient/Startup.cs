namespace OOPGame.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

            //Meet every monster.
            for (int i = 0; i < monsters.Length; i++)
            {
                int answer;
                //If you are up against the final monster -> special boss dialog.
                if (i == monsters.Length - 1)
                {
                    finalBoss = true;
                }
                //Hero attack or flee menu
                if (!finalBoss)
                {
                    Console.WriteLine("There is a {0} ahead.", monsters[i].Name);
                    Console.WriteLine("0. Fight");
                    Console.WriteLine("1. Flee");

                    //Validation for input of attack or flee option
                    while (true)
                    {
                        try
                        {
                            answer = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid number. Try again.");
                        }
                    }
                }
                else //Boss dialog
                {   
                    Console.WriteLine("You have reached the mighty {0}. You must slay it to save your princess!", monsters[i].Name);
                    answer = 0;
                }

                //Option fight
                if (answer == 0)
                {
                    //Fight until one is dead
                    while (hero.HP > 0 && monsters[i].HP > 0)
                    {
                        //Menu for attack options
                        for (int j = 0; j < hero.AttackNames.Length; j++)
                        {
                            Console.WriteLine("{0}. Attack with {1}", j, hero.AttackNames[j]);
                        }
                        Console.WriteLine("3. Drink potion");
                        //Validation for input of attack options
                        while (true)
                        {
                            try
                            {
                                answer = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Invalid number. Try again.");
                            }
                        }
                        //Perform action based on answer
                        //If answer is an attack
                        if (answer >= 0 && answer < 3)
                        {
                            //Hero attacks monster
                            Attack(hero, monsters[i], answer);
                            //If monster is dead
                            if (monsters[i].HP <= 0)
                            {
                                //Killing a commom monster
                                if (!finalBoss)
                                {
                                    Console.WriteLine("You have defeated {0} and have reached a new level.", monsters[i].Name);
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
                                    Console.WriteLine("You have defeated the ëvil {0} and have saved your princess.", monsters[i].Name);
                                }

                            }
                            //Monster still alive
                            else
                            {
                                Attack(monsters[i], hero, 0);
                            }
                            //If hero dies
                            if (hero.HP <= 0)
                            {
                                Console.WriteLine("You have died and have failed your princess.");
                                break;
                            }
                        }
                        //option Drink Potion
                        else if (answer == 3)
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
                            Attack(monsters[i], hero, 0);
                            if (hero.HP <= 0)
                            {
                                Console.WriteLine("You have died and have failed your princess.");
                                break;
                            }
                        }
                        else
                        {
                            //invalid answer
                            Console.WriteLine("Invalid answer. Try again");
                        }
                    }
                }
                //Option flee
                else if (answer == 1)
                {
                    //Monster always inflicts damage on a fleeing opponent
                    int damageSuffered = monsters[i].DamageOnFlee();
                    hero.HP -= damageSuffered;
                    Console.WriteLine("While you were fleeing {0} dealth you {1}. You now have {2}HP.", monsters[i].Name, damageSuffered, hero.HP);

                }
                else //invalid answer
                {
                    Console.WriteLine("Invalid answer.");
                    i--;
                }

            }

        }

        
        static void Attack(ICreature attacker, ICreature deffender, int answer)
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
                        Console.WriteLine("{3} dealth {0} damage. {1} now has {2}HP", damageDealth, deffender.Name, deffender.HP, attacker.Name);
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

        //static void AttackMonster(Hero hero, IMonster monster, int answer)
        //{
        //    if (RandomChance.Success(100 - monster.Armor))
        //    {
        //        int damageDealth = hero.Attack(hero.AttackChance[answer], hero.AttackPower[answer]);
        //        if (damageDealth != 0)
        //        {
        //            monster.HP -= damageDealth;
        //            if (monster.HP > 0)
        //            {
        //                Console.WriteLine("You dealth {0} damage. {1} now has {2}HP", damageDealth, monster.Name, monster.HP);
        //            }
        //            else
        //            {
        //                Console.WriteLine("You dealth {0} damage.", damageDealth);
        //            }
        //        }
        //        else
        //        {
        //            //Attack failed
        //            Console.WriteLine("You couldn't perform your {0}.", hero.AttackNames[answer]);
        //        }
        //    }
        //    else
        //    {
        //        //armor blocked
        //        Console.WriteLine("{0}'s armor stopped your attack.", monster.Name);
        //    }
        //}

        //static void MonsterAttack(Hero hero, IMonster monster)
        //{
        //    //assign a random attack for the monster
        //    Random rnd = new Random();
        //    int answer = rnd.Next(0, 3);

        //    if (RandomChance.Success(100 - hero.Armor))
        //    {
        //        int damageDealth = monster.Attack(monster.AttackChance[answer], monster.AttackPower[answer]);
        //        if (damageDealth != 0)
        //        {
        //            hero.HP -= damageDealth;
        //            if (hero.HP > 0)
        //            {
        //                Console.WriteLine("{0} dealth you {1} damage with {2}. You now have {3}HP.", monster.Name, damageDealth, monster.AttackNames[answer], hero.HP);
        //            }
        //            else
        //            {
        //                Console.WriteLine("{0} dealth you {1} damage.", monster.Name, damageDealth);
        //            }
        //        }
        //        else
        //        {
        //            //Attack failed
        //            Console.WriteLine("{0} couldn't perform {1}.", monster.Name, monster.AttackNames[answer]);
        //        }
        //    }
        //    else
        //    {
        //        //armor blocked
        //        Console.WriteLine("Your armor stopped {0}'s attack.", monster.Name);
        //    }
        //}
    }
}
