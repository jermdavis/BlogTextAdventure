using AdventureEngine.Entities;
using AdventureEngine.Scripts.Actions;
using AdventureEngine.Scripts.Commands;

namespace AdventureEngine.Scripts.Behaviours
{
    
    public class CantGet : Behaviour
    {
        public CantGet() : base("cantget")
        {
        }

        public override bool Execute(Entity owner, World world, Action action)
        {
            if (action is CanGetItemAction)
            {
                world.Display($"You can't pick up.");
                return false;
            }

            return true;
        }
    }

}