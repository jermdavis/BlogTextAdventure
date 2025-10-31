using AdventureEngine.Scripts.Actions;

namespace AdventureEngine.Scripts.Commands
{

    public class MoveCommand : Command
    {
        public MoveCommand() : base("move", "move <direction> - leave a location via an exit")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            if (parameters.Length == 0)
            {
                world.Display("Move which way?");
                return;
            }

            var direction = parameters[0];

            var rm = InputParser.MatchExit(world.Player.Room.Exits, direction);

            if(rm == null)
            {
                world.Display($"There's no exit '{direction}'");
                return;
            }

            var route = rm.Value;
            var fullDirection = route.Key;
            var toRoom = route.Value;
            var fromRoom = world.Player.Room;

            var canLeave = new CanLeaveRoomAction(fromRoom, toRoom, world.Player, fullDirection);
            var canEnter = new CanLeaveRoomAction(fromRoom, toRoom, world.Player, fullDirection);

            // test from-room
            if (VerifyCommand(fromRoom, world, canLeave) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player, world, canLeave) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player.Items, world, canLeave) == false)
            {
                return;
            }
            if (VerifyCommand(fromRoom.Characters, world, canLeave) == false)
            {
                return;
            }
            if (VerifyCommand(fromRoom.Items, world, canLeave) == false)
            {
                return;
            }

            // test to-room
            if (VerifyCommand(toRoom, world, canEnter) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player, world, canEnter) == false)
            {
                return;
            }
            if (VerifyCommand(toRoom.Items, world, canEnter) == false)
            {
                return;
            }
            if (VerifyCommand(toRoom.Characters, world, canEnter) == false)
            {
                return;
            }
            if (VerifyCommand(toRoom.Items, world, canEnter) == false)
            {
                return;
            }

            world.Player.MoveCharacterToRoom(toRoom);
            world.Display($"You walk {fullDirection} to {toRoom.Article} {toRoom.Name}");

            var hasLeft = new HasLeftRoomAction(fromRoom, toRoom, world.Player, fullDirection);
            var hasEntered = new HasEnteredRoomAction(fromRoom, toRoom, world.Player, fullDirection);

            // notify from-room
            VerifyCommand(fromRoom, world, hasLeft);
            VerifyCommand(world.Player, world, hasLeft);
            VerifyCommand(world.Player.Items, world, hasLeft);
            VerifyCommand(fromRoom.Characters, world, hasLeft);
            VerifyCommand(fromRoom.Items, world, hasLeft);

            // notify to-room
            VerifyCommand(toRoom, world, hasEntered);
            VerifyCommand(world.Player, world, hasEntered);
            VerifyCommand(world.Player.Items, world, hasEntered);
            VerifyCommand(toRoom.Characters, world, hasEntered);
            VerifyCommand(toRoom.Items, world, hasEntered);
        }
    }

}