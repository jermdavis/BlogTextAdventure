using AdventureEngine;
using AdventureEngine.Entities;
using AdventureEngine.Scripts;
using AdventureEngine.Scripts.Actions;
using AdventureEngine.Scripts.Commands;

namespace ExampleTextAdventure.Example.Behaviours
{
    
    public class OldManBehaviour : Behaviour
    {
        public OldManBehaviour() : base("oldman")
        {
        }
        public override bool Execute(Entity owner, World world, AdventureEngine.Scripts.Action action)
        {
            // enter room reaction
            if(action is HasEnteredRoomAction her)
            {
                world.Display("The old man mumbles a greeting as you enter.");
                return true;
            }

            // hello reaction
            if(action is HasSaidAction hsa)
            {
                world.Display("In response, the old man mumbles something incomprehensible.");

                if (hsa.Message.StartsWith("hello", StringComparison.OrdinalIgnoreCase) ||
                    hsa.Message.StartsWith("hi", StringComparison.OrdinalIgnoreCase))
                {
                    var man = (Character)owner;
                    var cup = InputParser.MatchEntities(man.Items, "cup");

                    if (cup == null)
                    {
                        world.Display("His mumbling includes something that looks like a mime of drinking from a cup.");
                    }
                    else
                    {
                        world.Display("As he mumbles, he also hands you a cup. You think you make out the word 'tea' when he speaks.");
                        man.Items.Remove(cup);
                        world.Player.Items.Add(cup);
                        cup.Character = world.Player;
                    }

                    return true;
                }
            }

            // given tea - provide taxi card reaction
            if (action is HasGivenItemAction hga)
            {
                if(hga.ToCharacter == owner && hga.Item.Name.ToLower() == "tea")
                {
                    var man = (Character)owner;

                    world.Display("Yet more mumbling greets you handing over the tea.");
                    world.Display("And it's followed by further excited mumbling as he presents you with a taxi card.");
                    world.Display("You could call a taxi with that! Now, where did you see a phone?");

                    var card = InputParser.MatchEntities(man.Items, "business card");

                    if (card != null)
                    {
                        man.Items.Remove(card);
                        world.Player.Items.Add(card);
                        card.Character = world.Player;
                    }

                    return true;
                }
            }

            return true;
        }
    }

}