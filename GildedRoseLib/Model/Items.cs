namespace GildedRoseLib.Model
{
    public abstract class Item
    {
        public string Name { get; }
        public virtual int Changer { get; } = -1;
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
        public override int Changer { get; } = -1;
        public Normal(string name) : base(name) { }
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            if (sellIn < 0)
                return (sellIn, quality += (2 * Changer));
            return (sellIn, quality += Changer);
        }
    }

    public class Legendary : Item
    {
        public override int Changer { get; } = 0;
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
                return (sellIn, quality += (4 * Changer));
            return (sellIn, quality += (2 * Changer));
        }
    }

    public class AgedBrie : Item
    {
        public AgedBrie(string name) : base(name) { }
        public override int Changer { get; } = 1;
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            return (sellIn, quality += Changer);
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
                return (sellIn, quality += (3 * Changer));
            if (sellIn <= 10)
                return (sellIn, quality += (2 * Changer));
            return (sellIn, quality += Changer);
        }
    }

    public class NewItem : Item
    {
        public NewItem(string name) : base(name) { }
        public override (int?, int?) Calculate(int? sellIn, int? quality)
        {
            DecreaseSellIn(ref sellIn);
            if (sellIn < 0)
                return (sellIn, quality += (2 * Changer));
            return (sellIn, quality += Changer);
        }
    }
}
