using Engine.Factories;
using Engine.Models;
using Engine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestEngine.Models
{
    [TestClass]
    public class TestInventory
    {
        [TestMethod]
        public void Test_Instantiate()
        {
            var inventory = new Inventory();

            Assert.AreEqual(0, inventory.Items.Count);
        }

        [TestMethod]
        public void Test_AddItem()
        {
            var inventory = new Inventory();

            var inventory1 = inventory.AddItemFromFactory(3001);

            Assert.AreEqual(1, inventory1.Items.Count);
        }

        [TestMethod]
        public void Test_AddItems()
        {
            var inventory = new Inventory();

            var itemsToAdd = new List<GameItem> {
                ItemFactory.CreateGameItem(3001),
                ItemFactory.CreateGameItem(3002)
            };

            var inventory1 = inventory.AddItems(itemsToAdd);

            Assert.AreEqual(2, inventory1.Items.Count);

            // Notice the used of chained AddItemFromFactory() calls
            var inventory2 = inventory1.AddItemFromFactory(3001)
                                       .AddItemFromFactory(3002);

            Assert.AreEqual(4, inventory2.Items.Count);
        }

        [TestMethod]
        public void Test_AddItemQuantities()
        {
            var inventory = new Inventory();

            var inventory1 = inventory.AddItems(new List<ItemQuantity> { new ItemQuantity(1001, 3) });

            Assert.AreEqual(3, inventory1.Items.Count(i => i.ItemTypeID == 1001));

            var inventory2 = inventory1.AddItemFromFactory(1001);

            Assert.AreEqual(4, inventory2.Items.Count(i => i.ItemTypeID == 1001));

            var inventory3 = inventory2.AddItems(new List<ItemQuantity> { new ItemQuantity(1002, 1) });

            Assert.AreEqual(4, inventory3.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(1, inventory3.Items.Count(i => i.ItemTypeID == 1002));
        }

        [TestMethod]
        public void Test_RemoveItem()
        {
            var inventory = new Inventory();

            var item1 = ItemFactory.CreateGameItem(3001);
            var item2 = ItemFactory.CreateGameItem(3002);

            var inventory1 = inventory.AddItems(new List<GameItem> { item1, item2 });

            var inventory2 = inventory1.RemoveItem(item1);

            Assert.AreEqual(1, inventory2.Items.Count);
        }

        [TestMethod]
        public void Test_RemoveItems()
        {
            var inventory = new Inventory();

            var item1 = ItemFactory.CreateGameItem(3001);
            var item2 = ItemFactory.CreateGameItem(3002);
            var item3 = ItemFactory.CreateGameItem(3002);

            var inventory1 = inventory.AddItems(new List<GameItem> { item1, item2, item3 });

            var inventory2 = inventory1.RemoveItems(new List<GameItem> { item2, item3 });

            Assert.AreEqual(1, inventory2.Items.Count);
        }

        [TestMethod]
        public void Test_CategorizedItemProperties()
        {
            // Initial empty inventory
            var inventory = new Inventory();

            Assert.AreEqual(0, inventory.Weapons.Count);
            Assert.AreEqual(0, inventory.Consumables.Count);

            // Add a pointy stick (weapon)
            var inventory1 = inventory.AddItemFromFactory(1001);

            Assert.AreEqual(1, inventory1.Weapons.Count);
            Assert.AreEqual(0, inventory1.Consumables.Count);

            // Add oats (NOT a consumable)
            var inventory2 = inventory1.AddItemFromFactory(3001);

            Assert.AreEqual(1, inventory2.Weapons.Count);
            Assert.AreEqual(0, inventory2.Consumables.Count);

            // Add a rusty sword (weapon)
            var inventory3 = inventory2.AddItemFromFactory(1002);

            Assert.AreEqual(2, inventory3.Weapons.Count);
            Assert.AreEqual(0, inventory3.Consumables.Count);

            // Add a granola bar (IS a consumable)
            var inventory4 = inventory3.AddItemFromFactory(2001);

            Assert.AreEqual(2, inventory4.Weapons.Count);
            Assert.AreEqual(1, inventory4.Consumables.Count);
        }

        [TestMethod]
        public void Test_RemoveItemQuantities()
        {
            // Initial empty inventory
            var inventory = new Inventory();

            Assert.AreEqual(0, inventory.Weapons.Count);
            Assert.AreEqual(0, inventory.Consumables.Count);

            var inventory2 = inventory.AddItemFromFactory(1001)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(3001)
                                      .AddItemFromFactory(3001);

            Assert.AreEqual(1, inventory2.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(4, inventory2.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory2.Items.Count(i => i.ItemTypeID == 3001));

            var inventory3 = inventory2.RemoveItems(new List<ItemQuantity> { new ItemQuantity(1002, 2) });

            Assert.AreEqual(1, inventory3.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(2, inventory3.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory3.Items.Count(i => i.ItemTypeID == 3001));

            var inventory4 = inventory3.RemoveItems(new List<ItemQuantity> { new ItemQuantity(1002, 1) });

            Assert.AreEqual(1, inventory4.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(1, inventory4.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory4.Items.Count(i => i.ItemTypeID == 3001));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Test_RemoveItemQuantities_RemoveTooMany()
        {
            // Initial empty inventory
            var inventory = new Inventory();

            Assert.AreEqual(0, inventory.Weapons.Count);
            Assert.AreEqual(0, inventory.Consumables.Count);

            var inventory2 = inventory.AddItemFromFactory(1001)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(1002)
                                      .AddItemFromFactory(3001)
                                      .AddItemFromFactory(3001);

            Assert.AreEqual(1, inventory2.Items.Count(i => i.ItemTypeID == 1001));
            Assert.AreEqual(4, inventory2.Items.Count(i => i.ItemTypeID == 1002));
            Assert.AreEqual(2, inventory2.Items.Count(i => i.ItemTypeID == 3001));

            // Should throw an exception,
            // since we are trying to remove more items than exist in the inventory.
            var inventory3 = inventory2.RemoveItems(new List<ItemQuantity> { new ItemQuantity(1002, 999) });
        }
    }
}
