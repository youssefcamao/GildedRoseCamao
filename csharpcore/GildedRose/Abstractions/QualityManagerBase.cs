namespace GildedRose.Abstractions
{
    public abstract class QualityManagerBase : IQualityManager
    {
        protected virtual int MaxQuality { get; } = 50;
        public abstract void UpdateQuality(Item item);
        protected void UpdateWithMargins(Item item, int qualityMargin, int sellInMargin = -1)
        {
            var nextQuality = item.Quality + qualityMargin;
            if (nextQuality >= 0 && nextQuality <= MaxQuality)
            {
                item.Quality += qualityMargin;
            }
            else
            {
                if (nextQuality <= 0)
                {
                    item.Quality = 0;
                }
                else
                {
                    item.Quality = MaxQuality;
                }
            }
            item.SellIn += sellInMargin;

        }
    }

}
