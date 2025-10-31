using AdventureEngine.Entities;
using AdventureEngine.Scripts.Actions;

namespace AdventureEngine.Scripts.Commands
{

    public class ExamineCommand : Command
    {
        public ExamineCommand() : base("examine", "examine <entity> - take a look at something in the room or your pocket")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            if (parameters.Length == 0) 
            {
                world.Display($"Examine what?");
                return;
            }

            var thing = parameters[0];
            var player = world.Player;

            var character = InputParser.MatchEntities(world.Player.Room.Characters, thing);
            if(character != null)
            {
                var exCharacter = new CanExamineCharacterAction(character, world.Player);
                if (VerifyCommand(character, world, exCharacter))
                {
                    world.Display($"{character.Article} {character.Name}");
                    world.Display(character.Description);

                    var hasExCharacter = new HasExaminedCharacterAction(character, world.Player);
                    VerifyCommand(character, world, hasExCharacter);
                }
                return;
            }

            var item = InputParser.MatchEntities(player.Room.Items, thing);
            if(item != null) 
            {
                var exItem = new CanExamineItemAction(item, world.Player);
                if (VerifyCommand(item, world, exItem))
                {
                    world.Display($"{item.Article} {item.Name}");
                    world.Display(item.Description);

                    var hasExItem = new HasExaminedItemAction(item, world.Player);
                    VerifyCommand(item, world, hasExItem);
                }
                return;
            }

            item = InputParser.MatchEntities(player.Items, thing);
            if(item != null)
            {
                var exItem = new CanExamineItemAction(item, world.Player);
                if (VerifyCommand(item, world, exItem))
                {
                    world.Display($"{item.Article} {item.Name}");
                    world.Display(item.Description);

                    var hasExItem = new HasExaminedItemAction(item, world.Player);
                    VerifyCommand(item, world, hasExItem);
                }
                return;
            }

            var exit = InputParser.MatchExit(world.Player.Room.Exits, thing);
            if(exit != null)
            {
                var ex = exit.Value;
                var exRoom = new CanExamineExitAction(world.Player.Room, ex.Value, world.Player, ex.Key);
                if (VerifyCommand(ex.Value, world, exRoom))
                {
                    world.Display($"To the {ex.Key} is {ex.Value.Name}");
                    world.Display(ex.Value.Description);

                    var hasExRoom = new HasExaminedExitAction(world.Player.Room, ex.Value, world.Player, ex.Key);
                    VerifyCommand(ex.Value, world, hasExRoom);
                }
                return;
            }

            world.Display($"There's no {thing} to examine.");
        }
    }

}