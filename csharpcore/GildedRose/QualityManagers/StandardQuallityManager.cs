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
        public StandardQuallityManager(Item item) : base(item)
        {

        }
        public override void UpdateQuality()
        {
            if (Item.SellIn >= 0)
            {
                UpdateQualityMargin = -1;
            }
            else
            {
                UpdateQualityMargin = -2;
            }
            UpdateWithQualityMarging();
        }
    }
}
