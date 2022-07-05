using GildedRose.Abstractions;
using System;

namespace GildedRose.QualityManagers
{
    public class ConjuredQualityManager : QualityManagerBase
    {
        public override void UpdateQuality(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            int updateMargin;
            if (item.SellIn > 0)
            {
                updateMargin = -2;
            }
            else
            {
                updateMargin = -4;
            }
            UpdateWithMargins(item, updateMargin);
        }
    }
}
