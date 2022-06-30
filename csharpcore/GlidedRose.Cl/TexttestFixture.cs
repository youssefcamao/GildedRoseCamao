
using GildedRoseKata;
using gr = GildedRoseKata;
using System;
using System.Collections.Generic;
using GildedRose.Abstractions;
using GildedRose.QualityManagers;

namespace GlidedRose.Cl
{
    public static class TexttestFixture
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            Dictionary<string, Func<Item, IQualityManager>> qualityItemsDefinition = new Dictionary<string, Func<Item, IQualityManager>>();
            qualityItemsDefinition.Add("Aged Brie", (x) => new AgedBrieQualityManager(x));
            qualityItemsDefinition.Add("+5 Dexterity Vest", (x) => new StandardQuallityManager(x));
            qualityItemsDefinition.Add("Sulfuras, Hand of Ragnaros", (x) => new SulfurasQualityManager(x));
            qualityItemsDefinition.Add("Backstage passes to a TAFKAL80ETC concert", (x) => new BackStageQualityManager(x));
            qualityItemsDefinition.Add("Elixir of the Mongoose", (x) => new StandardQuallityManager(x));
            qualityItemsDefinition.Add("Conjured Mana Cake", (x) => new ConjuredQualityManager(x));
            
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item is now implemented
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new gr.GildedRose(Items, qualityItemsDefinition);

            int days = 30;
            if (args.Length > 0)
            {
                days = int.Parse(args[0]) + 1;
            }

            for (var i = 0; i <= days; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
