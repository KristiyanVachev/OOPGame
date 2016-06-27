namespace OOPGame.ConsoleClient
{
    using System;
    using OOPGame.Core.Interfaces;
    using OOPGame.Core.Infrastructure;

    public static class Utillities
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

        public static int ValidateAnswer(int scopeEnd)
        {
            while (true)
            {
                try
                {
                    int answer = int.Parse(Console.ReadLine());
                    if (answer >= 0 && answer < scopeEnd)
                    {
                        return answer;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Select a number between 0 and {0}", scopeEnd);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid answer. Select a number in the scope [0...{0}]", scopeEnd);
                }
            }
        }

        //To-Do
        //public static void Fight(IHero hero, IMonster monster)
        //{
            
        //}
    }
}
