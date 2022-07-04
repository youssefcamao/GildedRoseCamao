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
        public override void UpdateQuality(Item item)
        {
            if (item.SellIn > 10)
            {
                UpdateQualityMargin = 1;
            }
            else if(item.SellIn <= 10 && item.SellIn > 5)
            {
                UpdateQualityMargin = 2;
            }
            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                UpdateQualityMargin = 3;
            }
            else
            {
                item.Quality = 0;
                UpdateQualityMargin = 0;
            }
            UpdateWithMargings(item);
        }
    }
}
