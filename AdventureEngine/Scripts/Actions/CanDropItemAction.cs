using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{

    public class CanDropItemAction : Action
    {
        public Room Room => (Room)base.ParameterOne!;
        public Item Item => (Item)base.ParameterTwo!;
        public Player Player => (Player)base.ParameterThree!;

        public CanDropItemAction(Room room, Item item, Player player)
        {
            base.ParameterOne = room;
            base.ParameterTwo = item;
            base.ParameterThree = player;
        }
    }

}