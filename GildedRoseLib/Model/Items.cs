namespace GildedRoseLib.Model
{
    public abstract class Item
    {
        public string Name { get; }
        public virtual int By { get; } = -1;
        public string Error { get; set; }
        public abstract (int?, int?) Calculate(int? sellIn, int? quality);
        protected Item(string name)
        {
            Name = name;
        }
        protected int? DecreaseSellIn(ref int? sellIn) { return sellIn--; }
    }

    public class Normal : Item
    {
        public override int By { get; } = -1;
        public Normal(string name) : base(name) { }
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            if (sellIn < 0)
                return (sellIn, quality += (2 * By));
            return (sellIn, quality += By);
        }
    }

    public class Legendary : Item
    {
        public override int By { get; } = 0;
        public Legendary(string name) : base(name) { }
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            return (sellIn, quality);
        }
    }

    public class Conjured : Normal
    {
        public Conjured(string name) : base(name) { }
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            if (sellIn < 0)
                return (sellIn, quality += (4 * By));
            return (sellIn, quality += (2 * By));
        }
    }

    public class AgedBrie : Item
    {
        public AgedBrie(string name) : base(name) { }
        public override int By { get; } = 1;
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            return (sellIn, quality += By);
        }
    }

    public class Pass : AgedBrie
    {
        public Pass(string name) : base(name) { }
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            if (sellIn < 0)
                return (sellIn, 0);
            if (sellIn <= 5)
                return (sellIn, quality += (3 * By));
            if (sellIn <= 10)
                return (sellIn, quality += (2 * By));
            return (sellIn, quality += By);
        }
    }

    public class NewItem : Item
    {
        public NewItem(string name) : base(name) { }
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            if (sellIn < 0)
                return (sellIn, quality += (2 * By));
            return (sellIn, quality += By);
        }
    }
}
