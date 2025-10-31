using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class KitchenBehaviour : Behaviour
    {
        public KitchenBehaviour() : base("kitchen")
        { 
        }

        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            // deny patio exit
            if (action is CanLeaveRoomAction clr && clr.FromRoom == owner)
            {
                var rm = (Room)owner;
                var ex = InputParser.MatchExit(rm.Exits, clr.Direction);

                if(ex == null)
                {
                    return true;
                }

                var target = world.Rooms.Where(r => r.Name == "patio").First();

                if (ex.Value.Value == target)
                {
                    world.Display("As you approach the door, you can see there's a large dog just outside. It's growling. Going out that way is likely to end badly.");
                    return false;
                }
            }

            if(action is HasUsedItemAction hua)
            {
                var kettle = InputParser.MatchEntities(world.Player.Room.Items, "kettle");
                var cup = InputParser.MatchEntities(world.Player.Items, "cup");
                if (hua.Item == kettle || hua.Item == cup)
                {
                    if (cup == null)
                    {
                        world.Display("The kettle boils. What are you going to do with it?");
                        return false;
                    }
                    else
                    {
                        world.Display("After the kettle boils, and you use one of the dodgy looking teabags to make a cup of tea.");

                        //  remove & hide cup.
                        world.Player.Items.Remove(cup);
                        cup.Character = null;
                        cup.Room = world.Player.Room;
                        world.Player.Room.Items.Add(cup);
                        cup.IsNotVisible();

                        // show and give tea.
                        var tea = world.Player.Room.Items.Where(i => i.Name == "tea").First();
                        world.Player.Room.Items.Remove(tea);
                        tea.Room = null;
                        tea.Character = world.Player;
                        world.Player.Items.Add(tea);
                        tea.IsVisible();

                        return true;
                    }
                }
            }

            if(action is HasEnteredRoomAction her)
            {
                world.Player.AddCommand("use");
            }
            if (action is HasLeftRoomAction hlr)
            {
                world.Player.RemoveCommand("use");
            }

            return true;
        }
    }

}