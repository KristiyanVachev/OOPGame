namespace OOPGame.ConsoleClient
{
    using System;
    using OOPGame.Core.Interfaces;
    using OOPGame.Core.Infrastructure;
    using OOPGame.Core.Models;

    public static class Utillities
    {
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
    }
}
