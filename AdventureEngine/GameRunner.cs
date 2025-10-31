using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace AdventureEngine
{
    
    public class GameRunner
    {
        public void Run(Func<World> init)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Initialising world...");
            var world = init();

            Console.WriteLine("Starting game...");
            var parser = new InputParser();
            var game = new Game(world);
            world.Game = game;
            Console.WriteLine("Type 'help' if you don't know what you can do...");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            var hew = new HasEnteredWorld(world.Player.Room, world.Player);
            Command.VerifyCommand(world.Player, world, hew);
            Command.VerifyCommand(world.Player.Room, world, hew);

            while (game.Running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("> ");
                var command = Console.ReadLine() ?? string.Empty;
                var input = parser.Parse(command);

                Console.ForegroundColor = ConsoleColor.White;

                if (input.Length > 0)
                {
                    game.Update(input);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}