using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class CanUseItemAction : Action
    {
        public Character Character => (Character)base.ParameterOne!;
        public Item Item => (Item)base.ParameterTwo!;

        public CanUseItemAction(Character ch, Item item)
        {
            base.ParameterOne = ch;
            base.ParameterTwo = item;
        }
    }

}