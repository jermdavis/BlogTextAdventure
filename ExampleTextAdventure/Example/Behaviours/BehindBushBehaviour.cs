using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{

    public class BehindBushBehaviour : Behaviour
    {
        public BehindBushBehaviour() : base("behindbush")
        {
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if(action is HasExaminedItemAction hei)
            {
                if (hei.Item.Name == "bush")
                {
                    var rm = world.Rooms.Where(r => r.Name == "compost heap").First();
                    rm.Visible = true;
                }
            }

            return true;
        }
    }

}