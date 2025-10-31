using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    public class StatueBehaviour : Behaviour
    {
        public StatueBehaviour() : base("statue")
        {
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            if (action is HasUsedItemAction hua)
            {
                if(hua.Item.Name == "flower")
                {
                    hua.Character.DropItem(hua.Item);
                    hua.Item.IsNotVisible();

                    owner.SetProperty("hasFlower", 1);

                    world.Display("You reach up and put the flower into the knight's hand. With a grating creak its fingers close around the stem, holding it tightly and the flower starts to glow with a warm light.");
                }
            }

            if(action is HasExaminedItemAction hei)
            {
                if(owner.TestProperty("hasFlower",1))
                {
                    world.Display("In one hand, he's holding a flower. It's glowing faintly.");
                }
                else
                {
                    world.Display("He's holding his hand out as if he should be holding something.");
                }
            }

            if(action is HasEnteredRoomAction her)
            {
                her.Player.AddCommand("use");
            }
            if(action is HasLeftRoomAction hlr)
            {
                hlr.Player.RemoveCommand("use");
            }

            return true;
        }
    }

}