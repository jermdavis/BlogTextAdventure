using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class HasLeftRoomAction : Action
    {
        public Room FromRoom => (Room)base.ParameterOne!;
        public Room ToRoom => (Room)base.ParameterTwo!;
        public Player Player => (Player)base.ParameterThree!;
        public string Direction => base.Data!;

        public HasLeftRoomAction(Room fromRoom, Room toRoom, Player player, string direction)
        {
            base.ParameterOne = fromRoom;
            base.ParameterTwo = toRoom;
            base.ParameterThree = player;
            base.Data = direction;
        }
    }



}