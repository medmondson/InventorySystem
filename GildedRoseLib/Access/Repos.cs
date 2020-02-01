using GildedRoseLib.Model;
using System.Collections.Generic;

namespace GildedRoseLib.Access
{
    public class Repos
    {
        //items list with names.
        public static IList<Item> Items = new List<Item>()
            {
                new AgedBrie("Aged Brie"),
                new BackstagePass("Backstage passes"),
                new Sulfuras("Sulfuras"),
                new Normal("Normal Item"),
                new Conjured("Conjured")
            };

        //sample inventory list
        public static IList<IInventory> SampleInventories = new List<IInventory>()
        {
            new Inventory(){Item = Items[0],SellIn = 1,Quality = 1, },
            new Inventory(){Item = Items[1],SellIn = -1,Quality = 2},
            new Inventory(){Item = Items[1],SellIn = 9,Quality = 2},
            new Inventory(){Item = Items[2],SellIn = 2,Quality = 2},
            new Inventory(){Item = Items[3],SellIn = -1,Quality = 55},
            new Inventory(){Item = Items[3],SellIn = 2,Quality = 2},
            new Inventory(){Item = new NewItem("INVALID ITEM") , SellIn = 2,Quality = 2},
            new Inventory(){Item = Items[4],SellIn = 2,Quality = 2},
            new Inventory(){Item = Items[4],SellIn = -1,Quality = 5}
        };
    }
}
