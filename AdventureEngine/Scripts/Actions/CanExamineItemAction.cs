using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class CanExamineItemAction : Action
    {
        public Item Item => (Item)base.ParameterOne!;
        public Player Player => (Player)base.ParameterTwo!;

        public CanExamineItemAction(Item item, Player player)
        {
            base.ParameterOne = item;
            base.ParameterTwo = player;
        }
    }



}