using System;
using GildedRoseLib;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using GildedRoseLib.Access;
using GildedRoseLib.Model;
using Assert = NUnit.Framework.Assert;

namespace GildedRoseTest
{
    [TestFixture]
    public class Test1
    {
        [Test]
        public void Normal_Item_Before_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
                {
                    return new List<IInventory>()
                    {
                        new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Normal)), SellIn = 2, Quality = 2}

                    };
                });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 1);
            Assert.AreEqual(inventory.SellIn, 1);
        }

        [Test]
        public void Normal_Item_After_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Normal)), SellIn = -1, Quality = 5}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 3);
            Assert.AreEqual(inventory.SellIn, -2);
        }

        [Test]
        public void Normal_Item_After_SellIn_Date_While_Negative_Quality()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Normal)), SellIn = -1, Quality = -4}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 0);
            Assert.AreEqual(inventory.SellIn, -2);
        }


        [Test]
        public void Legendary_Item_Before_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Legendary)), SellIn = 2, Quality = 5}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 5);
            Assert.AreEqual(inventory.SellIn, 2);
        }

        [Test]
        public void Legendary_Item_After_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Legendary)), SellIn = -2, Quality = 5}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 5);
            Assert.AreNotEqual(inventory.SellIn, 2);
        }

        [Test]
        public void BackStagePass_Item_Before_SellIn_Date_Greater_10()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Pass)), SellIn = 12, Quality = 5}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 6);
            Assert.AreEqual(inventory.SellIn, 11);
        }

        [Test]
        public void BackStagePass_Item_Before_SellIn_Date_On_10()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Pass)), SellIn = 11, Quality = 5}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 7);
            Assert.AreEqual(inventory.SellIn, 10);
        }

        [Test]
        public void BackStagePass_Item_Before_SellIn_Date_Less_10()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Pass)), SellIn = 10, Quality = 22}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 24);
            Assert.AreEqual(inventory.SellIn, 9);
        }

        [Test]
        public void BackStagePass_Item_Before_SellIn_Date_Less_5()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Pass)), SellIn = 4, Quality = 16}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 19);
            Assert.AreEqual(inventory.SellIn, 3);
        }

        [Test]
        public void BackStagePass_Item_After_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Pass)), SellIn = -3, Quality =14}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 0);
            Assert.AreEqual(inventory.SellIn, -4);
        }

        [Test]
        public void Conjured_Item_Before_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Conjured)), SellIn = 3, Quality = 8}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 6);
            Assert.AreEqual(inventory.SellIn, 2);
        }

        [Test]
        public void Conjured_Item_After_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(Conjured)), SellIn = -3, Quality = 9}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 5);
            Assert.AreEqual(inventory.SellIn, -4);
        }

        [Test]
        public void AgedBre_Item_Before_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(AgedBrie)), SellIn = 6, Quality = 7}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 8);
            Assert.AreEqual(inventory.SellIn, 5);
        }

        [Test]
        public void AgedBre_Item_After_SellIn_Date()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = new Lazy<IEnumerable<IInventory>>(() =>
            {
                return new List<IInventory>()
                {
                    new Inventory() {Item = Repos.Items.FirstOrDefault(i => i.GetType() == typeof(AgedBrie)), SellIn = -4, Quality = 7}

                };
            });
            inventoryManagement.Adjust();
            var inventory = inventoryManagement.Inventories.Value.ElementAt(0);
            Assert.AreEqual(inventory.Quality, 8);
            Assert.AreEqual(inventory.SellIn, -5);
        }

        [Test]
        public void Exception_While_No_Inventory_Available()
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.Inventories = null;
            Assert.Throws<IndexOutOfRangeException>(inventoryManagement.Adjust);
        }
    }
}
