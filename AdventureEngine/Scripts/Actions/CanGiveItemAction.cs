using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    
    public class CanGiveItemAction : Action
    {
        public Character ToCharacter => (Character)base.ParameterOne!;
        public Item Item => (Item)base.ParameterTwo!;
        public Player FromPlayer => (Player)base.ParameterThree!;

        public CanGiveItemAction(Character ch, Item item, Player player)
        {
            base.ParameterOne = ch;
            base.ParameterTwo = item;
            base.ParameterThree = player;
        }
    }

}