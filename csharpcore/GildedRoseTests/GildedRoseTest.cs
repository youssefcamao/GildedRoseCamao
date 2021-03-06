using GildedRose;
using GildedRose.Abstractions;
using GildedRose.QualityManagers;
using System;
using System.Collections.Generic;
using Xunit;
using gr = GildedRose;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        private readonly Dictionary<string, IQualityManager> _qualityItemsDefinition = new Dictionary<string, IQualityManager>();
        public GildedRoseTest()
        {
            InitializeQualityItemsDefinition();
        }
        private void InitializeQualityItemsDefinition()
        {
            _qualityItemsDefinition.Add("Aged Brie", new AgedBrieQualityManager());
            _qualityItemsDefinition.Add("Sulfuras, Hand of Ragnaros", new SulfurasQualityManager());
            _qualityItemsDefinition.Add("Backstage passes to a TAFKAL80ETC concert", new BackStageQualityManager());
            _qualityItemsDefinition.Add("Conjured Mana Cake", new ConjuredQualityManager());
        }
        [Fact]
        public void GildedRose_QualityNotNegative_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
            app.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }
        [Fact]
        public void GildedRose_QualityMax50_NormalCase_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 } };
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
            app.UpdateQuality();
            Assert.Equal(50, Items[0].Quality);
        }
        [Fact]
        public void GildedRose_AgedBrie_Increase_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 20 },
            new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 }};
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
            app.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(21, Items[0].Quality);
            Assert.Equal(-1, Items[1].SellIn);
            Assert.Equal(22, Items[1].Quality);
        }
        [Fact]
        public void GildedRose_NormalCase_Decrease_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 12 },
            new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 12 }};
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
            app.UpdateQuality();
            Assert.Equal(9, Items[0].SellIn);
            Assert.Equal(11, Items[0].Quality);
            Assert.Equal(-1, Items[1].SellIn);
            Assert.Equal(10, Items[1].Quality);
        }
        [Fact]
        public void GildedRose_NormalCaseIfSealInExpired_DoubleDecrease_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 12 } };
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
            app.UpdateQuality();
            Assert.Equal(10, Items[0].Quality);
            Assert.Equal(-2, Items[0].SellIn);
        }
        [Fact]
        public void GildedRose_Sulfuras_NotChanged_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
            app.UpdateQuality();
            Assert.Equal(80, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(80, Items[1].Quality);
            Assert.Equal(-1, Items[1].SellIn);
        }
        [Fact]
        public void GildedRose_BackStagePasses_UpdateQuality_Successful()
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
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 50
                }};
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
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
            //Keeps the same quality
            Assert.Equal(50, Items[4].Quality);
            Assert.Equal(9, Items[4].SellIn);
            // Drop to 0
            Assert.Equal(0, Items[3].Quality);
            Assert.Equal(-1, Items[3].SellIn);
        }
        [Fact]
        public void GildedRose_Conjured_DoubleDecrease_Successful()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 },
             new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 1 },
            new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 }};
            var app = new gr.GildedRose(Items, _qualityItemsDefinition, new StandardQuallityManager());
            app.UpdateQuality();
            Assert.Equal(2, Items[0].SellIn);
            Assert.Equal(4, Items[0].Quality);
            //check if quality is not negative
            Assert.Equal(2, Items[1].SellIn);
            Assert.Equal(0, Items[1].Quality);
            // check if it gets decreased by 4 after sell in date
            Assert.Equal(-1, Items[2].SellIn);
            Assert.Equal(6, Items[2].Quality);
        }
        [Fact]
        public void GildedRose_ShouldThrow_ArgumentNullException_Successful()
        {
            var sulfurasQualityManager = new SulfurasQualityManager();
            var agedBrieQualityManager = new AgedBrieQualityManager();
            var backStageQualityManager = new BackStageQualityManager();
            var conjuredQualityManager = new ConjuredQualityManager();
            var standardQualityManager = new StandardQuallityManager();

            Assert.Throws<ArgumentNullException>(() => sulfurasQualityManager.UpdateQuality(null));
            Assert.Throws<ArgumentNullException>(() => agedBrieQualityManager.UpdateQuality(null));
            Assert.Throws<ArgumentNullException>(() => backStageQualityManager.UpdateQuality(null));
            Assert.Throws<ArgumentNullException>(() => conjuredQualityManager.UpdateQuality(null));
            Assert.Throws<ArgumentNullException>(() => standardQualityManager.UpdateQuality(null));
        }
    }
}
