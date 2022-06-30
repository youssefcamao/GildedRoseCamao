using GildedRose.Abstractions;
using GildedRoseKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.QualityManagers
{
    public class SulfurasQualityManager : QualityManagerBase
    {
        public SulfurasQualityManager(Item item) : base(item)
        {

        }
        protected override int UpdateSellInMargin { get; set; } = 0;
        public override void UpdateQuality()
        {
            UpdateWithQualityMarging();
        }
    }
}
