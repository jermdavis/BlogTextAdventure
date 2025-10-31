using AdventureEngine.Entities;

namespace AdventureEngine.Scripts.Actions
{
    
    public class HasSaidAction : Action
    {
        public Character Speaker => (Character)base.ParameterOne!;
        public string Message => base.Data!;

        public HasSaidAction(Character ch, string message)
        {
            base.ParameterOne = ch;
            base.Data = message;
        }
    }

}