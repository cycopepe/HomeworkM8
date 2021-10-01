using Business;
using Services;
using System;
using System.Linq;

namespace HomeworkM8
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                return -1;
            }

            int.TryParse(args[0], out int addValue);

            var service = new PlayerService();
            var rawPlayers = service.GetPlayers();
            var players = rawPlayers.Select(x => (x.Name, x.Height)).ToList();
            var module = new PlayersModule();

            var result = module.GetPlayersAddUps(players, addValue);

            if (result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine($"- {item.Item1}      {item.Item2}");
                }
            }
            else {
                Console.WriteLine("No matches found");
            }


            Console.WriteLine("\nPress any key to exit");
            Console.ReadKey();
            return 0;
        }
    }
}
