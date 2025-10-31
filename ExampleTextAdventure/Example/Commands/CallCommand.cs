using AdventureEngine;
using AdventureEngine.Scripts;

namespace ExampleTextAdventure.Example.Commands
{
    
    public class CallCommand : Command
    {
        public CallCommand() : base("call", "call <thing> - phone someone, if you know the number.")
        {
        }
        public override void Execute(World world, string[] parameters)
        {
            if(parameters.Length == 0 || parameters[0].Length == 0)
            {
                world.Display("Call what?");
                return;
            }

            var card = InputParser.MatchEntities(world.Player.Items, "business card");
            if (card != null && string.Compare(parameters[0], "taxi", true) == 0)
            {
                world.Display("You phone the taxi company. They promise a car will arrive at the taxi waiting spot very soon.");
                world.Display("In fact, pretty much before you've had a chance to say thanks and put the phone down, you hear the crunch of gravel outside.");

                var taxiRoom = world.Rooms.Where(r => r.Name == "taxi").First();
                taxiRoom.Visible = true;
            }
            else
            {
                world.Display("What number would you even dial?");
            }
        }
    }

}