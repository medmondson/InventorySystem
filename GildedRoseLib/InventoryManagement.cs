using System;
using GildedRoseLib.Model;
using System.Collections.Generic;
using System.Linq;
using GildedRoseLib.Access;

namespace GildedRoseLib
{
    public class InventoryManagement
    {
        private readonly int _maxQuality = 50;
        private readonly int _minQuality = 0;
        private readonly Lazy<IList<Item>> _items;
        public Lazy<IEnumerable<IInventory>> Inventories;
        public InventoryManagement()
        {
            _items = new Lazy<IList<Item>>(() => Repos.Items);
            Inventories = new Lazy<IEnumerable<IInventory>>(() => Repos.SampleInventories);
        }

        public void Adjust()
        {
            if (_items?.Value == null) throw new IndexOutOfRangeException("Items cannot be empty");
            if (Inventories?.Value == null) throw new IndexOutOfRangeException("Inventory list cannot be empty");
            foreach (var inventory in Inventories.Value)
            {
                var found = _items.Value.FirstOrDefault(i => i.GetType() == inventory.Item.GetType());
                if (found != null)
                {
                    (inventory.SellIn, inventory.Quality) = found.Calculate(inventory.SellIn, inventory.Quality);
                    if (inventory.Quality > _maxQuality) inventory.Quality = _maxQuality;
                    else if (inventory.Quality < _minQuality) inventory.Quality = _minQuality;
                }
                else
                {
                    inventory.Item.Error = "NO SUCH ITEM";
                    inventory.Quality = null;
                    inventory.SellIn = null;
                }
            }
        }  
    }
}
