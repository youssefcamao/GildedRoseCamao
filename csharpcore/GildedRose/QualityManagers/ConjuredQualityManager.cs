using GildedRose.Abstractions;
using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.QualityManagers
{
    public class ConjuredQualityManager : QualityManagerBase
    {
        public ConjuredQualityManager(Item item) : base(item)
        {

        }
        public override void UpdateQuality()
        {
            if (Item.SellIn >= 0)
            {
                UpdateQualityMargin = -2;
            }
            else
            {
                UpdateQualityMargin = -4;
            }
            UpdateWithQualityMarging();
        }
    }
}
