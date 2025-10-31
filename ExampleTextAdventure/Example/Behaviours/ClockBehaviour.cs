using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class ClockBehaviour : Behaviour
    {
        public ClockBehaviour() : base("clock") { }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if(!owner.Properties.ContainsKey("state"))
            {
                owner.Properties.Add("state", 0);
            }

            if(action is HasExecutedCommand || action is HasEnteredRoomAction)
            {
                if (owner.Properties["state"] == 0)
                {
                    world.Display("* tick *");
                    owner.Properties["state"] = 1;
                }
                else
                {
                    world.Display("* tock *");
                    owner.Properties["state"] = 0;
                }
            }

            return true;
        }
    }

}