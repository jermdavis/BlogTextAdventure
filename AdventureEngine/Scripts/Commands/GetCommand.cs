using AdventureEngine.Scripts.Actions;

namespace AdventureEngine.Scripts.Commands
{

    public class GetCommand : Command
    {
        public GetCommand() : base("get","get <room item> - pick up something from the room")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            if(parameters.Length == 0)
            {
                world.Display("Get what?");
                return;
            }

            var itemName = parameters[0];

            var item = InputParser.MatchEntities(world.Player.Room.Items, itemName);

            if (item == null)
            {
                world.Display($"There's no {itemName} here");
                return;
            }

            var canGet = new CanGetItemAction(world.Player.Room, item, world.Player);

            if (VerifyCommand(world.Player.Room, world, canGet) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player, world, canGet) == false)
            {
                return;
            }
            if (VerifyCommand(item, world, canGet) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player.Room.Characters, world, canGet) == false)
            {
                return;
            }

            world.Player.GetItem(item);

            var hasGot = new HasGotItemAction(world.Player.Room, item, world.Player);

            VerifyCommand(world.Player.Room, world, hasGot);
            VerifyCommand(world.Player, world, hasGot);
            VerifyCommand(item, world, hasGot);
            VerifyCommand(world.Player.Room.Characters, world, hasGot);

            world.Display($"You get {item.Article} {item.Name}");
        }
    }

}