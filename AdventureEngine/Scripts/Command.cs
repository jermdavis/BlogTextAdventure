using AdventureEngine.Entities;

namespace AdventureEngine.Scripts
{

    public abstract class Command : Script
    {
        public string Help { get; }

        public Command(string name, string help) : base(name)
        {
            Help = help;
        }

        public static bool VerifyCommand(Entity target, World world, Action action, string? parameter = null)
        {
            var canExecute = true;
            foreach (var behaviourName in target.Behaviours)
            {
                var behaviour = world.Behaviours[behaviourName];
                if (behaviour?.Execute(target, world, action) == false)
                {
                    canExecute = false;
                }
            }

            return canExecute;
        }

        public static bool VerifyCommand(IEnumerable<Entity> targets, World world, Action action, string? parameter = null)
        {
            var canExecute = true;

            var targetSet = targets.ToArray();
            foreach (var owner in targetSet)
            {
                if(VerifyCommand(owner, world, action, parameter) == false)
                {
                    canExecute = false;
                }
            }

            return canExecute;
        }

        public abstract void Execute(World world, string[] parameters);
    }

}