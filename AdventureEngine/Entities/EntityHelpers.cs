using AdventureEngine;
using AdventureEngine.Entities;
using System;
using System.Numerics;

namespace AdventureEngine.Scripts
{
    
    public static class EntityHelpers
    {
        public static T IsNotVisible<T>(this T entity) where T : Entity
        {
            entity.Visible = false;
            return entity;
        }

        public static T IsVisible<T>(this T entity) where T : Entity
        {
            entity.Visible = true;
            return entity;
        }

        public static Player CreatePlayer(this World world, string article, string name, string description = "")
        {
            var player = new Player() { Article = article, Name = name, Description = description };
            world.Player = player;
            return player;
        }

        public static Character CreateCharacter(this World world, string article, string name, string description = "")
        {
            var ch = new Character() { Article = article, Name = name, Description = description };
            return ch;
        }

        public static T SetProperty<T>(this T instance, string key, int value) where T : Entity
        {
            if (instance.Properties.ContainsKey(key))
            {
                instance.Properties[key] = value;
            }
            else
            {
                instance.Properties.Add(key, value);
            }

            return instance;
        }

        public static Room AddExit(this Room fromRoom, string direction, Room toRoom)
        {
            fromRoom.Exits.Add(direction, toRoom);

            return fromRoom;
        }

        public static T MoveCharacterToRoom<T>(this T ch, Room rm) where T : Character
        {
            if(ch.Room != null)
            {
                var oldRm = ch.Room;
                oldRm.Characters.Remove(ch);
            }

            ch.Room = rm;
            rm.Characters.Add(ch);

            return ch;
        }

        public static Room CreateRoom(this World world, string article, string name, string description = "")
        {
            var room = new Room() { Article = article, Name = name, Description = description };
            world.Rooms.Add(room);
            return room;
        }

        public static Room AddItemInRoom(this Room rm, Item itm)
        {
            rm.Items.Add(itm);
            itm.Room = rm;
            return rm;
        }

        public static T AddItemInInventory<T>(this T ch, Item itm) where T : Character
        {
            ch.Items.Add(itm);
            itm.Character = ch;
            return ch;
        }

        public static Character GetItem(this Character ch, Item itm)
        {
            var rm = ch.Room;
            
            rm.Items.Remove(itm);
            itm.Room = null;

            ch.Items.Add(itm);
            itm.Character = ch;

            return ch;
        }

        public static Character DropItem(this Character ch, Item itm)
        {
            var rm = ch.Room;

            ch.Items.Remove(itm);
            itm.Character = null;

            rm.Items.Add(itm);
            itm.Room = rm;

            return ch;
        }

        public static Item CreateItem(this World w, string article, string name, string description = "")
        {
            var itm = new Item() { 
                Article = article,
                Name = name,
                Description = description
            };

            w.Items.Add(itm);

            return itm;
        }

        public static T AddBehaviour<T>(this T item, string name) where T : Entity
        {
            item.Behaviours.Add(name);
            return item;
        }

        public static T AddBehaviours<T>(this T item, params string[] names) where T : Entity
        {
            foreach (var name in names)
            {
                item.Behaviours.Add(name);
            }

            return item;
        }

        public static Player AddCommand(this Player player, string name)
        {
            if (!player.Commands.Contains(name))
            {
                player.Commands.Add(name);
            }
            return player;
        }

        public static Player AddCommand(this Player player, params string[] names)
        {
            foreach(string name in names)
            {
                player.AddCommand(name);
            }
            
            return player;
        }

        public static Player AddCommands(this Player player, params string[] names)
        {
            foreach (var name in names)
            {
                player.AddCommand(name);
            }

            return player;
        }

        public static Player RemoveCommand(this Player player, string name)
        {
            if(player.Commands.Contains(name))
            {
                player.Commands.Remove(name);
            }

            return player;
        }
    }

}