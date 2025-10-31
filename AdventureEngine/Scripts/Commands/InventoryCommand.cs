namespace AdventureEngine.Scripts.Commands
{
    public class InventoryCommand : Command
    {
        public InventoryCommand() : base("inventory", "inventory - what are you carrying?")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            world.Display("You're carrying:");
            var visibleItems = world.Player.Items.Where(i => i.Visible);
            if (visibleItems.Count() > 0)
            {
                foreach(var item in world.Player.Items)
                {
                    if (item.Visible)
                    {
                        world.Display($"  {item.Article} {item.Name}");
                    }
                }
            }
            else
            {
                world.Display("  Nothing");
            }
        }
    }

}