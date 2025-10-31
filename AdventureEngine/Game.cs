using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace AdventureEngine
{
    
    public class Game
    {
        public bool Running { get; set; } = true;
        public World World { get; }

        public Game(World world)
        {
            World = world;
        }
        
        public void Update(string[] input)
        {
            var verb = input[0];
            var parameters = input[1..];

            var commandName = InputParser.MatchVerb(World.Player.Commands, verb);
            if (commandName == null)
            {
                // check if verb is a valid direction - if so 
                var exit = InputParser.MatchExit(World.Player.Room.Exits, verb);
                if (exit == null)
                {
                    World.Display($"You can't '{verb}' right now.");
                    return;
                }

                // yes - try again as a faked "move" operation
                parameters = [verb];
                verb = "move";
                commandName = InputParser.MatchVerb(World.Player.Commands, verb);
            }

            World.Commands.TryGetValue(commandName!, out Command? command);

            if (command == null)
            {
                World.Display($"You can't '{verb}' right now.");
                return;
            }

            Console.WriteLine();

            HasExecutedCommand hec = new(World.Player, World.Player.Room, verb);
            Command.VerifyCommand(World.Player, World, hec);
            Command.VerifyCommand(World.Player.Items, World, hec);
            Command.VerifyCommand(World.Player.Room, World, hec);
            Command.VerifyCommand(World.Player.Room.Items, World, hec);

            command.Execute(World, parameters);
        }
    }

}