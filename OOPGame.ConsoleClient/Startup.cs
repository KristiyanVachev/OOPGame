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

            for (int i = 0; i < monsters.Length; i++)
            {
                //attack menu
                Console.WriteLine("There is a {0} ahead.",monsters[i].Name);
                Console.WriteLine("0. Fight");
                Console.WriteLine("1. Flee");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 0)
                {
                    //fight
                    while (hero.HP > 0 && monsters[i].HP > 0)
                    {
                        Console.WriteLine("0. Attack with {0}",hero.WeakAttackName);
                        Console.WriteLine("1. Attack with {0}", hero.StrongAttackName);
                        Console.WriteLine("2. Attack with {0}", hero.UltimateAttackName);
                        Console.WriteLine("3. Drink potion");
                        answer = int.Parse(Console.ReadLine());
                        switch (answer)
                        {
                            case 0:
                                //attack with weak attack
                                if (RandomChance.Success(100 - monsters[i].Armor))
                                {
                                    int damageDealth = hero.WeakAttack();
                                    if (damageDealth != 0)
                                    {
                                        monsters[i].HP -= damageDealth;
                                    }
                                    else
                                    {
                                        //Attack failed
                                    }
                                }
                                else
                                {
                                    //miss because of armor
                                }
                                break;
                            case 1:
                                //attack with strong attack
                                break;
                            case 2:
                                //attack with ultimate attack
                                break;
                            case 3:
                                //drink potion
                                break;
                            default:
                                //invalid answer
                                break;
                        }


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
    }
}
