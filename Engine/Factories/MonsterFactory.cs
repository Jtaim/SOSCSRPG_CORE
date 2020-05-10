﻿using System;
using Engine.Models;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            switch(monsterID) {
                case 1:
                    var snake = new Monster("Snake", "Snake.png", 4, 4, 1, 2, 5, 1);

                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);

                    return snake;

                case 2:
                    var rat = new Monster("Rat", "Rat.png", 5, 5, 1, 2, 5, 1);

                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);

                    return rat;

                case 3:
                    var giantSpider = new Monster("Giant Spider", "GiantSpider.png", 10, 10, 1, 4, 10, 3);

                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 75);

                    return giantSpider;

                default:
                    throw new ArgumentException($"MonsterType '{monsterID}' does not exist");
            }
        }

        private static void AddLootItem(Monster monster, int itemID, int percentage)
        {
            if(RandomNumberGenerator.NumberBetween(1, 100) <= percentage) {
                monster.AddItemToInventory(ItemFactory.CreateGameItem(itemID));
            }
        }
    }
}
