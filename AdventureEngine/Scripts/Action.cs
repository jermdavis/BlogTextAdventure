using AdventureEngine.Entities;

namespace AdventureEngine.Scripts
{
    
    public abstract class Action
    {
        protected Entity? ParameterOne;
        protected Entity? ParameterTwo;
        protected Entity? ParameterThree;
        protected Entity? ParameterFour;
        protected string? Data;
    }

}