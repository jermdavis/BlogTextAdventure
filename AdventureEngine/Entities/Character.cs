using AdventureEngine.Scripts;

namespace AdventureEngine.Entities
{
    
    public class Character : Entity
    {
        public Room Room { get; set; }
        public List<Item> Items { get; } = new();
    }

}