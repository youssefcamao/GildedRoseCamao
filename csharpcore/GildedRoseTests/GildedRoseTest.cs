using Xunit;
using System.Collections.Generic;
using gr = GildedRoseKata;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void GlidedRose_QualityNotNegative_Successful()
        {
            IList<Item> Items = new List<Item> { new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0}};
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void GlidedRose_QualityMax50_NormalCase_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }
        [Fact]
        public void GlidedRose_AgedBrie_Increase_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 20 } };
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(21, Items[0].Quality);
        }
        [Fact]
        public void GlidedRose_NormalCase_Decrease_Successful()
        {
            IList<Item> Items = new List<Item> {new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 12 }};
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
        }
        [Fact]
        public void GlidedRose_NormalCaseIfSealInExpired_DoubleDecrease_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 12 } };
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(10, Items[0].Quality);
            Assert.Equal(-2, Items[0].SellIn);
        }
        [Fact]
        public void GlidedRose_Sulfuras_NotChanged_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(80, Items[1].Quality);
            Assert.Equal(-1, Items[1].SellIn);
        }
        [Fact]
        public void GlidedRose_BackStagePasses_UpdateQuality_Successful()
        {
            IList<Item> Items = new List<Item> 
            { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 45
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 45
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 22
                }};
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            // Normal Increase
            Assert.Equal(21, Items[0].Quality);
            Assert.Equal(14, Items[0].SellIn);

            // Increase by 2
            Assert.Equal(47, Items[1].Quality);
            Assert.Equal(9, Items[1].SellIn);

            // Increase by 3
            Assert.Equal(48, Items[2].Quality);
            Assert.Equal(4, Items[2].SellIn);

            // Drop to 0
            Assert.Equal(0, Items[3].Quality);
            Assert.Equal(-1, Items[3].SellIn);
        }
        [Fact]
        public void GlidedRose_Conjured_DoubleDecrease_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            var app = new gr.GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality);
        }
    }
}
