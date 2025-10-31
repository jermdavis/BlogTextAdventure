using AdventureEngine;
using AdventureEngine.Scripts;

namespace ExampleTextAdventure.Example.Commands
{
    
    public class RingCommand : Command
    {
        public RingCommand() : base("ring", "ring <item> - make a doorbell go ding")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            var bellItem = world.Items.Where(i => i.Name == "doorbell").First();
            var match = InputParser.MatchEntity(bellItem, parameters[0]);

            if(!match)
            {
                world.Display($"You can't ring a {parameters[0]}");
                return;
            }

            world.Display("You can hear the sound of the bell behind the door.");
            world.Display("But after a wait, it's clear nobody is going to come and answer the door.");
        }
    }

}