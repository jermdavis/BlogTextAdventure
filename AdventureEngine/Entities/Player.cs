using AdventureEngine.Scripts;

namespace AdventureEngine.Entities
{
    
    public class Player : Character
    {
        public List<string> Commands { get; } = new();

        public bool HasItem(string name)
        {
            var itm = this.Items.Where(i => string.Compare(name, i.Name, true)==0).FirstOrDefault();

            if (itm != null)
            {
                return true;
            }

            return false;
        }
    }

}