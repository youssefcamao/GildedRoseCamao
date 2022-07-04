using GildedRose.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private readonly Dictionary<string, IQualityManager> _qualityItemsDefinition;
        private readonly IQualityManager _standardQualityManager;

        public GildedRose(IList<Item> Items, Dictionary<string, IQualityManager> qualityItemsDefinition, IQualityManager standardQualityManager)
        {
            _items = Items;
            _qualityItemsDefinition = qualityItemsDefinition;
            _standardQualityManager = standardQualityManager;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (_qualityItemsDefinition.TryGetValue(item.Name, out var qualityManger))
                {
                    qualityManger.UpdateQuality(item);
                }
                else
                {
                    _standardQualityManager.UpdateQuality(item);
                }
            }
        }
    }
}
