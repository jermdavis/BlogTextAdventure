using AdventureEngine.Entities;

namespace AdventureEngine.Scripts
{

    public abstract class Behaviour : Script
    {
        public Behaviour(string name) : base(name)
        {
        }

        public abstract bool Execute(Entity owner, World world, Action action);
    }

}