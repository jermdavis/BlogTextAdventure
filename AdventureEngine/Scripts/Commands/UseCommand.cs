using AdventureEngine.Scripts.Actions;

namespace AdventureEngine.Scripts.Commands
{
    
    public class UseCommand : Command
    {
        public UseCommand() : base("use", "use <item> - make use of an item to do a thing")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            if(parameters.Length == 0)
            {
                world.Display("Use what?");
                return;
            }

            var itemName = parameters[0];

            // is it in the player's inventory?
            var item = InputParser.MatchEntities(world.Player.Items, itemName);
            if (item == null)
            {
                // or is it in the room?
                item = InputParser.MatchEntities(world.Player.Room.Items, itemName);

                if(item == null)
                {
                    world.Display($"Where's the {itemName} you want to use?");
                    return;
                }
            }

            var canUse = new CanUseItemAction(world.Player, item);
            if(!VerifyCommand(world.Player.Room.Characters, world, canUse))
            {
                return;
            }
            if (!VerifyCommand(world.Player.Room, world, canUse))
            {
                return;
            }
            if (!VerifyCommand(world.Player.Room.Items, world, canUse))
            {
                return;
            }
            if (!VerifyCommand(world.Player.Items, world, canUse))
            {
                return;
            }

            world.Display($"You use {item.Article} {item.Name}.");

            var hasUsed = new HasUsedItemAction(world.Player, item);
            VerifyCommand(world.Player.Room.Characters, world, hasUsed);
            VerifyCommand(world.Player.Room, world, hasUsed);
            VerifyCommand(world.Player.Room.Items, world, hasUsed);
            VerifyCommand(world.Player.Items, world, hasUsed);
        }
    }

}