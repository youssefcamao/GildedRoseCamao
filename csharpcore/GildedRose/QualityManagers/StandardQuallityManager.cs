using GildedRose.Abstractions;

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
