using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class HasExaminedItemAction : Action
    {
        public Item Item => (Item)base.ParameterOne!;
        public Player Player => (Player)base.ParameterTwo!;

        public HasExaminedItemAction(Item item, Player player)
        {
            base.ParameterOne = item;
            base.ParameterTwo = player;
        }
    }



}