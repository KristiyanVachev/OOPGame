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

            for (int i = 0; i < monsters.Length; i++)
            {
                //attack menu
                Console.WriteLine("There is a {0} ahead.", monsters[i].Name);
                Console.WriteLine("0. Fight");
                Console.WriteLine("1. Flee");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 0)
                {
                    //fight
                    while (hero.HP > 0 && monsters[i].HP > 0)
                    {
                        for (int j = 0; j < hero.AttackNames.Length; j++)
                        {
                            Console.WriteLine("{0}. Attack with {1}", j, hero.AttackNames[j]);
                        }
                        Console.WriteLine("3. Drink potion");
                        answer = int.Parse(Console.ReadLine());

                        //Perform action based on answer
                        if (answer >= 0 && answer < 3)
                        {
                            AttackMonster(hero, monsters[i], answer);
                            if (monsters[i].HP <= 0)
                            {
                                Console.WriteLine("You have defeated {0} and have reached a new level.", monsters[i].Name);
                                if (i % 2 == 0)
                                {
                                    int ind = i / 2;
                                    Console.WriteLine("You have found a new sword: {0}", swords[ind].Name);
                                    hero.Sword = swords[ind];
                                }
                                else
                                {
                                    int ind = (i  - 1) / 2;
                                    Console.WriteLine("You have found a new shield: {0}", shields[ind].Name);
                                    hero.Shield = shields[ind];
                                }

                                hero.LevelUp();
                                Console.WriteLine("{0} - HP: {1} - Damage: {2} - Armor: {3}", hero.Name, hero.HP, hero.Damage, hero.Armor);

                                break;
                            }
                            MonsterAttack(hero, monsters[i]);
                            if (hero.HP <= 0)
                            {
                                Console.WriteLine("You have died and have failed your princess.");
                                break;
                            }
                        }
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
                            MonsterAttack(hero, monsters[i]);
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
                    //declare result
                    if (hero.HP < 0)
                    {
                        Console.WriteLine("You have died and have failed your princess.");
                        break;
                    }

                }
                else if (answer == 1)
                {
                    //flee
                    hero.HP -= monsters[i].DamageOnFlee();
                }
                else //invalid answer
                {
                    Console.WriteLine("Invalid answer.");
                    i--;
                }

            }

        }

        static void AttackMonster(Hero hero, IMonster monster, int answer)
        {
            if (RandomChance.Success(100 - monster.Armor))
            {
                int damageDealth = hero.Attack(hero.AttackChance[answer], hero.AttackPower[answer]);
                if (damageDealth != 0)
                {
                    monster.HP -= damageDealth;
                    if (monster.HP > 0)
                    {
                        Console.WriteLine("You dealth {0} damage. {1} now has {2}HP", damageDealth, monster.Name, monster.HP);
                    }
                    else
                    {
                        Console.WriteLine("You dealth {0} damage.", damageDealth);
                    }
                }
                else
                {
                    //Attack failed
                    Console.WriteLine("You couldn't perform your {0}.", hero.AttackNames[answer]);
                }
            }
            else
            {
                //armor blocked
                Console.WriteLine("{0}'s armor stopped your attack.", monster.Name);
            }
        }

        static void MonsterAttack(Hero hero, IMonster monster)
        {
            //assign a random attack for the monster
            Random rnd = new Random();
            int answer = rnd.Next(0, 3);

            if (RandomChance.Success(100 - hero.Armor))
            {
                int damageDealth = monster.Attack(monster.AttackChance[answer], monster.AttackPower[answer]);
                if (damageDealth != 0)
                {
                    hero.HP -= damageDealth;
                    Console.WriteLine("{0} dealth you {1} damage with {2}. You now have {3}HP.", monster.Name, damageDealth, monster.AttackNames[answer], hero.HP);
                }
                else
                {
                    //Attack failed
                    Console.WriteLine("{0} couldn't perform {1}.", monster.Name, monster.AttackNames[answer]);
                }
            }
            else
            {
                //armor blocked
                Console.WriteLine("Your armor stopped {0}'s attack.", monster.Name);
            }
        }
    }
}
