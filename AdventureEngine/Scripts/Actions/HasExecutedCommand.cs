using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class HasExecutedCommand : Action
    {
        public Room Room => (Room)base.ParameterTwo!;
        public Player Player => (Player)base.ParameterOne!;
        public string Verb => base.Data!;

        public HasExecutedCommand(Player player, Room room, string verb) 
        {
            base.ParameterOne = player;
            base.ParameterTwo = room;
            base.Data = verb;
        }
    }

}