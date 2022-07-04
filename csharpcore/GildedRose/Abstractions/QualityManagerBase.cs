using GildedRoseKata;
using System;

namespace GildedRose.Abstractions
{
    public abstract class QualityManagerBase : IQualityManager
    {
        protected virtual int UpdateQualityMargin { get; set; } = 0;
        protected virtual int UpdateSellInMargin { get; set; } = -1;
        protected virtual int MaxQuality { get; set; } = 50;
        public abstract void UpdateQuality(Item item);
        protected void UpdateWithMargings(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            var nextQuality = item.Quality + UpdateQualityMargin;
            if (nextQuality >= 0 && nextQuality <= MaxQuality)
            {
                item.Quality += UpdateQualityMargin;
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
            item.SellIn += UpdateSellInMargin;

        }
    }

}
