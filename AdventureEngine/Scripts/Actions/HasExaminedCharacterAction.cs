using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    public class HasExaminedCharacterAction : Action
    {
        public Character Character => (Character)base.ParameterOne!;
        public Player Player => (Player)base.ParameterTwo!;

        public HasExaminedCharacterAction(Character character, Player player)
        {
            base.ParameterOne = character;
            base.ParameterTwo = player;
        }
    }

}