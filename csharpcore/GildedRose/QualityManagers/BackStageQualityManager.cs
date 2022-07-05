using GildedRose.Abstractions;
using System;

namespace GildedRose.QualityManagers
{
    public class BackStageQualityManager : QualityManagerBase
    {
        public override void UpdateQuality(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            int updateMargin;
            if (item.SellIn > 10)
            {
                updateMargin = 1;
            }
            else if (item.SellIn <= 10 && item.SellIn > 5)
            {
                updateMargin = 2;
            }
            else if (item.SellIn <= 5 && item.SellIn > 0)
            {
                updateMargin = 3;
            }
            else
            {
                item.Quality = 0;
                updateMargin = 0;
            }
            UpdateWithMargins(item, updateMargin);
        }
    }
}
