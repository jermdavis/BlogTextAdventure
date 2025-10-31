namespace AdventureEngine.Scripts.Commands
{
    
    public class QuitCommand : Command
    {
        public QuitCommand() : base("quit", "quit - leave the game")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            world.Game.Running = false;
            world.Display("Goodbye...");
        }
    }

}