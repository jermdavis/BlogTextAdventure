using AdventureEngine.Entities;
using AdventureEngine.Scripts;

namespace AdventureEngine
{

    public class World
    {
        public Game Game { get; set; }
        public List<Room> Rooms { get; } = new();
        public List<Character> Characters { get; } = new();
        public List<Item> Items { get; } = new();

        public Player Player { get; set; }

        public Dictionary<string, Behaviour> Behaviours { get; } = new();
        public Dictionary<string, Command> Commands { get; } = new();
    }

}