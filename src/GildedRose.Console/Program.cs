using System.Collections.Generic;

namespace GildedRose.Console
{
    class Program
    {
        private static IList<Item> Items;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}

            };

            UpdateQuality();

            System.Console.ReadKey();

        }

        public static void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Sulfuras, Hand of Ragnaros": break;

                    case "Aged Brie":
                        UpdateAsAgedBrie(i);
                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateAsConcertPass(i);
                        break;

                    case "Conjured Mana Cake":
                        UpdateAsManaCake(i);
                        break;

                    default:
                        UpdateAsNormalItem(i);
                        break;
                }
            }
        }

        private static void UpdateAsNormalItem(int i)
        {
            if (Items[i].Quality > 0) Items[i].Quality--;

            Items[i].SellIn--;

            if (Items[i].SellIn < 0 && Items[i].Quality > 0) Items[i].Quality--;
        }

        private static void UpdateAsManaCake(int i)
        {
            if (Items[i].Quality > 0) Items[i].Quality -= 2;

            Items[i].SellIn--;

            if (Items[i].SellIn < 0 && Items[i].Quality > 0) Items[i].Quality -= 2;
        }

        private static void UpdateAsConcertPass(int i)
        {
            if (Items[i].Quality < 50)
            {
                Items[i].Quality++;

                if (Items[i].SellIn < 11 && Items[i].Quality < 50)
                {
                    Items[i].Quality++;
                }

                if (Items[i].SellIn < 6 && Items[i].Quality < 50)
                {
                    Items[i].Quality++;
                }
            }

            Items[i].SellIn--;

            if (Items[i].SellIn < 0) Items[i].Quality = 0;
        }

        private static void UpdateAsAgedBrie(int i)
        {
            if (Items[i].Quality < 50) Items[i].Quality++;

            Items[i].SellIn--;

            if (Items[i].SellIn < 0 && Items[i].Quality < 50) Items[i].Quality++;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
