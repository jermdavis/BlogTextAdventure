using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class HasEnteredWorld : Action
    {
        public Room Room => (Room)base.ParameterOne!;
        public Player Player => (Player)base.ParameterTwo!;

        public HasEnteredWorld(Room room, Player player)
        {
            base.ParameterOne = room;
            base.ParameterTwo = player;
        }
    }

}