namespace AdventureEngine.Scripts.Commands
{
    
    public class HelpCommand : Command
    {
        public HelpCommand() : base("help", "help - what you're reading now")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            world.Display("Verbs you can use right now:");
            foreach (var commandName in world.Player.Commands)
            {
                var command = world.Commands[commandName];
                if (command != null)
                {
                    world.Display($"  {command.Help}");
                }
            }
        }
    }

}