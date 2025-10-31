using AdventureEngine.Scripts;

namespace AdventureEngine.Entities
{
    
    public class Item : Entity
    {
        public Room? Room { get; set; }
        public Character? Character { get; set; }
    }

}