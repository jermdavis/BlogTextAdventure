using AdventureEngine.Scripts;
using System.Reflection;

namespace AdventureEngine
{
    
    public static class WorldExtensions
    {
        public static World RegisterBehaviour<BS>(this World world) where BS : Behaviour, new()
        {
            var b = new BS();
            world.Behaviours.Add(b.Name, b);
            return world;
        }

        public static World RegisterBehaviour<BS>(this World world, BS b) where BS : Behaviour
        {
            world.Behaviours.Add(b.Name, b);
            return world;
        }

        public static World RegisterCommand<CM>(this World world) where CM : Command, new()
        {
            var c = new CM();
            world.Commands.Add(c.Name, c);
            return world;
        }

        public static World RegisterCommands(this World world, Assembly dll)
        {
            var cmds = dll.GetTypes().Where(t => t.IsAssignableTo(typeof(Command)));

            foreach (var cmd in cmds)
            {
                var constructor = cmd.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                    var command = (Command)constructor.Invoke(null);
                    world.Commands.Add(command.Name, command);
                }
            }

            return world;
        }

        public static World RegisterBehaviours(this World world, Assembly dll)
        {
            var bhs = dll.GetTypes().Where(t => t.IsAssignableTo(typeof(Behaviour)));

            foreach (var bh in bhs)
            {
                var constructor = bh.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                    var behaviour = (Behaviour)constructor.Invoke(null);
                    world.Behaviours.Add(behaviour.Name, behaviour);
                }
            }

            return world;
        }
    }

}