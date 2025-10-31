using AdventureEngine.Scripts;

namespace AdventureEngine.Entities
{
    
    public abstract class Entity
    {
        public string Article { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Behaviours { get; } = new();
        public Dictionary<string, int> Properties { get; } = new();
        public bool Visible { get; set; } = true;

        public bool TestProperty(string name, int value)
        {
            if(!Properties.ContainsKey(name))
            {
                return false;
            }

            return Properties[name] == value;
        }
    }

}