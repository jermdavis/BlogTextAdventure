using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class EnterWorldBehaviour : Behaviour
    {
        public EnterWorldBehaviour() : base("enterworld")
        {
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if(action is HasEnteredWorld hew)
            {
                world.Display(
                    """"
                    It has been a very long day.

                    You've just walked the best part of four miles from where got off the bus. And it turns out the directions you were given aren't right. There's no sign of the office you were looking for - just an old cottage.

                    Your feet are telling you that there'll be an open rebellion if you try to walk all the way back.
                    
                    So time to look for an alternative...
                    """"
                );
            }

            return true;
        }
    }

}