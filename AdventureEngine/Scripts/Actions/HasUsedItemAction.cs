using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class HasUsedItemAction : Action
    {
        public Character Character => (Character)base.ParameterOne!;
        public Item Item => (Item)base.ParameterTwo!;

        public HasUsedItemAction(Character ch, Item item)
        {
            base.ParameterOne = ch;
            base.ParameterTwo = item;
        }
    }

}