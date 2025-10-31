using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    
    public class CanSayAction : Action
    {
        public Character Speaker => (Character)base.ParameterOne!;
        public string Message => base.Data!;

        public CanSayAction(Character ch, string message)
        {
            base.ParameterOne = ch;
            base.Data = message;
        }
    }

}