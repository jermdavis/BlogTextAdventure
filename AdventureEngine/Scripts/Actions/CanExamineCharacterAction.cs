using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class CanExamineCharacterAction : Action
    {
        public Character Character => (Character)base.ParameterOne!;
        public Player Player => (Player)base.ParameterTwo!;

        public CanExamineCharacterAction(Character character, Player player)
        {
            base.ParameterOne = character;
            base.ParameterTwo = player;
        }
    }

}