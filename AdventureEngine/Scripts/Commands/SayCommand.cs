using AdventureEngine.Scripts.Actions;

namespace AdventureEngine.Scripts.Commands
{

    public class SayCommand : Command
    {
        public SayCommand() : base("say", "say <message> - speak to someone")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            var canSay = new CanSayAction(world.Player, parameters[0]);

            if (!VerifyCommand(world.Player.Room.Characters, world, canSay))
            {
                return;
            }
            if (!VerifyCommand(world.Player.Items, world, canSay))
            {
                return;
            }
            if (!VerifyCommand(world.Player.Room, world, canSay))
            {
                return;
            }
            if (!VerifyCommand(world.Player.Room.Items, world, canSay))
            {
                return;
            }

            world.Display($"You say '{parameters[0]}'");

            var hasSaid = new HasSaidAction(world.Player, parameters[0]);

            VerifyCommand(world.Player.Room.Characters, world, hasSaid);
            VerifyCommand(world.Player.Items, world, hasSaid);
            VerifyCommand(world.Player.Room, world, hasSaid);
            VerifyCommand(world.Player.Room.Items, world, hasSaid);
        }
    }

}