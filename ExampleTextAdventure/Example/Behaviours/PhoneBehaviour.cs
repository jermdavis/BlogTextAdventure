using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class PhoneBehaviour : Behaviour
    {
        public PhoneBehaviour() : base("phone")
        {
        }
        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if(action is HasEnteredRoomAction)
            {
                world.Player.AddCommand("call");
            }
            
            if(action is HasLeftRoomAction)
            {
                world.Player.RemoveCommand("call");
            }

            return true;
        }
    }

}