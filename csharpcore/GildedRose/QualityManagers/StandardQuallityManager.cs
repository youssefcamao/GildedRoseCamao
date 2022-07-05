using GildedRose.Abstractions;
using System;

namespace GildedRose.QualityManagers
{
    public class StandardQuallityManager : QualityManagerBase
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
                updateMargin = -1;
            }
            else
            {
                updateMargin = -2;
            }
            UpdateWithMargins(item, updateMargin);
        }
    }
}
