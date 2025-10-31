using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class DoormatBehaviour : Behaviour
    {
        public DoormatBehaviour() : base("doormat")
        {
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if(action is HasExaminedItemAction hei)
            {
                var itm = world.Items.Where(i => i.Name == "key").First();
                if (itm.Visible == false)
                {
                    world.Display("The lump is a key..");
                    itm.Visible = true;
                }
                else
                {
                    world.Display("There's no lump now - nothing else to find but some mud and dust.");
                }
            }

            return true;
        }
    }

}