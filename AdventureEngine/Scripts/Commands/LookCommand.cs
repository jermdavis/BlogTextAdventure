namespace AdventureEngine.Scripts.Commands
{
    
    public class LookCommand : Command
    {
        public LookCommand() : base("look", "look - examine your surroundings")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            var r = world.Player.Room;

            world.Display($"{r.Article} {r.Name}");
            if (!string.IsNullOrWhiteSpace(r.Description))
            {
                world.Display(r.Description);
            }
            
            var visibleExits = r.Exits.Where(e => e.Value.Visible);
            if (visibleExits.Any())
            {
                world.Display("Exits:");
                foreach (var exit in visibleExits)
                {
                    world.Display($"  To the {exit.Key} is {exit.Value.Article} {exit.Value.Name}");
                }
            }

            var visibleCharacters = r.Characters.Where(c => c.Visible && c != world.Player);
            if (visibleCharacters.Any())
            {
                world.Display("Characters:");
                foreach (var character in visibleCharacters)
                {
                    if (character != world.Player)
                    {
                        world.Display($"  {character.Article} {character.Name}");
                    }
                }
            }

            var visibleItems = r.Items.Where(c => c.Visible);
            if (visibleItems.Any())
            {
                world.Display("Items:");
                foreach(var item in visibleItems)
                {
                    world.Display($"  {item.Article} {item.Name}");
                }
            }
        }
    }

}