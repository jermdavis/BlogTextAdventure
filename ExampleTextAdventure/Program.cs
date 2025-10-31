using AdventureEngine;

namespace ExampleTextAdventure
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var runner = new GameRunner();
            runner.Run(ExampleTextAdventure.Example.ExampleSetup.Initialise);
        }
    }

}