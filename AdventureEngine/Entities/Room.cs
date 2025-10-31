using AdventureEngine.Scripts;

namespace AdventureEngine.Entities
{
    
    public class Room : Entity
    {
        
        public Dictionary<string, Room> Exits { get; } = new();
        public List<Character> Characters { get; } = new();
        public List<Item> Items { get; } = new();
    }

}