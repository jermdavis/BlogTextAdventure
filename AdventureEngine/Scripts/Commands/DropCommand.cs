using AdventureEngine.Scripts.Actions;

namespace AdventureEngine.Scripts.Commands
{

    public class DropCommand : Command
    {
        public DropCommand() : base("drop", "drop <inventory item> - put something down")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            if (parameters.Length == 0)
            {
                world.Display("Drop what?");
                return;
            }

            var itemName = parameters[0];

            var item = InputParser.MatchEntities(world.Player.Items, itemName);

            if (item == null)
            {
                world.Display($"You're not carrying {itemName}");
                return;
            }

            var canDrop = new CanDropItemAction(world.Player.Room, item, world.Player);

            if (VerifyCommand(world.Player.Room, world, canDrop) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player, world, canDrop) == false)
            {
                return;
            }
            if (VerifyCommand(item, world, canDrop) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player.Room.Characters, world, canDrop) == false)
            {
                return;
            }

            world.Player.DropItem(item);

            var hasDropped = new HasDroppedItemAction(world.Player.Room, item, world.Player);

            VerifyCommand(world.Player.Room, world, hasDropped);
            VerifyCommand(world.Player, world, hasDropped);
            VerifyCommand(item, world, hasDropped);
            VerifyCommand(world.Player.Room.Characters, world, hasDropped);

            world.Display($"You drop {item.Article} {item.Name}");
        }
    }

}