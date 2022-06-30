using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Abstractions
{
    public abstract class QualityManagerBase : IQualityManager
    {
        protected Item Item { get; }
        protected QualityManagerBase(Item item)
        {
            Item = item;
        }
        protected virtual int UpdateQualityMargin { get; set; } = 0;
        protected virtual int UpdateSellInMargin { get; set; } = 1;
        protected virtual int MaxQuality { get; set; } = 50;
        protected int Quality
        {
            get
            {
                return Item.Quality;
            }
            set
            {
                if (value < MaxQuality && value > 0)
                {
                    Item.Quality = value;
                }
            }
        }
        public abstract void UpdateQuality();
        protected void UpdateWithQualityMarging()
        {
            Quality += UpdateQualityMargin;
            Item.SellIn -= UpdateSellInMargin;
        }
    }

}
