namespace GildedRoseLib.Model
{
    public interface IInventory
    {
        Item Item { get; set; }
        int? SellIn { get; set; }
        int? Quality { get; set; }
    }

    public class Inventory : IInventory
    {
        public Item Item { get; set; }
        public int? SellIn { get; set; }
        public int? Quality { get; set; }
    } 
}
