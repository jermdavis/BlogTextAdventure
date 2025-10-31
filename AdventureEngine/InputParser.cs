using AdventureEngine.Entities;
using AdventureEngine.Scripts;

namespace AdventureEngine
{
    
    public class InputParser
    {
        public string[] Parse(string input)
        {
            return input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        public static string? MatchVerb(IEnumerable<string> playerCommands, string verb)
        {
            var command = playerCommands
                .Where(c => string.Compare(c, verb, ignoreCase: true) == 0)
                .FirstOrDefault();

            if(command != null)
            {
                return command; 
            }

            var partialCommand = playerCommands
                .Where(c => c.StartsWith(verb, StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault();

            if (partialCommand != null)
            {
                return partialCommand;
            }

            return null;
        }

        public static KeyValuePair<string,Room>? MatchExit(Dictionary<string,Room> exits, string direction)
        {
            foreach(var exit in exits)
            {
                if (exit.Value.Visible && string.Compare(exit.Key, direction, ignoreCase: true) == 0)
                {
                    return exit;
                }
            }

            foreach(var exit in exits)
            {
                if(exit.Value.Visible && exit.Key.StartsWith(direction, StringComparison.InvariantCultureIgnoreCase))
                {
                    return exit;
                }
            }

            return null;
        }

        public static T? MatchEntities<T>(IEnumerable<T> entities, string name) where T : Entity
        {
            foreach (T entity in entities)
            {
                if(MatchEntity(entity, name))
                {
                    return entity;
                }
            }
            return default;
        }

        public static bool MatchEntity<T>(T entity, string name) where T : Entity
        {
            if(entity.Visible)
            {
                if (string.Compare(entity.Name, name, ignoreCase: true) == 0)
                {
                    return true;
                }

                if (entity.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }

                if(entity.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            
            return false;
        }
    }

}