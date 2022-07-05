using GildedRose.Abstractions;
using System;

namespace GildedRose.QualityManagers
{
    public class SulfurasQualityManager : QualityManagerBase
    {
        protected override int MaxQuality => 80;
        public override void UpdateQuality(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            UpdateWithMargins(item, 0, 0);
        }
    }
}
