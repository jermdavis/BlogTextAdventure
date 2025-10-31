using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{

    public class BellBehaviour : Behaviour
    {
        public BellBehaviour() : base("bell")
        {
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if(action is HasEnteredRoomAction har)
            {
                world.Player.AddCommand("ring");
            }

            if(action is HasLeftRoomAction hlr)
            {
                world.Player.RemoveCommand("ring");
            }

            return true;
        }
    }

}