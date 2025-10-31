using AdventureEngine.Scripts.Actions;

namespace AdventureEngine.Scripts.Commands
{

    public class GiveCommand : Command
    {
        public GiveCommand() : base("give", "give <character> <inventory item> - hand something from your inventory to someone else")
        {
        }

        public override void Execute(World world, string[] parameters)
        {
            if (parameters.Length <= 1)
            {
                world.Display("Give what to whom?");
                return;
            }

            var charName = parameters[0];
            var itemName = parameters[1];

            var character = InputParser.MatchEntities(world.Player.Room.Characters, charName);
            var item = InputParser.MatchEntities(world.Player.Items, itemName);

            if (character == null && item == null)
            {
                // check if user swapped positions?
                character = InputParser.MatchEntities(world.Player.Room.Characters, itemName);
                item = InputParser.MatchEntities(world.Player.Items, charName);
            }

            if (character == null)
            {
                world.Display($"{charName} isn't here.");
                return;
            }

            if (item == null)
            {
                world.Display($"You're not carrying {itemName}");
                return;
            }

            var canGive = new CanGiveItemAction(character, item, world.Player);

            if (VerifyCommand(world.Player.Room, world, canGive) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player, world, canGive) == false)
            {
                return;
            }
            if (VerifyCommand(item, world, canGive) == false)
            {
                return;
            }
            if (VerifyCommand(world.Player.Room.Characters, world, canGive) == false)
            {
                return;
            }

            world.Player.Items.Remove(item);
            item.Character = character;
            character.Items.Add(item);

            var hasGiven = new HasGivenItemAction(character, item, world.Player);

            VerifyCommand(world.Player.Room, world, hasGiven);
            VerifyCommand(world.Player, world, hasGiven);
            VerifyCommand(item, world, hasGiven);
            VerifyCommand(world.Player.Room.Characters, world, hasGiven);            
        }
    }

}