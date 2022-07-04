using GildedRose.Abstractions;

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
            else if (item.SellIn <= 10 && item.SellIn > 5)
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
