using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{

    public class GateMovementBehaviour : Behaviour
    {
        public GateMovementBehaviour() : base("gatemovement")
        { 
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if (action is CanLeaveRoomAction clr && clr.FromRoom == owner)
            {
                if (string.Compare(clr.Direction, "west", ignoreCase: true) == 0)
                {
                    world.Display("It really was a very long walk down that lane to get here. You've no desire to do that again.");
                    return false;
                }
            }

            if(action is HasLeftRoomAction hlr && hlr.FromRoom == owner)
            {
                if (string.Compare(hlr.Direction, "east", ignoreCase: true) == 0)
                {
                    world.Display("The gate creaks shut behind you. Ominously.");
                    return true;
                }
            }

            if (action is HasEnteredRoomAction her && her.ToRoom == owner)
            {
                if (string.Compare(her.Direction, "west", ignoreCase: true) == 0)
                {
                    world.Display("The gate creaks shut behind you. It's still ominous.");
                    return true;
                }
            }

            return true;
        }
    }

}