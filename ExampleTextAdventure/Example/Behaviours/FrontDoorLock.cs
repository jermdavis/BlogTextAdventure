using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class FrontDoorLock : Behaviour
    {
        public FrontDoorLock() : base("frontdoorlock")
        {
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if (action is CanLeaveRoomAction clr)
            {
                var rm = (Room)owner;
                var key = InputParser.MatchEntities(world.Player.Items, "key");

                if (clr.FromRoom == rm && clr.Direction == "east")
                {
                    if (key == null)
                    {
                        world.Display("The front door is locked. You'll need a key to get in.");
                        return false;
                    }
                    else
                    {
                        world.Display("You open the front door with the key you found.");
                        return true;
                    }
                }
            }

            if(action is CanEnterRoomAction cer)
            {
                var rm = (Room)owner;
                var key = InputParser.MatchEntities(world.Player.Items, "key");

                if (cer.ToRoom == rm && cer.Direction == "west")
                {
                    if (key == null)
                    {
                        world.Display("The front still has its lock. You need the key to leave.");
                        return false;
                    }
                    else
                    {
                        world.Display("You open the front door with the key you found.");
                        return true;
                    }
                }
            }

            return true;
        }
    }

}