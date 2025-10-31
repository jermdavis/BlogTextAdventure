namespace AdventureEngine.Scripts
{
    
    public abstract class Script
    {
        public string Name { get; }

        public Script(string name)
        {
            Name = name;
        }
    }

}