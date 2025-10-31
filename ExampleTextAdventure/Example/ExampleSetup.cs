using AdventureEngine;
using AdventureEngine.Scripts;

namespace ExampleTextAdventure.Example
{
    
    public static class ExampleSetup
    {
        public static World Initialise()
        {
            var world = new World();

            world
                .RegisterCommands(typeof(ExampleSetup).Assembly)
                .RegisterCommands(typeof(World).Assembly);

            world
                .RegisterBehaviours(typeof(ExampleSetup).Assembly)
                .RegisterBehaviours(typeof(World).Assembly);

            #region -- items --

            var cashItem = world
                .CreateItem("Some", "cash",
                    """"
                    A small wad of cash. There's about £10 in there.
                    """"
                );

            var taxiSignItem = world
                .CreateItem("A", "sign",
                    """"
                    It's a metal sign fixed to the garden wall. It says this is a pickup point for "Quick Cabs" - but you have to have booked in advance.
                    Guaranteed no more than £10 per trip! 
                    
                    They'd be ideal for taking you back to town, and avoiding that loooong walk.
                    Sadly the sign has been defaced. You can't read the phone number.
                    """"
                )
                .AddBehaviour("cantget");

            var statueItem = world
                .CreateItem("A", "statue",
                    """"
                    A marble knight. Very nicely carved.
                    """"
                )
                .AddBehaviour("cantget")
                .AddBehaviour("statue");

            var bushItem = world
                .CreateItem("A", "bush",
                    """"
                    When you wander up to the bush you see big waxy green leaves, and some bright red flowers.

                    But also there's a small path going past the bush with a compost heap behind it.
                    """"
                )
                .AddBehaviours("cantget", "behindbush");

            var flowerItem = world
                .CreateItem("A", "flower",
                    """"
                    One of the bright red flowers from the bush. It looks freshly picked.
                    """"
                );

            var matItem = world
                .CreateItem("A", "doormat",
                    """"
                    A pretty normal looking mat made of rubber and that coir stuff that's on the outside of a coconut. It says "Welcome" on it, but the whole porch isn't giving off a particular welcoming vibe.

                    The top right corner of the mat looks oddly worn and lumpy however...
                    """"
                )
                .AddBehaviours("doormat", "cantget");

            var keyItem = world
                .CreateItem("The", "key",
                    """"
                    A shiny brass front-door key. It's fairly unremarkable.
                    """"
                )
                .IsNotVisible();

            var bellItem = world
                .CreateItem("The", "doorbell",
                    """"
                    One of those modern doorbell buttons that's supposed to look like metal but is actiually plastic. It doesn't look like it's been used in a while.
                    """"
                )
                .AddBehaviour("cantget");

            var phoneItem = world
                .CreateItem("A", "phone",
                    """"
                    A very old looking rotary dial phone.
                    """"
                )
                .AddBehaviours("cantget", "phone");

            var clockItem = world
                .CreateItem("A", "clock",
                    """"
                    A tall grandfather clock. You can hear its mechanism ticking.
                    """"
                )
                .AddBehaviours("cantget", "clock");

            var cupItem = world
                .CreateItem("A", "cup",
                    """"
                    A plain white ceramic cup. It looks like it might have had tea in it at some point.
                    """"
                );

            var teaItem = world
                .CreateItem("A", "tea",
                    """"
                    It's a cup of tea. No milk mind, but strong builders' tea.
                    """"
                )
                .IsNotVisible();

            var taxiCardItem = world
                .CreateItem("A", "business card",
                    """"
                    A small business card for "Quick Cabs". It has a phone number on it.
                    That looks useful.
                    """"
                );


            var kettleItem = world
                .CreateItem("A", "kettle",
                    """"
                    An old electric kettle. It could do with the application of a bit of polish and de-scaler, but it appears functional.
                    And there's water in it. You could use this, if you had something to put the results in.
                    """"
                )
                .AddBehaviour("cantget");

            var ovenItem = world
                .CreateItem("An", "oven",
                    """"
                    A big old gas oven. It looks like it might still work. Not that there's anything to cook in here.
                    """"
                )
                .AddBehaviour("cantget");

            var fridgeItem = world
                .CreateItem("A", "fridge",
                    """"
                    A big old fridge. It's humming quiety, but the door doesn't look like it wants to open.
                    """"
                )
                .AddBehaviour("cantget");

            #endregion

            #region -- rooms--

            var gateRoom = world
                .CreateRoom("The", "garden gate",
                    """"
                    You're standing by an ornate iron gate. It's a bit old and showing some signs of rust, but it does seem to have been taken care of. And the blacksmith who made it certainly knew his stuff.

                    The gate sits in a a nicely built stone wall. There's a small sign fixed to it.

                    To the north is a winding garden path leading up towards am equally old looking cottage. Smoke curls gently from the chimney in the distance, and you can hear some birds singing from a nearby tree.

                    Behind you is the country lane you walked down to get here. You have no desire to go back that way on foot.
                    """"
                )
                .AddItemInRoom(taxiSignItem);

            var laneRoom = world
                .CreateRoom("A", "winding lane", 
                    """"
                    Miles of windy country lane snake off to the south. It took a very long time to walk up here. You have no desire to do that again.
                    """"
                );

            var taxiRoom = world
                .CreateRoom("A", "taxi", 
                    """"
                    Scuffed leather. Toyota Prius. It's a standard taxi, with a pretty standard driver.
                    """"
                )
                .IsNotVisible();

            var pathRoom = world
                .CreateRoom("The", "garden path",
                    """"
                    Flag stones in a winding path head east towards the cottage, past a statue. There's slightly messy lawn to one side of the path, with flowerbeds behind it.
                    And there's also a flowery looking shrubbery bush to the other side of the path.
                    """"
                )
                .AddItemInRoom(bushItem)
                .AddItemInRoom(statueItem);

            var compostRoom = world
                .CreateRoom("A", "compost heap",
                    """"
                    Surrounded by some old wooden pallets to keep it in a heap, there's a big pile of rotting garden waste here. It smells pretty bad.
                    You can see some worms wriggling in the heap, and there are some wasps buzzing about too.
                    """"
                )
                .AddItemInRoom(flowerItem)
                .IsNotVisible();

            var doorstepRoom = world
                .CreateRoom("The", "doorstep",
                    """"
                    The cottage looked quite quaint from a distance, but up close it's a bit more run down. There's peeling paint on the door and mud on the ground.
                    A pile of leaves have collected in the corner, and flutter about occasionally with gusts of wind.
                    """"
                )
                .AddBehaviours("bell", "frontdoorlock")
                .AddItemInRoom(matItem)
                .AddItemInRoom(keyItem)
                .AddItemInRoom(bellItem);

            var hallwayRoom = world
                .CreateRoom("The", "hallway",
                    """"
                    Inside it's dark and smells of old wood and dust. Stairs lead up towards the first floor, and the hall contunues towards the back of the house.
                    """"
                )
                .AddItemInRoom(phoneItem)
                .AddItemInRoom(clockItem);

            var bedRoom = world
                .CreateRoom("The", "bedroom",
                    """"
                    There's a theme of dingy rooms here. The bedroom contains an old brass bed, some very flower bedding, a wardrobe, and an old man in a chair who appears to only speak in those odd noises that farmers make.
                    """"
                );

            var kitchenRoom = world
                .CreateRoom("The", "kitchen",
                    """"
                    After the dark and musty hallway there's a similarly dark and musty kitchen. With a fridge, an oven and a kettle, it's clear someone is living here.
                    But it's still not an appealing place to cook. Some slightly odd looking teabags sit in a box on the counter. And by the sound of it there's a dog outside.
                    """"
                )
                .AddBehaviour("kitchen")
                .AddItemInRoom(kettleItem)
                .AddItemInRoom(fridgeItem)
                .AddItemInRoom(ovenItem)
                .AddItemInRoom(teaItem);

            var patioRoom = world
                .CreateRoom("The", "patio",
                    """"
                    It would be a lovely patio if it weren't for the dog. Nice stone flags. Plants in pots. A windchime.
                    But the dog looks angry...
                    """"
                );

            gateRoom
                .AddBehaviour("gatemovement")
                .AddExit("west", laneRoom)
                .AddExit("east", pathRoom)
                .AddExit("north", taxiRoom);

            pathRoom
                .AddExit("west", gateRoom)
                .AddExit("east", doorstepRoom)
                .AddExit("north", compostRoom);

            compostRoom
                .AddExit("south", pathRoom);

            doorstepRoom
                .AddExit("west", pathRoom)
                .AddExit("east", hallwayRoom);

            hallwayRoom
                .AddExit("west", doorstepRoom)
                .AddExit("up", bedRoom)
                .AddExit("east", kitchenRoom);

            bedRoom
                .AddExit("down", hallwayRoom);

            kitchenRoom
                .AddExit("west", hallwayRoom)
                .AddExit("east", patioRoom);

            #endregion

            #region -- characters --

            var oldManCharacter = world
                .CreateCharacter("An", "old man",
                    """"
                    You've no idea who he is, but the old man is sitting in his bedroom chair. Very much the pipe and slippers type, but he's from somewhere rural and has an entirely impenetrable accent.

                    He's nodded at you in greeting, and looks like he's expecting you to do something in return.
                    """"
                )
                .AddBehaviour("oldman")
                .MoveCharacterToRoom(bedRoom)
                .AddItemInInventory(cupItem)
                .AddItemInInventory(taxiCardItem);

            var taxiCharacter = world
                .CreateCharacter("A", "taxi driver",
                    """"
                    Barry the taxi driver has seen better days. His hair is a bit greasy, and his shirt is stained. But as long as he can drive back to town without ending up in a ditch then that's probably not too important.
                    """"
                )
                .AddBehaviour("taxidriver")
                .MoveCharacterToRoom(taxiRoom);

            #endregion

            var playerCharacter = world
                .CreatePlayer("The", "Hero", "It's you")
                .AddItemInInventory(cashItem)
                .MoveCharacterToRoom(gateRoom)
                .AddBehaviour("enterworld")
                .AddCommand(
                    "move", "look", "help", "inventory", "get",
                    "drop", "quit", "examine", "say", "give"
                );

            return world; 
        }
    }

}