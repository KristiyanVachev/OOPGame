namespace OOPGame.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OOPGame.Core.Models;

    class Startup
    {
        static void Main()
        {
            string name = Console.ReadLine();
            Hero hero = new Hero(name);
            Console.WriteLine(hero.Name);
        }
    }
}
