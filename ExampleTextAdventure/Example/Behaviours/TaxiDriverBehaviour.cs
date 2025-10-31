using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class TaxiDriverBehaviour : Behaviour
    {
        public TaxiDriverBehaviour() : base("taxidriver")
        {
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            // on entry, say stuff

            if(action is HasEnteredRoomAction har)
            {
                world.Display("You climb into the taxi, and the driver greets you with a cheery hello.");
                world.Display("'Where too guv?' he asks, and you explain your destination.");
                world.Display("'£5 please.' he responds. 'We have a new pay-up-front policy.'");
                return true;
            }

            if(action is CanGiveItemAction hgi)
            {
                var cash = InputParser.MatchEntities(world.Player.Items, "cash");
                var driver = InputParser.MatchEntities(world.Player.Room.Characters, "taxi driver");

                if (hgi.Item != cash || hgi.ToCharacter != driver)
                {
                    return false;
                }

                world.Display("You hand the driver his money and put on your seatbelt.");
                world.Display("He pulls away with a spray of gravel, and drives you down the very long lane...");

                world.Game.Running = false;
            }

            return true;
        }
    }

}