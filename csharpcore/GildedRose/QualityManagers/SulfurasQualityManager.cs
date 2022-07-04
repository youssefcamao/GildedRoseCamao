using GildedRose.Abstractions;

namespace GildedRose.QualityManagers
{
    public class SulfurasQualityManager : QualityManagerBase
    {
        protected override int UpdateSellInMargin { get; set; } = 0;
        public override void UpdateQuality(Item item)
        {
            MaxQuality = 80;
            UpdateWithMargings(item);
        }
    }
}
