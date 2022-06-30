using GildedRose.Abstractions;
using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.QualityManagers
{
    public class BackStageQualityManager : QualityManagerBase
    {
        public BackStageQualityManager(Item item) : base(item)
        {

        }
        public override void UpdateQuality()
        {
            if (Item.SellIn > 10)
            {
                UpdateQualityMargin = 1;
            }
            else if(Item.SellIn <= 10 && Item.SellIn > 5)
            {
                UpdateQualityMargin = 2;
            }
            else if (Item.SellIn <= 5 && Item.SellIn > 0)
            {
                UpdateQualityMargin = 3;
            }
            else
            {
                Quality = 0;
            }
            UpdateWithQualityMarging();
        }
    }
}
