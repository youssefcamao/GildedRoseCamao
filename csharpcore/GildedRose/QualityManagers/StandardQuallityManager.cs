using GildedRose.Abstractions;
using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.QualityManagers
{
    public class StandardQuallityManager : QualityManagerBase
    {
        public override void UpdateQuality(Item item)
        {
            if (item.SellIn >= 0)
            {
                UpdateQualityMargin = -1;
            }
            else
            {
                UpdateQualityMargin = -2;
            }
            UpdateWithMargings(item);
        }
    }
}
